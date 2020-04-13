using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    public class ProductType
    {
        [Key]
        public int idProductType {get;set;}
        
        [StringLength (50)]
        public string description {get;set;}
    }
}