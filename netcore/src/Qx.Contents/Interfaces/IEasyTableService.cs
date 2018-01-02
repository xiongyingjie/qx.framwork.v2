using Qx.Contents.Entity;

namespace Qx.Contents.Interfaces
{
    public interface IEasyTableService
    {
        bool CreateEasyTable(string jsonstring,string tablename);
        bool CreateSelfEasyTable(string jsonstring, string tablename,string type);
        string GetEasyTable(string tableid);
        string GetSelfEasyTable(string tableid);
        bool DeleteEasyTable(string tableid);
        bool UpdateEasyTable(string jsonstring, string tableid);
        string GetEasyTableLie(string tableid);
        bool SaveTableLieEdit(string jsonstring, string tableid, string tablename);
        bool DeleteTableRow(string relationkeyID);
        string EidtTableRow_Before(string tableid);
        bool EidtTableRow_After(string jsonstring, string tableid, string relationkeyID);
        content_table_design CreateTable(string tablename);
        content_column_design CreateColumn(string tableid, string title, string pcttype, int CCDSeq, string dttype);
        content_column_value CreateValue(string columnid, string cvalue, string RelationKeyValue);
        void RollBack();
        string[] processJsonString(string jstring);
        string[] getJsonstringValue(string jstring);
        bool NewContentColumnDesign(string jsonstring);
        bool EditContentColumnDesign(string jsonstring);
        bool DeleteContentColumnDesign(string ccdid);
        string GetContentColumnInfo(string ccdid);
        bool NewColumnTemplate(string jsonstring);
        bool EditColumnTemplate(string jsonstring);
        bool DeleteColumnTemplate(string ctid);
        string GetColumnTemplateInfo(string ctid);
        string processHTMLstring(string html);
    }
}