using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using Qx.Report.Configs;
using Qx.Report.Interfaces;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Exceptions.Report;
using Qx.Tools.Models.Report;

namespace Qx.Report.Services
{
    public class ReportServices : IReportServices
    {

        #region Sql报表模板

        private string Sql_Query_Template(string sql, int pageIndex, int perCount,string filterScript)
        {
            sql = sql.ToLower();

         
            #region 行过滤
            //未预置标识符?  系统自动添加标识符
            if (!sql.Contains("#filter"))
                { //存在where 子句?
                    if (sql.Contains("where"))
                    {
                        if (!sql.Replace("where", "").Contains("where"))
                        {
                            //存在1个where子句
                            sql = sql.Replace("where", "where #filter and ");
                        }
                        else
                    {//存在多个where子句(使用#where标识)
                        sql = sql.Replace("#where", "where #filter and ");
                    }
                    }
                    else
                    {//sql中无where的系统自动添加where子句
                        if (!sql.Contains("order by"))
                        {
                            sql += "where #filter";
                        }
                        else
                        {
                            throw new DataFilterScriptException("该sql脚本过于复杂，系统无法自动解析行权限，请手动在主where后前加#或在相应位置添加标识符：#filter");
                        }
                    }
                }
                //处理sql脚本
                sql = sql.Replace("#filter", filterScript);
            #endregion

            sql = sql.ReplaceFirst("select", "select IDENTITY(INT,1,1) as _序号xh,").
                ReplaceFirst("from", " into #TEMPTABLE from ", sql.Contains("#from") ? "#" : "");

            sql += string.Format(@"
                select top {0} * from #TEMPTABLE where _序号xh>(({1}-1)*{0})
                DROP TABLE #TEMPTABLE;", perCount, pageIndex);
            return sql;

        }
        #endregion
        private List<List<string>> _dataRows;
        private List<List<string>> _dataRowsCrossDb;
        private List<List<string>> _dataRowsToShow;
        private List<List<string>> _dataRowsWithOperat;
        private string _dbConnStringKey;

        private string _filterScript;
        private string _finalSql;
        private string _id;
        private bool _isDbSource;
        private bool _isCrossDb;
        private string _parms;
        private List<string> _title;
        private List<string> _titleToShow;

        private List<string> _colunmToShowConfig;
        private List<string> _operateConfigs;
        private List<string> _operatCol;
        private ReportModel _report;
        private ReportViewModel _reportViewModel;
       
        //基于service
        public void Init(string id, string parms, List<List<string>> dataRows, int pageIndex , int perCount )
        {
            var report = GetReprot(id);
            Init(report, parms, dataRows); 
        }
        //基于报表
        public void Init(string id, string parms, string dbConnStringKey, int pageIndex, int perCount)
        {
            var report = GetReprot(id);
            Init(report, parms, dbConnStringKey, pageIndex, perCount);
        }
        //基于报表2
        public void Init(ReportModel report, string parms, string dbConnStringKey, int pageIndex , int perCount )
        {
            //默认false,若垮库则更改
            _isCrossDb = false;
            _dbConnStringKey = dbConnStringKey;
            //读取数据行
            var dataRows = _dbDataSource(report, parms, dbConnStringKey, pageIndex, perCount);
            Init(report, parms, dataRows);
        }
        public void Init(ReportModel report, string parms, List<List<string>> dataRows)
        {
            _id = report.ReportID;
            _parms = parms;
            _dataRows = dataRows;
            _dataRowsWithOperat = new List<List<string>>();//只是申请空间
            _operatCol = new List<string>();//只是申请空间
            _dataRowsToShow = new List<List<string>>();//只是申请空间
            _titleToShow = new List<string>();//只是申请空间
            _dataRowsCrossDb = new List<List<string>>();//只是申请空间
            _reportViewModel = new ReportViewModel();//只是申请空间
            _report = report; 
             _title = _report.HeadFields.UnPackString(';');
            _colunmToShowConfig = _report.ColunmToShow.UnPackString(';').ToList();//读取列配置
            _operateConfigs = _report.OperateColum.UnPackString(';');    //读取操作列配置    --列索引:值:内容;列索引:值:内容 
            _isDbSource = _report.SqlStr.ToLower().Contains("select") && _report.SqlStr.ToLower().Contains("from");

            //if (isDbSource == _isDbSource)
            //{
            //    _isDbSource = isDbSource;
            //}
            //else
            //{
            //    throw new Exception("调用出错,当前配置是FromDb,但调用的接口是FromService！");
            //}
        }
        private List<List<string>> _dbDataSource(ReportModel report, string parms, string dbConnStringKey, int pageIndex , int perCount)
        {

            var sql = "";
            try
            {
                sql = string.Format(report.SqlStr, // FormatString(
                    parms.UnPackString(';').ToArray<object>()
                    // )
                    );
                _finalSql = Sql_Query_Template(sql, pageIndex, perCount,_filterScript);
            
            }
            catch (Exception ex)
            {
                throw new SqlErrorException("请检查parms个数和Sql中预留参数个数是否相同！\n" + ex.Message);
            }
            var connStr = "";
            try
            {
                //读取数据行
                 connStr = ConfigurationManager.ConnectionStrings[dbConnStringKey].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new DataBaseNotFoundException("没有在web.config的connectionStrings节点中找到name为" + dbConnStringKey+ "的connectionString，请添加");
            }
            var dataRows = _finalSql.ExecuteReader2(connStr);
            //删除第一列
            dataRows = dataRows.RemoveCol(0);
            return dataRows;
        }

        private void Do()
        {
            var dataRowToDeal=new List<List<string>>();
            if (_dataRows.Count > 0 )
            {
                if (_isCrossDb)
                {
                    if (_dataRowsCrossDb.Any(a => a.Count != _title.Count))
                    {
                        throw new ReportConfigErrorException("请检查标题列数量是否等于数据列数量！\r\n_title=>" + _title.Count + "\r\nbody[0]=>" + _dataRowsCrossDb[0].Count);
                    }

                    dataRowToDeal = _dataRowsCrossDb;
                }
                else
                {
                    if (_dataRows.Any(a => a.Count != _title.Count))
                    {
                        throw new ReportConfigErrorException("请检查标题列数量是否等于数据列数量! \r\n_title=>" + _title.Count + "\r\nbody[0]=>" + _dataRows[0].Count);
                    }
                    dataRowToDeal = _dataRows;
                }
            }

            //构造操作列
            _operatCol = GetOperatCol(dataRowToDeal, _operateConfigs);//*赋值
            //过滤显示列
            _titleToShow.AddRange(_title.FilterRow(_colunmToShowConfig));//*赋值
            _dataRowsToShow.AddRange(dataRowToDeal.FilterRows(_colunmToShowConfig));//*赋值
            _dataRowsWithOperat.AddRange(_PackTable(_titleToShow,_dataRowsToShow,_operatCol)); //*赋值

            _reportViewModel.report = _report;
            _reportViewModel.header = _titleToShow;
            _reportViewModel.tableBody = _dataRowsToShow;
            _reportViewModel.header_all = _title;
            _reportViewModel.tableBody_all = dataRowToDeal;
            _reportViewModel.operatCol = _operatCol;
            _reportViewModel.FinalView = _dataRowsWithOperat;
        }

        private List<List<string>> _PackTable(List<string> title,List<List<string>>body, List<string>op)
        {
            var temp = new List<List<string>>();
            //插入标题
            temp.Add(title);
            //插入数据行
            temp.AddRange(body);
            //插入操作列
            temp = temp.AddCol(op);
            return temp;
        }
        #region 跨库

        private List<List<string>> _CrossDb( List<List<string>> rows,List<CrossDbParam>  paramList)
        {
            //标记CrossDb
            _isCrossDb = true;
            //新空间
            List<List<string>>dest=new List<List<string>>() ;

            paramList.ForEach(a =>
            {
                dest = __CrossDb(rows, a);
            });
          
            return dest;
        }
        private List<List<string>> __CrossDb( List<List<string>> rows, CrossDbParam param)
        {
            //新空间
            var temp = new List<List<string>>();
            rows.ForEach(a =>
            {
                temp.Add(___CrossDb(a, param));
            });     
            return temp;
        }

        private List<string> ___CrossDb(List<string>row, CrossDbParam param)
        {
            //新空间
            var temp = new List<string>();
            temp.AddRange(row);
            //如果OutIndex在ParamIndex的前面,则没有数据列，但是配置是按照有数据列进行配置的，因此自动ParamIndex-1
            if (param.OutIndex < param.ParamIndex)
            {
                param.ParamIndex -= 1;
            }
            var newCol = param.Func(row[param.ParamIndex]);
            if (param.OutIndex == -1)
            {
                temp.Add(newCol);
                ////同步标题
                //if (_title.Count < row.Count)
                //{
                //    _title.Add(param.OutTitle);
                //}
               
            }
            else
            {
                if(param.OutIndex>=temp.Count)
                    throw new Exception("OutIndex必须小于"+ temp.Count);
                temp.Insert(param.OutIndex, newCol);
                ////同步标题
                //if (_title.Count < row.Count)
                //{
                //    _title.Insert(param.OutIndex, param.OutTitle);
                //}
               
            }
            return temp;
        }
        #endregion 
        private string[] FormatString(List<string> srcString, char flag = '%')
        {
            return srcString.Select(o => flag + o.Replace("请选择", "") + flag).ToArray();
        }

        #region 增删改查

        public bool Add(ReportModel model)
        {
            var sql = string.Format(@"INSERT INTO report_data
           ([ReportID]
           ,[ReportName]
           ,[SqlStr]
           ,[HeadFields]
           ,[RecordsPerPage]
           ,[ParaNames]
           ,[ColunmToShow]
           ,[OperateColum]
           )
     VALUES
           ('{0}'
           ,'{1}'
           ,'{2}'
           ,'{3}'
           ,'{4}'
           ,'{5}'
           ,'{6}'
           ,'{7}')", model.ReportID.Replace("'", "''"),
                model.ReportName.Replace("'", "''"),
                model.SqlStr.Replace("'", "''"),
                model.HeadFields.Replace("'", "''"),
                model.RecordsPerPage,
                model.ParaNames.Replace("'", "''"),
                model.ColunmToShow.Replace("'", "''"),
                model.OperateColum.Replace("'", "''")
                );
            return sql.ExecuteNonQuery(Setting.ReportRuleConnectionString) > 0;
        }

        public bool Update(ReportModel model)
        {
            var openLog = false;//日志开关
            var reportLog = "";
            var old = GetReprot(model.ReportID);
            if(openLog)
            {
                var logList = old.ReportLog.HasValue()
               ? old.ReportLog.Deserialize<List<ReportModel>>()
               : new List<ReportModel>();
                //打包完删除旧日志
                logList.Add(model);
                reportLog = logList.Serialize();
            }
           

            var sql = string.Format(@"UPDATE report_data
               SET ReportName = '{1}'
                  ,SqlStr =  '{2}'
                  ,HeadFields = '{3}'
                  ,RecordsPerPage = '{4}'
                  ,ParaNames = '{5}'
                  ,ColunmToShow = '{6}'
                  ,OperateColum = '{7}'
                  ,ReportLog  = '{8}'
             WHERE ReportID = '{0}'", model.ReportID.Replace("'", "''")
                , model.ReportName.Replace("'", "''"),
                model.SqlStr.Replace("'", "''"),
                model.HeadFields.Replace("'", "''"),
                model.RecordsPerPage,
                model.ParaNames.Replace("'", "''"),
                model.ColunmToShow.Replace("'", "''"),
                model.OperateColum.Replace("'", "''"),
                model.ReportLog = reportLog.Replace("'", "''")
                );
            return sql.ExecuteNonQuery(Setting.ReportRuleConnectionString) > 0;
        }


        public bool Delete(string id)
        {
            var sql = string.Format(@"DELETE FROM report_data
            WHERE [ReportID] = '{0}'", id);
            return sql.ExecuteNonQuery(Setting.ReportRuleConnectionString) > 0;
        }

        public ReportModel GetReprot(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("请传入报表编号！");
            var sql =
                string.Format(
                    "select ReportID,ReportName,SqlStr,HeadFields,RecordsPerPage,ParaNames,ColunmToShow,OperateColum,ReportLog " +
                    "FROM report_data  where ReportID='{0}'",
                    id);

            return ReportModel.ToReport(sql.ExecuteReader2(Setting.ReportRuleConnectionString));
        }

        #endregion

        #region 获取操作列

        //获取多行的多条配置的操作列
        private List<string> GetOperatCol(List<List<string>> rows, List<string> operateConfigs)
        {
            var dest = new List<string> {"操作"};
            dest.AddRange(rows.Select(row => _GetOperatCol(row, operateConfigs).PackString(' ')));
            return dest;
        }

        //获取某行的多条配置的操作列
        private List<string> _GetOperatCol(List<string> row, List<string> operateConfigs)
        {
            return operateConfigs.Select(config => __GetOperatColFactory(row, config)).ToList();
        }

        //获取某行的一条配置的操作列

        #region 配置帮助

        // v1.0.0 配置帮助 (按新版本配置，旧版本将在新项目中弃用)

        //说明             参数个数       参数格式                                          
        //无条件无参数         1          内容                                                
        //无条件带一个参数     2          内容:参数1列索引;                                   
        //带条件不带参数       3          条件列索引:条件值:内容;                             
        //带条件带一个参数     4          条件列索引:条件值:内容:参数1列索引;                 
        //带条件带两个参数     5          条件列索引:条件值:内容:参数1列索引:参数2列索引;     


        // v1.0.1 配置帮助  v2.0.0

        //类型    说明             配置参数个数      带类型的参数格式
        //  N0    无条件无参数         2             类型:内容
        //  N1    无条件带一个参数     3             类型:内容:参数1列索引;
        //  N2    无条件带两个参数     4             类型:内容:参数1列索引:参数2列索引;
        //  Y0    带条件不带参数       4             类型:条件列索引:条件值:内容;
        //  Y1    带条件带一个参数     5             类型:条件列索引:条件值:内容:参数1列索引;
        //  Y2    带条件带两个参数     6             类型:条件列索引:条件值:内容:参数1列索引:参数2列索引;

        // v2.0.2 配置帮助

        //类型    说明                     配置参数个数      带类型的参数格式
        //  N0    无条件无参数                  2            类型:内容
        //  N1    无条件带1个参数               3            类型:内容:参数1列索引;
        //  N2    无条件带2个参数               4            类型:内容:参数1列索引:参数2列索引;
        //  Y0    带条件不带参数                4            类型:条件列索引:条件值:内容;
        //  Y1    带条件带1个参数               5            类型:条件列索引:条件值:内容:参数1列索引;
        //  Y2    带条件带2个参数               6            类型:条件列索引:条件值:内容:参数1列索引:参数2列索引;

        //  YC0   带条件带运算符不带参数        5            类型:条件列索引:条件运算符:条件值:内容;
        //  YC1   带条件带运算符带1个参数       6            类型:条件列索引:条件运算符:条件值:内容:参数1列索引;
        //  YC2   带条件带运算符带2个参数       7            类型:条件列索引:条件运算符:条件值:内容:参数1列索引:参数2列索引;

        // v2.0.2 条件运算符配置帮助 

        // 运算符               说明
        //  =                   等于    
        //  !=                  不等于
        //  >                   大于    
        //  <                   小于    
        //  >=                  大于等于    
        //  <=                  小于等于  

        // v2.0.3 配置帮助

        //类型    说明                     配置参数个数      带类型的参数格式
        //  N0    无条件无参数                  2            类型:内容
        //  N1    无条件带1个参数               3            类型:内容:参数1列索引;
        //  N2    无条件带2个参数               4            类型:内容:参数1列索引:参数2列索引;
        //  Y0    带条件不带参数                4            类型:条件列索引:条件值:内容;
        //  Y1    带条件带1个参数               5            类型:条件列索引:条件值:内容:参数1列索引;
        //  Y2    带条件带2个参数               6            类型:条件列索引:条件值:内容:参数1列索引:参数2列索引;

        //  YC0   带条件带运算符不带参数        5            类型:条件列索引:条件运算符:条件值:内容;
        //  YC1   带条件带运算符带1个参数       6            类型:条件列索引:条件运算符:条件值:内容:参数1列索引;
        //  YC2   带条件带运算符带2个参数       7            类型:条件列索引:条件运算符:条件值:内容:参数1列索引:参数2列索引;

        #endregion

        private string __GetOperatColFactory(List<string> row, string operateConfig)
        {
            //var v1 = __GetOperatCol(row, operateConfig);
            var v2 = __GetOperatColExtend(row, operateConfig).Replace("<a", "<a class='qx-operate' ");
            return //v1 + 
                v2;
        }

        #region 转义规则

        //  字符                   转义后
        //   ;                    $semicolon

        #endregion

        private string __GetOperatCol(List<string> row, string operateConfig)
        {
            //单条配置
            var _operateConfig = operateConfig.Replace("\r\n", "")
                .Replace("$semicolon", ";") //2016-09-05 新增转义规则
                .Trim().UnPackString(':');
            var html = "";

            #region 防错预判断

            if (!(_operateConfig.Count >= 0 &&
                  _operateConfig.Count <= 5) || (_operateConfig.Count > 0 &&
                                                 (_operateConfig[0][0] == 'Y' ||
                                                  _operateConfig[0][0] == 'N')))
            {
                return "";
            }

            #endregion

            for (var i = 0; i < row.Count; i++)
            {
                switch (_operateConfig.Count)
                {
                    case 1:
                    {
//不带条件直接中断
                        return _operateConfig[0] .AddSpace();
                    }
                    case 2:
                    {
//不带条件直接中断
                        return string.Format(_operateConfig[0], row[int.Parse(_operateConfig[1])]) .AddSpace();
                    }

                    case 3:
                        if (int.Parse(_operateConfig[0]) == i && _operateConfig[1] == row[i])
                        {
                            html += _operateConfig[2] .AddSpace();
                        }
                        break;
                    case 4:
                        if (int.Parse(_operateConfig[0]) == i && _operateConfig[1] == row[i])
                        {
                            html += string.Format(_operateConfig[2], row[int.Parse(_operateConfig[3])]).AddSpace();
                        }
                        break;
                    case 5:
                        if (int.Parse(_operateConfig[0]) == i && _operateConfig[1] == row[i])
                        {
                            html +=
                                string.Format(_operateConfig[2], row[int.Parse(_operateConfig[3])],
                                    row[int.Parse(_operateConfig[4])]) .AddSpace();
                        }
                        break;
                }
            }
            return html;
        }


        private object[] __GetOperatColV22(List<string> row,int startIndex, char paramCountString, List<string> operateConfig)
        {//生成参数数组
            var paramCount = int.Parse(paramCountString+"");
            var paramArray = new List<object>();
            for (var index = startIndex; index < startIndex + paramCount; index++)
            {
                paramArray.Add(row[int.Parse(operateConfig[index])]);
            }
            return paramArray.ToArray();
        }
        private string __GetOperatColExtend(List<string> row, string operateConfig)
        {
            var _operateConfig = operateConfig.Replace("\r\n", "")
                .Replace("$semicolon", ";") //2016-09-05 新增转义规则
                .Trim()
                .UnPackString(':'); //UnPackString(operateConfig, ':', true).ToList();
            var html = "";

            #region 防错预判断

            if (!
                (_operateConfig.Count > 0 &&
                 (_operateConfig[0][0] == 'Y' ||
                  _operateConfig[0][0] == 'N')))
            {
                return "";
            }

            #endregion

            for (var i = 0; i < row.Count; i++)
            {
                if (_operateConfig[0][0]== 'Y' && _operateConfig[0][1] == 'C')
                {//YC系列
                    if (int.Parse(_operateConfig[1]) == i && OpFactory(row[i], _operateConfig[2], _operateConfig[3]))
                        html += string.Format(_operateConfig[4], __GetOperatColV22(row,5, _operateConfig[0][2], _operateConfig)).AddSpace();
                }
                else if (_operateConfig[0][0] == 'Y')
                {//Y系列-先处理条件再理参数
                    if (int.Parse(_operateConfig[1]) == i && _operateConfig[2] == row[i])
                        html += string.Format(_operateConfig[3], __GetOperatColV22(row, 4, _operateConfig[0][1], _operateConfig)).AddSpace();

                }
                else if (_operateConfig[0][0] == 'N')
                {//N系列-只处理参数
                    var p = __GetOperatColV22(row, 2, _operateConfig[0][1], _operateConfig);
                    return string.Format(_operateConfig[1],p).AddSpace();
                }
                else 
                {
                    throw new NotSupportedException("操作列配置格式错误,请仔细核查操作列的配置规则！\n出错的配置为：" + _operateConfig.PackString());
                }
            }
            return html;
        }


        private bool OpFactory(string dbValue, string opString, string configValue)
        {
            //var configValueInt = int.Parse(dbValue);
            var result = false;
            switch (opString)
            {
                case "=":
                {
                    if (dbValue == configValue)
                    {
                        result = true;
                    }
                }
                    ;
                    break;
                case "!=":
                {
                    if (dbValue != configValue)
                    {
                        result = true;
                    }
                }
                    ;
                    break;
                case ">":
                {
                    if (double.Parse(dbValue) > double.Parse(configValue))
                    {
                        result = true;
                    }
                }
                    ;
                    break;
                case ">=":
                {
                    if (double.Parse(dbValue) >= double.Parse(configValue))
                    {
                        result = true;
                    }
                }
                    ;
                    break;
                case "<":
                {
                    if (double.Parse(dbValue) < double.Parse(configValue))
                    {
                        result = true;
                    }
                }
                    ;
                    break;
                case "<=":
                {
                    if (double.Parse(dbValue) <= double.Parse(configValue))
                    {
                        result = true;
                    }
                }
                    ;
                    break;
            }
            return result;
        }

        #endregion

        #region 旧版

        public string ToExcel(string id, string parms, string templateFileDir, string outputFileDir,
            string dbConnStringKey,int pageIndex=1,int perCount=10)
        {
            Init(id, parms, dbConnStringKey, pageIndex, perCount);
            Do();
            var content = _dataRows.AddRowToFirst(_titleToShow.Where(a=>!a.Contains("操作")).Select(b=>b).ToList());
            return new ExcelUtility(content, templateFileDir, outputFileDir).ToExcel().FullName;
        }

        public List<List<string>> ToHtml(string id, string parms, string dbConnStringKey, 
            int pageIndex = 1, int perCount = 10)
        {
            Init(id, parms, dbConnStringKey, pageIndex, perCount);
            Do();
            return _dataRowsWithOperat;
        }

        #endregion

        #region 新版

        public List<List<string>> GetDbDataSource(string id, string parms, string dbConnStringKey,
            int pageIndex = 1, int perCount = 10)
        {
            return _dbDataSource(GetReprot(id), parms, dbConnStringKey, pageIndex, perCount);
        }

        public string ToExcel(string id, string parms, string templateFileDir, string outputFileDir,
            List<List<string>> dataRows,
            int pageIndex = 1, int perCount = 10)
        {
            Init(id, parms, dataRows, pageIndex, perCount);
            Do();
            return new ExcelUtility(_dataRows, templateFileDir, outputFileDir).ToExcel().FullName;
        }

        public List<List<string>> ToHtml(string id, string parms, List<List<string>> dataRows,
            int pageIndex = 1, int perCount = 10)
        {
            Init(id, parms, dataRows, pageIndex, perCount);
            Do();
            return _dataRowsWithOperat;
        }
        //新版，支持垮裤
        public List<List<string>> CrossDb(string id, string parms, List<List<string>> dataRows,  List<CrossDbParam> paramList,
            int pageIndex = 1, int perCount = 10)
        {
            //第一行不参与运算
            dataRows.RemoveAt(0);
            Init(id, parms, dataRows, pageIndex, perCount);
           
            //追加数据行，注意操作列的配置
           _dataRowsCrossDb.AddRange(_CrossDb(_dataRows, paramList));//*赋值
            Do();
            return _dataRowsWithOperat;
        }
        public List<List<string>> Test(ReportModel report, string parms,string dbConnStringKey,
            int pageIndex = 1, int perCount = 10)
        {
            _filterScript = "1=1";
            Init(report, parms, dbConnStringKey, pageIndex, perCount);
            Do();
            return _dataRowsWithOperat;
        }
        #endregion

        public ReportViewModel ToView(string id, string parms, string dbConnStringKey, int pageIndex = 1, int perCount = 10, string filterScript = "")
        {
            _filterScript = filterScript;
           
            Init(id, parms, dbConnStringKey, pageIndex, perCount);
            Do();
            return _reportViewModel.SetPageParam(pageIndex, perCount, filterScript,_finalSql);
           
        }

        public ReportViewModel ToView(string id, string parms, List<List<string>> dataSource
            , int pageIndex = 1, int perCount = 10, string filterScript = "")
        {
            _filterScript = filterScript;
            Init(id, parms, dataSource, pageIndex, perCount);
            Do();
            return _reportViewModel.SetPageParam(pageIndex, perCount, filterScript, _finalSql);
        }
    }
}