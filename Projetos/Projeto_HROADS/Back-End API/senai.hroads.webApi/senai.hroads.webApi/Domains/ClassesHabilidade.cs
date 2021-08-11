using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Domains
{
    [Table("ClassesHabilidade")]
    public class ClassesHabilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idClasseHabilidade { get; set; }

        public int idClasse { get; set; }
        public int idHabilidade { get; set; }

        [ForeignKey("idClasse")]
        public Classe classe { get; set; }

        [ForeignKey("idHabilidade")]
        public Habilidade habilidade { get; set; }

        public List<Classe> ListaClasses { get; set; }
        public List<Habilidade> ListaHabilidades { get; set; }
    }
}
