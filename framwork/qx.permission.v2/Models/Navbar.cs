namespace qx.permmision.v2.Models
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
    }
}