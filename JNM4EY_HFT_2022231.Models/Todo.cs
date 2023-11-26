using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JNM4EY_HFT_2022231.Models
{
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TodoId { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public bool? IsImportant { get; set; }
        public bool? IsUrgent { get; set; }
        public int AgendaId { get; set; }
        [JsonIgnore]
        public virtual Agenda Agenda { get; set; }
    }
}
