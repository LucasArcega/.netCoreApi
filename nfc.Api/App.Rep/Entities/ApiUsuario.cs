using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.Entities
{
    public class ApiUsuario
    {
        public int IdApiUsuario{ get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public int SegundosExpiracaToken { get; set; }

        public string  TipoClient { get; set; }

        public string ChaveBrowser { get; set; }

        public List<APIUsuarioSessao> Sessoes { get; set; }

    }
}
