using System;

namespace Dados
{
    public partial class Holiday
    {
        public bool feriado { get; set; }
        public Holiday(bool resultado)
        {
            this.feriado = resultado;
        }
        public Holiday SetFeriadoTrue()
        {
            this.feriado = true;
            return this;
        }
    }
}