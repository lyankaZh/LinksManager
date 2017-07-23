using System.ComponentModel.DataAnnotations;

namespace LinksManager.Models
{
    public class LinkModel
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }
    }
}