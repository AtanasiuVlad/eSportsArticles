using eSportsArticles.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eSportsArticles.Models
{
    public class StoresArticles
    {

        //Store
        public Guid storeId { get; set; }

        [ForeignKey("storeId")]
        public Store Store { get; set; }

        //Article
        public Guid articleId { get; set; }

        [ForeignKey("articleId")]
        public Article Article { get; set; }
    }
}
