using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace Criador
{
    class Program
    {
        static string arquivoEscolhido = @"\teste.txt";
        static string path = Directory.GetCurrentDirectory();
        public static void Main()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("Menu Principal");
                Console.WriteLine("=====================================================================");
                Console.WriteLine("[1] CRIAR ARQUIVO");
                Console.WriteLine("[2] INSERIR DADOS");
                Console.WriteLine("[3] VISUALIZAR ARQUIVO");
                Console.WriteLine("[4] MUDAR ARQUIVO");
                Console.WriteLine("=====================================================================");
                Console.Write("Escolha: ");
                int escolha = int.Parse(Console.ReadLine());
                Acao(escolha);
            }
            catch (System.Exception)
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("Escolha uma opção valida.");
                Console.WriteLine("=====================================================================");
                System.Threading.Thread.Sleep(1000);
                Main();
            }
        }
        public static void Acao(int escolha)
        {
            try
            {
                switch (escolha)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("=====================================================================");
                        Console.Write("ESCOLHA O TITULO DO ARQUIVO: ");
                        arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
                        if (File.Exists(path + arquivoEscolhido))
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
                            StreamWriter arquivo = new StreamWriter(path + arquivoEscolhido, true); // cria ou abre
                            arquivo.Close();
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
                        StreamWriter valor = new StreamWriter(path + arquivoEscolhido, true); // abre ou cria
                        Console.WriteLine("=====================================================================");
                        Console.Write("DIGITE ALGO: ");
                        valor.WriteLine(Console.ReadLine());
                        valor.Close();
                        Console.Clear();
                        Console.WriteLine("=====================================================================");
                        Console.WriteLine("Deseja escrever algo mais? <s/n>");
                        if (Console.ReadLine() == "s")
                            Acao(2);
                        else
                            Main();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("=====================================================================");
                        string text = System.IO.File.ReadAllText(path + arquivoEscolhido);
                        Console.Write(text);
                        Console.WriteLine("=====================================================================");
                        Console.WriteLine("Retornar? <s/n>");
                        if (Console.ReadLine() == "s")
                            Main();    
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("=====================================================================");
                        Console.Write("Digite o nome do arquivo: ");
                        arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
                        if (File.Exists(path + arquivoEscolhido))
                            Main();
                        else
                            Console.Clear();
                        arquivoEscolhido = @"\Teste.txt";
                        Console.WriteLine("=====================================================================");
                        Console.WriteLine("O arquivo não existe, deseja criá-lo? <s/n>");
                        if (Console.ReadLine() == "s")
                            Acao(1);
                        else
                            Main();
                        break;
                }
            }
            catch (System.Exception)
            {
                Console.Clear();
                Console.WriteLine("=====================================================================");
                Console.WriteLine("Escolha uma opção valida.");
                Console.WriteLine("=====================================================================");
                System.Threading.Thread.Sleep(1000);
                Main();
            }

        }
    }
}
