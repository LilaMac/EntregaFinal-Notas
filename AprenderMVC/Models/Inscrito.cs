using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;




namespace AprenderMVC.Models
{
    [Table("Inscrito")]
    public class Inscrito
    {
        [Key]
        public int Id { get; set; }
        public int IdTurma { get; set; }
        public int IdPessoa { get; set; }
        public int Nota { get; set; }

        public string Resultado { get; set; }

        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }

        [ForeignKey("IdPessoa")]
        [Display(Name = "Aluno")]
        public Pessoa Pessoa { get; set; }

        // 
        public string VerificaAprovacao(int iNota)
        {
            string sRet = "Reprovado";
            if (iNota > 6)
                sRet = "Aprovado";
            return sRet;
        }
    }


}
