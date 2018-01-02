namespace Web.Controllers
{
    public class FileItem
        {
            public string name { get; set; }
            public int size { get; set; }
            public string url { get; set; }
            public string thumbnailUrl { get; set; }
            public string deleteUrl { get; set; }
            public string deleteType { get; set; }
            public string id { get; set; }
    
            public string controlName { get; set; }
            public string savedPath { get; set; }
        }

}