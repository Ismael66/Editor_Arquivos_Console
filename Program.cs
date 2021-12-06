using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace ConsoleMenu
{
    class Program
    {
        static string arquivoEscolhido = @"\teste.txt";
        static string path = Directory.GetCurrentDirectory();
        public static void Main()
        {
           Visor.Opcoes();
        }
    }
}
