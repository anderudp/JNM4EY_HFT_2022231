using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNM4EY_HFT_2022231.Models
{
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgendaId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<AgendaUser> AgendaUsers { get; set; } = new HashSet<AgendaUser>();
        public virtual ICollection<Todo> Todos { get; set; } = new HashSet<Todo>();
    }
}
