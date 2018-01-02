using xyj.core.Extensions;

namespace xyj.acs.Models
{
    public class Navbar
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string ImageClass { get; set; }
        public string Activeli { get; set; }
        public bool Status { get; set; }
        public string ParentId { get; set; }
        public bool IsParent { get; set; }
        public string Url { get; set; }
        public string FinalUrl {
            get
            {
                return Url.HasValue()
                    ? Url
                    : string.Format("/{0}/{1}/{2}", Area.TrimString(), Controller.TrimString(), Name.TrimString());
            }
        }
    }
}