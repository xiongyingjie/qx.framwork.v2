using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Qx.Contents.Entity;
using Qx.Contents.Interfaces;
using Qx.Contents.Models;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Contents.Services
{
    public class ContentService : BaseRepository, IContents
    {
        public TableDesign GetTableDesign(string tableId)
        {
            var dest = Db.content_table_design.Where(a => a.ctd_id == tableId).
                Select(b => new TableDesign
                {
                    TableID = b.ctd_id,
                    TypeID = b.ct_id,
                    TypeName = b.content_type.type_name,
                    TableName = b.table_name,
                    Columns = b.content_column_design.
                        Select(c => new TableColumn
                        {
                            ColumnID = c.ccd_id,
                            DateTypeID = c.dt_id,
                            PageControlID = c.pct_id,
                            ColumnName = c.column_name,
                            DateTypeName = c.column_name,
                            PageControlName = c.page_control_type.pct_name,
                            Seq = c.seq,
                            IsPk = c.is_pk,
                            DefValue = c.def_value,
                            Value = c.def_value,//"警告:要获取各列的值请调用方法 GetTableValue(string tableId, string relationKeyId)"
                            Num = c.content_column_ui_design.num,
                            Tip = c.content_column_ui_design.tip,
                            Validators = c.content_column_ui_design.validators,
                            Options = c.content_column_ui_design.options,
                            Width = c.content_column_ui_design.width  ,
                            Height = c.content_column_ui_design.height,
                            Vertical = c.content_column_ui_design.vertical,
                            Folder = c.content_column_ui_design.folder,
                            SubmitUrl = c.content_column_ui_design.submitUrl,
                            Color = c.content_column_ui_design.color,
                        }).
                        OrderBy(d => d.Seq)
                });
            if (dest.Any())
            {
                return dest.FirstOrDefault();
            }
            throw new Exception(string.Format("tableId不存在，请确保传入了正确的tableId，当前传入的tableId是 '{0}'", tableId));
            ;
        }

   

        public TableValue  GetTableValue(string tableId, string relationKeyId)
        {
            var dest = Db.content_table_design.Where(a => a.ctd_id == tableId).
                Select(b => new TableValue
                {
                    TableID = b.ctd_id,
                    TypeID = b.ct_id,
                    RelationKeyID = relationKeyId,
                    TypeName = b.content_type.type_name,
                    TableName = b.table_name,
                    Columns = Db.content_column_value.Where(a=>a.relation_key_value==relationKeyId).
                        Select(c => new TableColumn
                        {
                            ColumnID = c.ccd_id,
                            DateTypeID = c.content_column_design.dt_id,
                            PageControlID = c.content_column_design.pct_id,
                            ColumnName = c.content_column_design.column_name,
                            DateTypeName = c.content_column_design.column_name,
                            PageControlName = c.content_column_design.page_control_type.pct_name,
                            Seq = c.content_column_design.seq,
                            IsPk = c.content_column_design.is_pk,
                            DefValue = c.content_column_design.def_value,
                            Value =c.column_value
                        }).
                        OrderBy(d => d.Seq)
                });
            if (dest.Any())
            {
                return dest.FirstOrDefault();
            }
            throw new Exception(string.Format("tableId不存在，请确保传入了正确的tableId，当前传入的tableId是 '{0}'", tableId));
            ;
        }

        public List<TableValue> GetTableValues(string tableId)
        {
            var keys=Db.content_column_value.Where(a => a.content_column_design.ctd_id == tableId). GroupBy(b => b.relation_key_value).ToList();
            var result = keys.Select(c => GetTableValue(tableId, c.Key)).ToList();
            return result;
        }

        public List<IGrouping<string, content_column_value>> GetTableValuesKeys(string tableId)
        {
            var keys = Db.content_column_value.Where(a => a.content_column_design.ctd_id == tableId).GroupBy(b => b.relation_key_value).ToList();
            return keys;
        }

        public bool UpdateTable(ContentBag contentValueBag)
        {
            var rule = GetTableDesign(contentValueBag.TableId);
            //验证数据合法性
            var require = rule.Columns;
            var real = contentValueBag.Values;
            if (require.Count() != real.Count())
            {
                throw new Exception(string.Format("参数个数不匹配，应该传入的参数个数是'{0}',实际传入的个数是'{1}'", require, real));
            }
            if (require.Select(a => a.ColumnID).ToList().Except(real.Select(b => b.ColumnID)).Any())
            {
                throw new Exception(string.Format("参数不匹配，应该传入的参数是'{0}',实际传入的是'{1}'",
                    string.Concat(require.Select(a => a.ColumnID + ",")),
                    string.Concat(real.Select(a => a.ColumnID + ","))));
            }
            contentValueBag.Values.ToList().ForEach(a =>
            {
                var model = new content_column_value
                {
                    ccv_id = a.ColumnID + "-" + contentValueBag.RelationKeyID,
                    ccd_id = a.ColumnID,
                    column_value = a.ColumnValue,
                    relation_key_value = contentValueBag.RelationKeyID.HasValue()
                        ? contentValueBag.RelationKeyID
                        : Db.content_column_design.NoTrackingFind(b => b.ccd_id == a.ColumnID).def_value //设置默认值
                };
                //是否存在旧数据
                if (Db.content_column_value.Any(b => b.ccv_id == model.ccv_id))
                {
                    Db.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    Db.content_column_value.Add(model);
                }
            });
            return Db.Saved();
        }

        public bool UpdateTable(HttpContext request, string tableId, string relationKeyId)
        {
            var rule = GetTableDesign(tableId);
            //从表单提取数据
            var dest = new ContentBag
            {
                TableId = tableId,
                RelationKeyID = relationKeyId,
                Values = rule.Columns.Select(a =>
                    new ContentValue
                    {
                        ColumnID = a.ColumnID,
                        ColumnValue = request.Request.Query[a.ColumnID]  
                    }
                    )
            };

            return UpdateTable(dest);
        }
    }
}