using Qx.Tools;
using System.Configuration;

namespace Qx.Contents.Configs
{
    public static class Setting
    {
     
        public static readonly string ConnectionString = DbUtility.SqlSeverConnString("Qx.Contents");


        //Using for migration 请勿删除（原版）
        //public static string ConnectionString = "Data Source=scsxxt.com;Initial Catalog=Qx.Contents;Persist Security Info=True;User ID=sa;Password=Hqu33333;MultipleActiveResultSets=true";


        //////Using for migration 请勿删除 （整合版）
        //public static string ConnectionString = "Data Source=qxamoy.com,10385;database=Qx.Contents;Persist Security Info=False;User ID=sa;Password=QxamoySQL666;MultipleActiveResultSets=True;";

    }
}