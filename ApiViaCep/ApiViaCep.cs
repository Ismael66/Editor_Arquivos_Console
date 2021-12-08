using System;
using System.Text;
using Newtonsoft.Json;
// using System.Linq

namespace ConsoleMenu.ApiViaCEP
{
    public class ApiViaCEP
    {
        static ViaCep campo;
        public static void Chama()
        {
            try
            {
                System.Threading.Thread.Sleep(3000);
                Console.ReadKey();
                Visor.Opcoes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static async void Rodar(string cep)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var resultado = await cliente.GetStringAsync("https://viacep.com.br/ws/" + cep + "/json/");
                campo = JsonConvert.DeserializeObject<ViaCep>(resultado);
                mensagemConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cep invalido.\n{ex.Message}");
            }
        }
        public static void mensagemConsole()
        {
            Visor.criaLinha();
            Console.WriteLine("Informações do Cep.");
            Visor.criaLinha();
            Console.WriteLine("[1] Logradouro\n" +
            "[2] Complemento\n" +
            "[3] Bairro\n" +
            "[4] Localidade\n" +
            "[5] UF\n" +
            "[6] IBGE\n" +
            "[7] GIA\n" +
            "[8] DDD\n" +
            "[9] Siafi\n" +
            "[0] Todos os dados");
            Visor.criaLinha();
            Console.WriteLine("Quais informações deseja resgatar?");
        }
        public static StringBuilder imprimeElementos(string cep)
        {
            Rodar(cep);
            string? validador = Console.ReadLine();
            StringBuilder mensagem = new StringBuilder();
            mensagem.Append($"=> Cep: {campo.Cep}\n");
            if (validador.Contains('0')) validador = "123456789";
            if (validador.Contains('1')) mensagem.Append($"Logradouro: {campo.Logradouro}\n");
            if (validador.Contains('2')) mensagem.Append($"Complemento: {campo.Complemento}\n");
            if (validador.Contains('3')) mensagem.Append($"Bairro: {campo.Bairro}\n");
            if (validador.Contains('4')) mensagem.Append($"Localidade: {campo.Localidade}\n");
            if (validador.Contains('5')) mensagem.Append($"UF: {campo.UF}\n");
            if (validador.Contains('6')) mensagem.Append($"IBGE: {campo.IBGE}\n");
            if (validador.Contains('7')) mensagem.Append($"GIA: {campo.GIA}\n");
            if (validador.Contains('8')) mensagem.Append($"DDD: {campo.DDD}\n");
            if (validador.Contains('9')) mensagem.Append($"Siafi: {campo.Siafi}\n");
            return mensagem;
        }
    }
}