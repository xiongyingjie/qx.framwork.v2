using System.Collections.Generic;


namespace Web.Controllers
{
    public class UploadResult
        {
            public UploadResult()
            {
                this.files = new List<FileItem>();
            }

            public UploadResult Add(FileItem item)
            {
                files.Add(item);
                return this;
            }
            public List<FileItem> files { get; set; }
        }

}