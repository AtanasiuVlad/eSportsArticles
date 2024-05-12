using eSportsArticles.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eSportsArticles.Models
{
    public class Store : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Display (Name = "Store Name")]
        [Required(ErrorMessage = "Store name is required")]
        [StringLength (50, MinimumLength = 3, ErrorMessage = "Store name must be between 3 and 50 chars")]
        public string storeName { get; set; }
        [Display (Name = "Location")]
		[Required(ErrorMessage = "Location is required")]
		public string Location { get; set; }
        [Display (Name = "Open Hour")]
		[Required(ErrorMessage = "Open hour is required")]
		public string openHour { get; set; }
		[Display(Name = "Close Hour")]
		[Required(ErrorMessage = "Close hour is required")]
		public string closeHour { get; set; }
        [Display (Name = "Logo Picture URL")]
		[Required(ErrorMessage = "Profile picture is required")]
		public string PictureURL { get; set; }

        //Relationships
        public List<StoresArticles> storeArticles { get; set; }
        public List<Article> Articles { get; set; }
        public List<Employee> employees { get; set; }
    }
}
