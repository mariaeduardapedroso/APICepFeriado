using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using DesafioFeriado;
using Dados;

namespace apiCepEFeriado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIDataController : ControllerBase
    {

        [HttpGet(Name = "Getdata")]//serve pra nada so nomear função
        public async Task<Holiday> GetAsync(string Data)
        {
            var TesteDataFormato = "[0-9]{2}[/][0-9]{2}[/][0-9]{4}";

            Match resultado1 = Regex.Match(Data, TesteDataFormato);

            var feriado = new Holiday(false);

            if (resultado1.Success == false)
            {
                return feriado;
            }

            var DataAdquirida = new VerSeADataEFeriado(Data);

            if (DataAdquirida.CompararSeEFeriadoFixo() || DataAdquirida.CompararSeEFeriadoNaoFixo())
            {
                return feriado.SetFeriadoTrue();
            }

            return feriado;
        }
    }
}