using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rep.Models
{
    public class Filtro
    {
        public int Skip { get; set; }

        public int Take { get; set; }

        public string PalavraChave { get; set; }
    }
}
