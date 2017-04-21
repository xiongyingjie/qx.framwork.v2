using System.Collections.Generic;

namespace Qx.Contents.Models
{
    public class ContentBag
    {
        public IEnumerable<ContentValue> Values;
        public string TableId { get; set; }
    }
}