using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace ConsoleMenu
{
    public class Visor
    {
        static string? arquivoEscolhido;
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                "[4] Alterar arquivo selecionado\n" +
                "[5] Resgatar dados por Cep\n" +
                "[6] Sair do programa");
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
                    case "5":
                        insereCep();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        retornarMenu("Escolha uma opção valida.", true);
                        Opcoes();
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
                Opcoes();
            }
            else
            {
                var arquivo = new StreamWriter(path + arquivoEscolhido, true); // cria ou abre
                arquivo.Close();
                if (!retornarMenu("Arquivo criado com sucesso.", true))
                    Opcoes();
            }
        }
        static void insereDados()
        {
            if (!File.Exists(path + arquivoEscolhido))
            {
                if (retornarMenu("Arquivo não existe. Deseja criar um novo arquivo?<s/n>"))
                    Acao("1");
                else
                {
                    if (retornarMenu("Deseja selecionar um arquivo já criado?<s/n>"))
                        Acao("4");
                    else
                        Opcoes();
                }
            }
            else
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
        }
        static void visualizaArquivo()
        {
            if (File.Exists(path + arquivoEscolhido))
            {
                string text = System.IO.File.ReadAllText(path + arquivoEscolhido);
                Console.Write(text);
                retornarMenu("Arquivo aberto com suceeso", true);
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
        static void insereCep()
        {
            Console.Clear();
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
                    cepDigitado();
                    break;
                case "2":
                    cepAleatorio();
                    break;
                default:
                    criaLinha();
                    if (!retornarMenu("Digite uma opção valida.", true))
                        insereCep();
                    break;
            }
        }
        #endregion
        #region Funções Switch Cep
        static void cepDigitado()
        {
            if (File.Exists(path + arquivoEscolhido))
            {
                var valor = new StreamWriter(path + arquivoEscolhido, append: true);
                Console.Write("Digite o Cep: ");
                string? cep = Console.ReadLine();
                if (cep != string.Empty && cep.Length == 8)
                {
                    ApiViaCEP.ApiViaCEP.Chama(cep, valor);
                }
                else
                {
                    criaLinha();
                    if (!retornarMenu("Cep inválido.", true))
                        insereCep();
                }
            }
            else
            {
                if (retornarMenu("Nenhum arquivo selecionado. Deseja selecionar?<s/n>"))
                    Acao("4");
                else
                    Opcoes();
            }
        }
        static void cepAleatorio()
        {
            if (File.Exists(path + arquivoEscolhido))
            {
                var valor = new StreamWriter(path + arquivoEscolhido, append: true);
                int[] arrayCeps = new int[10] { 58410140, 58400440, 69550061, 85815210, 69313265, 57307004, 64013100,
                    97577470, 64050080, 78058150};
                Random random = new Random();
                int cepAleatorio = arrayCeps[random.Next(arrayCeps.Length)];
                ApiViaCEP.ApiViaCEP.Chama(cepAleatorio.ToString(), valor);
            }
            else
            {
                if (retornarMenu("Nenhum arquivo selecionado. Deseja selecionar?<s/n>"))
                    Acao("4");
                else
                    Opcoes();
            }
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
