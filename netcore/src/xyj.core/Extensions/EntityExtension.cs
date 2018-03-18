using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using xyj.core.Exceptions.Upgrate;
using xyj.core.Utility;

namespace xyj.core.Extensions
{
    public static class EntityExtension
    {


        public static bool Saved(this DbContext db)
        {
            return db.SaveChanges()>0;
        }

        /*
        字段说明@{#类型:正则表达式:验证错误提示#}  
        角色ID@{#C1:^[0-9]*$:0-9的数字#}
        */
        private static dynamic ResolveRegRule(string colName, string noteString)
        {
            var list = noteString.UnPackString('@');
            var columnNote = list[0];
            var ruleString = list.Count > 1 ? list[1] : "";
            if (!ruleString.HasValue())
            {
                return new { name = colName, note = columnNote, ruleDetail = "" };
            }
            var detail = ruleString.PickUp().UnPackString(':');
            switch (detail[0])
            {
                //C1:^[0-9]*$:0-9的数字
                case "C1":
                    {
                        return new { name = colName, note = columnNote, ruleType = detail[0], ruleDetail = detail[1], errorTip = detail[2] };
                    }
                   
                default: { throw new NotSupportedException(string.Format("不支持改格式的解析!格式类型：{0}", detail[0])); }
            }
        }
        public static List<DbValidationError> Check(this DbContext db, object entity)
        {
            throw new NotSupportedExceptionInCoreException();
            //var list = new List<DbValidationError>();
            //var connString = "";// db.Database.Connection.Database.GetConnectionString();
            //var tableName = entity.GetType().Name;
            ////规则集合
            //var columRuleInfos = tableName.
            //    SqlTableInfo().
            //    ExecuteReader2(connString).
            //    Select(col => ResolveRegRule(col[1], col[2])).ToList();

            ////待存取的值
            //var info = ReflectionUtility.GetObjInfo(entity);
            ////属性集合
            //var info_p = info[0];
            ////值集合
            //var info_v = info[1];
            //for (var index = 0; index < info_p.Count(); index++)
            //{
            //    var p = info_p[index];
            //    var v = info_v[index];
            //    var p_rule = columRuleInfos.FirstOrDefault(rule => rule.name == p);
            //    if (p_rule != null)
            //    {
            //        //正则匹配
            //        if (!v.IsValidate((string)p_rule.ruleDetail))
            //        {
            //            list.Add(new DbValidationError(p,
            //                string.Format("{0} 不符合要求，应该为 {1}", p_rule.note, p_rule.errorTip)));
            //        }
            //    }
            //}
            //return list;
        }
        public static bool SaveAdd(this DbContext db, object entity)
        {
            //var list = db.Check(entity);
            //if (list.Any())
            //{
            //    throw new FormValitationException(list);
            //}
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
            return true;
        }

        public static bool SaveDelete(this DbContext db, object entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        public static bool SaveModified(this DbContext db, object entity)
        {
            //var list = db.Check(entity);
            //if (list.Any())
            //{
            //    throw new FormValitationException(list);
            //}
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public static bool Save<T>(this T table, DbContext db) where T : class
        {
            return db.Saved();
        }

    }

    public class DbValidationError
    {
        private string p;
        private dynamic dynamic;

        public DbValidationError(string p, dynamic dynamic)
        {
            this.p = p;
            this.dynamic = dynamic;
        }
    }
}