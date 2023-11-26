using JNM4EY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class AgendaUser
    {
        public int AgendaId { get; set; }
        [JsonIgnore]
        public virtual Agenda Agenda { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
