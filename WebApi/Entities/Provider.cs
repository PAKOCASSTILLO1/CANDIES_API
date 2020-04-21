using System;
using System.ComponentModel.DataAnnotations;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class Provider
    {
        public Provider()
        {
            this.state = true;
        }

        public void update(ProviderDto dto, DataContext context)
        {
            this.nameProvider = dto.nameProvider;
            this.reason = dto.reason;
            this.nit = dto.nit;
            this.address = dto.address;
            this.email = dto.email;
            this.typeProvider = dto.typeProvider;
            this.state = true;
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
        public int idProvider {get; set;}

        [StringLength (100)]
        public string nameProvider {get; set;}

        [StringLength (200)]
        public string reason {get;set;}
        [StringLength (10)]
        public string nit {get;set;}

        [StringLength (200)]
        public string address {get; set;}

        [EmailAddress]
        [StringLength (100)]
        public string email {get; set;}
        public int typeProvider {get; set;}
        public bool state {get; set;}

        // Autoria
        public int Usuario_Creo {get; set;}
        public DateTime Fecha_Creo {get;set;}
        public int? Usuario_Modifico {get;set;}
        public DateTime? Fecha_Modifico {get;set;}
    }
}