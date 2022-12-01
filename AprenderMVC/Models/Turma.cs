using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AprenderMVC.Models
{
    [Table("Turma")]
    public partial class Turma
    {
        [Key]
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public int IdPessoa { get; set; }
        [DataType(DataType.Date)]
        public DateTime DtInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime DtFim { get; set; }

        public string  IdeStatus { get; set; }

        [ForeignKey("IdPessoa")]
        [NotMapped]
        [DisplayName("Instrutor")]
        public Pessoa Pessoa { get; set; }

        [ForeignKey("IdCurso")]
        [NotMapped]
        public Curso Curso { get; set; }

        
    }
}
