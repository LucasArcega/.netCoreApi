using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.Entities
{
    public class APIUsuarioSessao
    {
        public int IdUsuarioSessao { get; set; }
        public int IdApiUsuario { get; set; }
        public string Identificador { get; set; }
        public string AutorizacaoHash { get; set; }

        public bool Ativo
        {
            get { return (Inativo == 1 ? false : true); }
            set { Inativo = (!value ? 1 : 0); }
        }
        public int Inativo { get; set; }
        public string DadosSession { get; set; }     
        public DateTime DataExpiracao { get; set; }
        public ApiUsuario APIUsuario { get; set; }

        public string InfoClient { get; set; }
        public string IpAcesso { get; set; }
        public string Usuario { get; set; }
    }
}
