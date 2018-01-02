namespace xyj.core.Models.Form
{
    public class FormUI
    {
        public FormUI(int code, string msg, string url, string jsonData)
        {
            this.code = code;
            this.msg = msg;
            this.url = url;
            this.jsonData = jsonData;
        }

        public FormUI()
        {

        }
        public int code;
        public string msg;
        public string url;
        public string jsonData;

    }
}