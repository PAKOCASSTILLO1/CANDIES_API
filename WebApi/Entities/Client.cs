using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class Client
    {
        [JsonIgnore]
        private DataContext _context;
        public Client()
        {
            this.state = true;
        }

        public void update(ClientDto dto, DataContext context)
        {
            _context = context;
            this.name = dto.name;
            this.address = dto.address;
            this.coordinate = dto.coordinate;
            this.nit = dto.nit;
            this.wholesaler = dto.wholesaler;
            this.email = dto.email;
            this.idPerson = dto.idPerson;
            this.urlPage = dto.urlPage;
            this.person = _context.Person.Find(dto.idPerson);
        }

        public void auditInsert(String id){
            int user = Int32.Parse(id);
            this.Usuario_Creo = user;
            this.Fecha_Creo = DateTime.Now;
        }

        public void auditUpdate(String id){
            int user = Int32.Parse(id);
            this.Usuario_Modifico = user;
            this.Fecha_Modifico = DateTime.Now;
        }

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

        // Autoria
        public int Usuario_Creo {get; set;}
        public DateTime Fecha_Creo {get;set;}
        public int? Usuario_Modifico {get;set;}
        public DateTime? Fecha_Modifico {get;set;}

    }
}