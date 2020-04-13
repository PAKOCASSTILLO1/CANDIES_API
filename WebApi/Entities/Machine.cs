using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApi.Entities
{
    public class Machine
    {
        [Key]
        public int idMachine {get;set;}

        [ForeignKey("statusMachine")]
        public int idStatusMachine {get;set;}
        public int capacity {get;set;}

        [JsonIgnore]
        public StatusMachine statusMachine {get;set;}
    }
}