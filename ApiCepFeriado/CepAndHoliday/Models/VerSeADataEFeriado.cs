using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DesafioFeriado
{
    internal class VerSeADataEFeriado
    {
        private string diaAdquirido { get; set; }
        private string mesAdquirido { get; set; }
        private string anoAdquirido { get; set; }

        //public bool feriado;
        public VerSeADataEFeriado(string DataAdquiridaString)
        {
            string[] DiaMesAnoSeparado = DataAdquiridaString.Split('/');

            this.diaAdquirido = DiaMesAnoSeparado[0];
            this.mesAdquirido = DiaMesAnoSeparado[1];
            this.anoAdquirido = DiaMesAnoSeparado[2];
        }

        public bool CompararSeEFeriadoFixo()
        {
            var FeriadosFixos = "-01/01-21/04-01/05-07/09-12/10-02/11-15/11-25/12-";
            /*
            * Confraternização Universal:	1 janeiro
            * Tiradentes	21 abril
            * Dia do trabalho	1 de maio
            * Independencia	7 setembro
            * Nossa senhora	12 outubro
            * Finados	2 novembro
            * Proclamação	15 novembro
            * Natal	25 dezembro
            */
            string DiaMes = string.Format("-{0}/{1}-", this.diaAdquirido, this.mesAdquirido);

            Match compararFeriadoFixo = Regex.Match(FeriadosFixos, DiaMes);
            if (compararFeriadoFixo.Success)//todo retornar sucess
            {
                return true;
            }
            return false;
        }

        public bool CompararSeEFeriadoNaoFixo()
        {
            int diaAdquiridoNumero = Int32.Parse(this.diaAdquirido);
            int mesAdquiridoNumero = Int32.Parse(this.mesAdquirido);
            int anoAdquiridoNumero = Int32.Parse(this.anoAdquirido);


            var DataAdquiridaDate = new DateTime(anoAdquiridoNumero, mesAdquiridoNumero, diaAdquiridoNumero);


            DateTime diaPascoa = DiaQueEPascoa(anoAdquiridoNumero);



            if (DataAdquiridaDate == diaPascoa || DataAdquiridaDate == diaPascoa.AddDays(60) || DataAdquiridaDate == diaPascoa.AddDays(-48)
                || DataAdquiridaDate == diaPascoa.AddDays(-2) || DataAdquiridaDate == diaPascoa.AddDays(-46))
            /*
             * diaPascoa.AddDays(60) -> Corpus Christ
             * diaPascoa.AddDays(-48) -> Carnaval
             * diaPascoa.AddDays(-2) -> Sexta Santa
             * diaPascoa.AddDays(-46) -> Quarta Feira de Cinzas
             */
            {//if complexo
                return true;
            }

            return false;
        }


        internal static DateTime DiaQueEPascoa(int ano)
        {
            int dia = 0;
            int mes = 0;

            int posicaoDentroDoCicloLunar = ano % 19;

            int seculo = ano / 100;

            int NumeroDeDiasEntreEquinócioPróximaLuaCheia = (seculo - (int)(seculo / 4) - (int)((8 * seculo + 13) / 25) +
                19 * posicaoDentroDoCicloLunar + 15) % 30;

            int NumeroDeDiasEntreLuaCheiaAposEquinócioPrimeiroDomingoAposLuaCheia = NumeroDeDiasEntreEquinócioPróximaLuaCheia -
                (int)(NumeroDeDiasEntreEquinócioPróximaLuaCheia / 28) * (1 - (int)(NumeroDeDiasEntreEquinócioPróximaLuaCheia / 28) *
                (int)(29 / (NumeroDeDiasEntreEquinócioPróximaLuaCheia + 1)) * (int)((21 - posicaoDentroDoCicloLunar) / 11));

            dia = NumeroDeDiasEntreLuaCheiaAposEquinócioPrimeiroDomingoAposLuaCheia - ((ano + (int)(ano / 4) +
                NumeroDeDiasEntreLuaCheiaAposEquinócioPrimeiroDomingoAposLuaCheia + 2 - seculo + (int)(seculo / 4)) % 7) + 28;
            mes = 3;

            if (dia > 31)
            {
                mes++;
                dia -= 31;
            }

            return new DateTime(ano, mes, dia);
        }
    }


}




