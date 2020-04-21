using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using WebApi.Helpers;

namespace WebApi.Entities
{
    public class PurchaseDetail
    {
        [JsonIgnore]
        private DataContext _context;

        public void update(PurchaseDetailDto dto, DataContext context)
        {
            _context = context;
            this.idProduct = dto.idProduct;
            this.idPurchaseOrder = dto.idPurchaseOrder;
            this.product = _context.Product.Find(dto.idProduct);
            this.purchaseOrderFK = _context.PurchaseOrder.Find(dto.idPurchaseOrder);
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
        public int idPurchaseDetail {get;set;}

        [ForeignKey("product")]
        public int idProduct {get;set;}

        [ForeignKey("purchaseOrder")]
        public int? idPurchaseOrder {get;set;}

        [JsonIgnore]
        public Product product {get;set;}

        [JsonIgnore]
        public PurchaseOrder purchaseOrderFK {get;set;}

        // Autoria
        public int Usuario_Creo {get; set;}
        public DateTime Fecha_Creo {get;set;}
        public int? Usuario_Modifico {get;set;}
        public DateTime? Fecha_Modifico {get;set;}
    }
}