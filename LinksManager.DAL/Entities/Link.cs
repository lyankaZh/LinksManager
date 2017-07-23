using System.ComponentModel.DataAnnotations;

namespace LinksManager.DAL.Entities
{
    public class Link
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public virtual string Category { get; set; }
    }
}
