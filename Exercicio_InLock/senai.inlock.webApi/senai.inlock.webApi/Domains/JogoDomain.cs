using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }


        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string descricao { get; set; }


        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime dataLancamento { get; set; }


        [Required(ErrorMessage = "O valor do jogo é obrigatório!")]
        public double valor { get; set; }


        [Required(ErrorMessage = "O id do estúdio é obrigatório!")]
        public int idEstudio { get; set; }

        public EstudioDomain estudio { get; set; }
    }
}
