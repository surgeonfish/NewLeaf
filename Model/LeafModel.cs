namespace NewLeaf.Model
{
    public class LeafModel
    {
        public DatabaseHelper DatabaseHelper = null;

        public int Id { get; set; }

        public virtual string Content
        {
            get {  return ContentProperty; }
            set
            {
                ContentProperty = value;
                DatabaseHelper?.UpdateContent(Id, value);
            }
        }
        private string ContentProperty;

        public virtual string Color
        {
            get { return ColorProperty; }
            set
            {
                ColorProperty = value;
                DatabaseHelper?.UpdateColor(Id, value);
            }
        }
        private string ColorProperty;

        public string DateCreated { get; set; }

        public string DateLastUpdated { get; set; }
    }
}
