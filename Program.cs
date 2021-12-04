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
                criaLinha();
                Console.WriteLine("Menu Principal");
                criaLinha();
                Console.WriteLine("[1] Criar arquivo\n" +
                "[2] Inserir dados no arquivo\n" +
                "[3] Visualizar arquivo\n" +
                "[4] Alterar arquivo selecionado");
                criaLinha();
                Console.Write("Digite a opção desejada: ");
                Acao(Console.ReadLine());
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static void Acao(string? escolha)
        {
            try
            {
                Console.Clear();
                criaLinha();
                switch (escolha)
                {
                    case "1":
                        criaArquivo();
                        break;
                    case "2":
                        insereDados();
                        break;
                    case "3":
                        visualizaArquivo();
                        break;
                    case "4":
                        alteraArquivo();
                        break;
                    default:
                        retornarMenu("Escolha uma opção valida.", true);
                        Main();
                        break;
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Funções Switch
        static void criaArquivo()
        {
            Console.Write("Digite um nome para o arquivo: ");
            arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
            if (File.Exists(path + arquivoEscolhido))
            {
                retornarMenu("Já existe um arquivo come este nome.", true);
                Main();
            }
            else
            {
                var arquivo = new StreamWriter(path + arquivoEscolhido, true); // cria ou abre
                arquivo.Close();
                retornarMenu("Arquivo criado com sucesso.", true);
                Main();
            }
        }
        static void insereDados()
        {
            var valor = new StreamWriter(path + arquivoEscolhido, true); // abre ou cria
            Console.Write("Digite algo: ");
            valor.WriteLine(Console.ReadLine());
            valor.Close();
            if (retornarMenu("Deseja escrever algo mais? <s/n>"))
                Acao("2");
            else
                Main();
        }
        static void visualizaArquivo()
        {
            string text = System.IO.File.ReadAllText(path + arquivoEscolhido);
            Console.Write(text);
            if (retornarMenu("Retornar? <s/n>"))
                Main();
        }
        static void alteraArquivo()
        {
            Console.Write("Digite o nome do arquivo: ");
            arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
            if (File.Exists(path + arquivoEscolhido))
                Main();
            else
                Console.Clear();
            arquivoEscolhido = @"\Teste.txt";
            if (retornarMenu("O arquivo não existe, deseja criá-lo? <s/n>"))
                Acao("1");
            else
                Main();
        }
        #endregion
        #region Funções Comuns
        static void criaLinha(int repeticoes = 24, char simbolo = '=')
        {
            var store = new StringBuilder(repeticoes);
            int index = 0;
            while (index < repeticoes)
            {
                store.Append(simbolo);
                index++;
            }
            Console.WriteLine(store.ToString());
        }
        static bool retornarMenu(string msg = "Ok", bool read = false)
        {
            criaLinha();
            Console.WriteLine(msg + (read ? "\nPressione qualquer tecla para continuar." : string.Empty));
            if (read)
            {
                Console.ReadKey(); // sem enter
                return false;
            }
            string? resposta = Console.ReadLine();
            Console.Clear();
            if (!string.IsNullOrEmpty(resposta) &&
            resposta.ToLower() == "s")
                return true;
            else
                return false;
        }
    }
    #endregion
}
