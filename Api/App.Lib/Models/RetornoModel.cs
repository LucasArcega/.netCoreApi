using System;
using System.Collections.Generic;
using System.Text;

namespace App.Lib.Models
{
    public class RetornoModel<T> : RetornoModel
    {
        public T Retorno { get; set; }
    }

    public class RetornoModel<T, TExecao> : RetornoModel<T>
    {
        public TExecao Tipo { get; set; }
    }

    public class RetornoModel
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public List<string> TempoExecucao { get; set; }
        public DateTime? ValidadeSessaoUsuario { get; set; }
        public DateTime? ExpiracaoBloqueio { get; set; }
    }
}
