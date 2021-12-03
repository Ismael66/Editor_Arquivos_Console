using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace Criador
{
    class Program
    {
        static string arquivoEscolhido = @"\Teste.txt";
        public static void Main()
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Menu Principal");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("[1] CRIAR ARQUIVO");
            Console.WriteLine("[2] INSERIR DADOS");
            Console.WriteLine("[3] MUDAR ARQUIVO");
            Console.WriteLine("=====================================================================");
            Console.Write("Escolha: ");
            int escolha = int.Parse(Console.ReadLine());
            Acao(escolha);
        }
        public static void Acao(int escolha)
        {

            switch (escolha)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=====================================================================");
                    Console.Write("ESCOLHA O TITULO DO ARQUIVO: ");
                    string titulo = Console.ReadLine();
                    arquivoEscolhido = @$"\{titulo}.txt";
                    var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + arquivoEscolhido;
                    if (File.Exists(path))
                    {
                        Console.Clear();
                        Console.WriteLine("=====================================================================");
                        Console.WriteLine("JÁ EXISTE UM ARQUIVO COM O MESMO NOME.");
                        Console.WriteLine("=====================================================================");
                        System.Threading.Thread.Sleep(1000);
                        Main();
                    }
                    else
                    {
                        FileStream fs = File.Create(path);
                        Console.Clear();
                        Console.WriteLine("=====================================================================");
                        Console.WriteLine("ARQUIVO CRIADO.");
                        Console.WriteLine("=====================================================================");
                        System.Threading.Thread.Sleep(1000);
                        Main();
                    }
                    break;
                case 2:
                    Console.Clear();
                    var path2 = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + arquivoEscolhido;
                    StreamWriter valor = new StreamWriter(path2, true); // abre
                    Console.WriteLine("=====================================================================");
                    Console.Write("DIGITE ALGO: ");
                    valor.Write(Console.ReadLine());
                    valor.Close();
                    string text = System.IO.File.ReadAllText(path2);
                    Console.WriteLine(text);
                    break;
                case 3:
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }
    }
}
