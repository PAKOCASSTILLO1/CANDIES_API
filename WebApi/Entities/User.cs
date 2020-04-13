using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    public class User
    {
        [Key]
        public int idUser { get; set; }

        [StringLength (50)]
        public string name { get; set; }

        [StringLength (50)]
        public string lastName { get; set; }

        [StringLength (15)]
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public byte estado { get; set; }
    }
}