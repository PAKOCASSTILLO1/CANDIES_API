using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class Client
    {
        [Key]
        public int idClient {get;set;}

        [StringLength (50)]
        public string name {get;set;}

        [StringLength (200)]
        public string address {get;set;}

        [StringLength (200)]
        public string coordinate {get; set;}

        [StringLength (10)]
        public string nit {get; set;}
        public bool wholesaler {get;set;}

        [StringLength (100)]
        [EmailAddress]
        public string email {get; set;}

        [ForeignKey("person")]
        public int idPerson {get;set;}

        [Url]
        [StringLength (500)]
        public string urlPage {get;set;}
        public bool state {get;set;}

        [JsonIgnore]
        public Person person {get;set;}

    }
}