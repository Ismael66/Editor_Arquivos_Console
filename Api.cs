using System;
using Newtonsoft.Json;

namespace apiTest
{
    class Api
    {
        static void Chama(string cep)
        {
            try
            {
                Rodar(cep);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async void Rodar(string cep)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var resultado = await cliente.GetStringAsync("https://viacep.com.br/ws/"+ cep +"/json/");
                dynamic dobj = JsonConvert.DeserializeObject<dynamic>(resultado);
                setFieldValue(dobj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void setFieldValue(dynamic campo)
        {
            Console.WriteLine(campo["cep"].ToString());
            Console.WriteLine(campo["bairro"].ToString());
        }
    }
}