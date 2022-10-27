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
    public class APICepController : ControllerBase
    {
        [HttpGet(Name = "Getenderecoedata")]//serve pra nada so nomear função
        public async Task<DadosCep> GetAsync(string Cep)
        {
            var comparar = "[0-9]{8}";

            Match resultado = Regex.Match(Cep, comparar);

            if (resultado.Success)
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://viacep.com.br/ws/") };//endereço base que vamos acessar
                                                                                                          //await == espera o aguardavel
                                                                                                          //DeserializeObject == QUEBRAR JSON
                                                                                                          //SerializeObject == TRASFORMAR JSON EM TEXTO
                var dados= await client.GetFromJsonAsync<DadosCep>($"{Cep}/json/");//acessar a api na rota do endereço web TODO:JUNTAR NA NA URI MAIS FACIL DEBUGAR
               // var content = await response.Content.ReadAsStringAsync();//retornar os dados da api em texto de forma assincrona 
              //  var dados = JsonConvert.DeserializeObject<DadosCep>(content);//transformar os dados da api em object

                return dados;
            }
            return new DadosCep();

        }
    }
}