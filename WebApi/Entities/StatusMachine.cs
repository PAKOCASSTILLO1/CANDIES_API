using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class StatusMachine
    {
        [Key]
        public int idStatusMachine {get;set;}

        [StringLength (50)]
        public string description {get;set;}
    }
}