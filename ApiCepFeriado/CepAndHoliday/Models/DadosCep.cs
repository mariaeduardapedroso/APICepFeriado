using System;

namespace Dados
{
    public partial class DadosCep
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public void imprimirDados()
        {
            Console.WriteLine($"Dados do CEP {this.Cep}");
            Console.WriteLine($"Logradouro: {this.Logradouro}");
            Console.WriteLine($"Complemento: {this.Complemento}");
            Console.WriteLine($"Bairro: {this.Bairro}");
            Console.WriteLine($"Localidade: {this.Localidade}");
            Console.WriteLine($"UF: {this.Uf}");
            Console.WriteLine($"IBGE: {this.Ibge}");
            Console.WriteLine($"GIA: {this.Gia}");
            Console.WriteLine($"DDD: {this.Ddd}");
            Console.WriteLine($"Siafi: {this.Siafi}");
        }
    }
}

