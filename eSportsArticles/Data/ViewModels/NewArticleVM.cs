using eSportsArticles.Data.Base;
using eSportsArticles.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eSportsArticles.Models
{
    public class NewArticleVM
    {
		[Key]
        public Guid Id { get; set; }
        [Display (Name ="Category")]
		[Required(ErrorMessage = "Category is required!")]
        public ArticleCategory articleCategory { get; set; }
        [Display (Name ="Name")]
		[Required(ErrorMessage = "Name is required!")]
		public string articleName { get; set; }
		[Display(Name = "Price")]
		[Required(ErrorMessage = "Price is required!")]
		public double Price { get; set; }
		[Display(Name = "Description")]
		[Required(ErrorMessage = "Description is required!")]
		public string Description { get; set; }
		[Display(Name = "Stars raiting")]
		public float ratingStars { get; set; }
		[Display(Name = "Color")]
		[Required(ErrorMessage = "Color is required!")]
		public string Color { get; set; }
		[Display(Name = "Size")]
		[Required(ErrorMessage = "Size is required!")]
		public string Size { get; set; }
		[Display(Name = "Available")]
		[Required(ErrorMessage = "Available is required!")]
		public bool isAvailable { get; set; }
		[Display(Name = "Start date")]
		[Required(ErrorMessage = "Start date is required!")]
		public DateTime startAvailablePeriod { get; set; }
		[Display(Name = "End date")]
		[Required(ErrorMessage = "End date is required!")]
		public DateTime endAvailablePeriod { get; set; }

		[Display(Name = "Picture")]
		[Required(ErrorMessage = "Picture is required!")]
		public string PictureURL  { get; set; }

		//Relationships
		[Display(Name = "StoreIds")]
		[Required(ErrorMessage = "Store is required!")]
        public List<Guid> StoreIds { get; set;}
		public Guid storeId { get; set; }
        public Store Store { get; set; }
    }
}
