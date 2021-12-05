using System;
using System.IO;
using System.Text;
using System.Reflection;
using Criador.Bisteca;

namespace Criador
{
    class Program
    {
        static string arquivoEscolhido = @"\teste.txt";
        static string path = Directory.GetCurrentDirectory();
        public static void Main()
        {
            var visor = new Visor();
            visor.Opcoes();
        }
    }
}
