using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class StatusMachine
    {
        public void update(StatusMachineDto dto)
        {
            this.description = dto.description;
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
        public int idStatusMachine {get;set;}

        [StringLength (50)]
        public string description {get;set;}

        // Autoria
        public int Usuario_Creo {get; set;}
        public DateTime Fecha_Creo {get;set;}
        public int? Usuario_Modifico {get;set;}
        public DateTime? Fecha_Modifico {get;set;}
    }
}