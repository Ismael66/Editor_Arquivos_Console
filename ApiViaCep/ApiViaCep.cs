using System;
using Newtonsoft.Json;
// using System.Linq

namespace ConsoleMenu.ApiViaCEP
{
    public class ApiViaCEP
    {
        public static void Chama(string cep)
        {
            try
            {
                Rodar(cep);
                System.Threading.Thread.Sleep(3000);
                Console.ReadLine();
                // Visor.retornarMenu("", true);
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
                ViaCep resultadojson = JsonConvert.DeserializeObject<ViaCep>(resultado);
                mensagemConsole();
                imprimeElementos(resultadojson, Console.ReadLine());
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
            "[9] Siafi");
            Visor.criaLinha();
            Console.WriteLine("Quais informações deseja resgatar?");
        }
        public static void imprimeElementos(ViaCep campo, string validador = "0")
        {
            Console.Clear();
            Visor.criaLinha();
            Console.WriteLine($"Cep: {campo.Cep}");
            Visor.criaLinha();
            if (validador.Contains('1')) Console.WriteLine($"Logradouro: {campo.Logradouro}");
            if (validador.Contains('2')) Console.WriteLine($"Complemento: {campo.Complemento}");
            if (validador.Contains('3')) Console.WriteLine($"Bairro: {campo.Bairro}");
            if (validador.Contains('4')) Console.WriteLine($"Localidade: {campo.Localidade}");
            if (validador.Contains('5')) Console.WriteLine($"UF: {campo.UF}");
            if (validador.Contains('6')) Console.WriteLine($"IBGE: {campo.IBGE}");
            if (validador.Contains('7')) Console.WriteLine($"GIA: {campo.GIA}");
            if (validador.Contains('8')) Console.WriteLine($"DDD: {campo.DDD}");
            if (validador.Contains('9')) Console.WriteLine($"Siafi: {campo.Siafi}");
        }
    }
}