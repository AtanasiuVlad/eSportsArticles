using System.ComponentModel.DataAnnotations;

namespace eSportsArticles.Models
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        [Display (Name = "Store Name")]
        public string storeName { get; set; }
        [Display (Name = "Location")]
        public string Location { get; set; }
        [Display (Name = "Open Hour")]
        public string openHour { get; set; }
		[Display(Name = "Close Hour")]
		public string closeHour { get; set; }
        [Display (Name = "Logo Picture URL")]
        public string PictureURL { get; set; }

        //Relationships
        public List<StoresArticles> storeArticles { get; set; }
        public List<Employee> employees { get; set; }
    }
}
