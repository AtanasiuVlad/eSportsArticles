using eSportsArticles.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eSportsArticles.Models
{
    public class Article
    {
        [Key] // [Required]
        public Guid Id { get; set; }
        [Display (Name ="Category")]
        public ArticleCategory articleCategory { get; set; }
        [Display (Name ="Name")]
        public string articleName { get; set; }
		[Display(Name = "Price")]
		public double Price { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
		[Display(Name = "Stars raiting")]
		public float ratingStars { get; set; }
		[Display(Name = "Color")]
		public string Color { get; set; }
		[Display(Name = "Size")]
		public string Size { get; set; }
		[Display(Name = "Available")]
		public bool isAvailable { get; set; }
		[Display(Name = "When is available")]
		public DateTime startAvailablePeriod { get; set; }
		public DateTime endAvailablePeriod { get; set; }

		[Display(Name = "Picture")]
		public string PictureURL  { get; set; }
        
        //Relationships
        public List<StoresArticles> storeArticles { get; set;}
    }
}
