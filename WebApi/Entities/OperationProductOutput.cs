using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class OperationProductOutput
    {
        [JsonIgnore]
        private DataContext _context;
        public OperationProductOutput()
        {
            this.dateOperation = DateTime.Now;
        }

        public void update(OperationProductOutputDto dto, DataContext context)
        {
            _context = context;
            this.idProduct = dto.idProduct;
            this.quantity = dto.quantity;
            this.unitValue = dto.unitValue;
            this.idNotification = dto.idNotification;
            this.product = _context.Product.Find(dto.idProduct);
            this.notification = _context.Notification.Find(dto.idNotification);
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
        public int idOperationOutput {get;set;}
        public DateTime dateOperation {get;set;}

        [ForeignKey("product")]
        public int idProduct {set; get;}

        public int quantity {get;set;}
        public float unitValue {get;set;}

        [ForeignKey("notification")]
        public int idNotification {set; get;}

        [JsonIgnore]
        public Product product {get;set;}

        [JsonIgnore]
        public Notification notification {get;set;}

        // Autoria
        public int Usuario_Creo {get; set;}
        public DateTime Fecha_Creo {get;set;}
        public int? Usuario_Modifico {get;set;}
        public DateTime? Fecha_Modifico {get;set;}
    }
}