using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace ConsoleMenu
{
    public class Visor
    {
        static string? arquivoEscolhido;
        static string path = Directory.GetCurrentDirectory();
        public static void Opcoes()
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
                Console.WriteLine(2);
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
                    case "5":
                        insereCep();
                        break;
                    default:
                        retornarMenu("Escolha uma opção valida.", true);
                        Opcoes();
                        break;
                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(1);
                throw new Exception(ex.Message);
            }
        }
        #region Funções Switch
        static void insereCep()
        {
            Console.WriteLine("Como deseja inserir informações ao arquivo?");
            criaLinha();
            Console.WriteLine("[1] Digitar Cep\n" +
           "[2] Cep aleatório");
            criaLinha();
            Console.Write("Digite a opção desejada: ");
            string? escolha = Console.ReadLine();
            Console.Clear();
            criaLinha();
            switch (escolha)
            {
                case "1":
                    Console.Write("Digite o Cep: ");
                    string? cep = Console.ReadLine();
                    if (cep != string.Empty && cep.Length == 8)
                    {
                        ApiViaCEP.ApiViaCEP.Chama(cep);
                    }
                    break;
                case "2":
                    break;
                default:
                    break;
            }

        }
        static void criaArquivo()
        {
            Console.Write("Digite um nome para o arquivo: ");
            arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
            if (File.Exists(path + arquivoEscolhido))
            {
                retornarMenu("Já existe um arquivo come este nome.", true);
                Opcoes();
            }
            else
            {
                var arquivo = new StreamWriter(path + arquivoEscolhido, true); // cria ou abre
                arquivo.Close();
                retornarMenu("Arquivo criado com sucesso.", true);
                Opcoes();
            }
        }
        static void insereDados()
        {
            var valor = new StreamWriter(path + arquivoEscolhido, true); // abre ou cria
            Console.Write("Digite um Cep: ");
            // var cep = new ApiViaCEP();
            // cep.Chama(Console.ReadLine());
            valor.WriteLine();
            valor.Close();
            if (retornarMenu("Deseja escrever novamente? <s/n>"))
                Acao("2");
            else
                Opcoes();
        }
        static void visualizaArquivo()
        {
            if (arquivoEscolhido != null)
            {
                string text = System.IO.File.ReadAllText(path + arquivoEscolhido);
                Console.Write(text);
                if (retornarMenu("Retornar? <s/n>"))
                    Opcoes();
            }
            else
            {
                if (retornarMenu("Nenhum arquivo selecioinado.", true))
                    Console.Write("text");
                else
                {
                    Opcoes();
                }
            }
        }
        static void alteraArquivo()
        {
            Console.Write("Digite o nome do arquivo: ");
            arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
            if (File.Exists(path + arquivoEscolhido))
                Opcoes();
            else
                Console.Clear();
            arquivoEscolhido = @"\Teste.txt";
            if (retornarMenu("O arquivo não existe, deseja criá-lo? <s/n>"))
                Acao("1");
            else
                Opcoes();
        }
        #endregion
        #region Funções Comuns
        public static void criaLinha(int repeticoes = 24, char simbolo = '=')
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
        public static bool retornarMenu(string msg = "Ok", bool read = false)
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
