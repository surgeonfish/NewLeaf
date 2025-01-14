namespace NewLeaf.Model
{
    public class LeafModel
    {
        public DatabaseHelper DatabaseHelper = null;
        public int Id { get; set; }
        public string Content { get; set; }
        public string Color { get; set; }
        public string DateCreated { get; set; }
        public string DateLastUpdated { get; set; }
    }
}
