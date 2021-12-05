using System;
using System.IO;
using System.Text;
using System.Reflection;

namespace Criador.Bisteca
{
    public class Visor
    {
        public static Visor teste;
        public static string arquivoEscolhido = @"\teste.txt";
        public static string path = Directory.GetCurrentDirectory();
        public void Opcoes()
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
                        teste.Opcoes();
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
                teste.Opcoes();
            }
            else
            {
                var arquivo = new StreamWriter(path + arquivoEscolhido, true); // cria ou abre
                arquivo.Close();
                retornarMenu("Arquivo criado com sucesso.", true);
                teste.Opcoes();
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
                teste.Opcoes();
        }
        static void visualizaArquivo()
        {
            string text = System.IO.File.ReadAllText(path + arquivoEscolhido);
            Console.Write(text);
            if (retornarMenu("Retornar? <s/n>"))
                teste.Opcoes();
        }
        static void alteraArquivo()
        {
            Console.Write("Digite o nome do arquivo: ");
            arquivoEscolhido = @$"\{Console.ReadLine()}.txt";
            if (File.Exists(path + arquivoEscolhido))
                teste.Opcoes();
            else
                Console.Clear();
            arquivoEscolhido = @"\Teste.txt";
            if (retornarMenu("O arquivo não existe, deseja criá-lo? <s/n>"))
                Acao("1");
            else
                teste.Opcoes();
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
