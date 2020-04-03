using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public byte estado { get; set; }
    }
}