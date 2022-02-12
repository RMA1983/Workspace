using System;
using System.IO;
using System.Text;
using System.Threading;
using static System.Console;

namespace Workspace_Projetos
{
    public static class SubMenus
    {
        #region MenuInvestidor()
        public static bool MenuInvestidor(Investidor investidor, CryptoAPI simulacao)
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("MENU INVESTIDOR:");
            WriteLine("");
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("1. Depositar.");
            WriteLine("2. Comprar Moeda.");
            WriteLine("3. Vender Moeda.");
            WriteLine("4. Mostrar Portfolio.");
            WriteLine("5. Mostrar Cambio.");
            WriteLine("6. Sair.");
            Write("\r\nSelecione uma opção: ");

            switch (ReadLine())
            {
                case "1":
                    double totalDepositado = investidor.Depositar();

                    OutputEncoding = Encoding.UTF8; //Mostra símbolo €
                    WriteLine($"Depositou {totalDepositado}€.\nTem agora: {investidor.EurosDepositados}€");
                    
                    Thread.Sleep(5000);
                    return true;

                case "2":
                    double totalComprado = investidor.ComprarMoeda(simulacao);

                    WriteLine($"Comprou {totalComprado}.\nTem agora: {investidor.EurosDepositados}");

                    Console.WriteLine($"Comprou {totalComprado}.\nTem agora: {investidor.EurosDepositados}");
                                        
                    Thread.Sleep(5000);
                    return true;

                case "3":           
                                        
                    Console.WriteLine($"Vendeu .\nTem agora: {investidor.EurosDepositados}");

                    Thread.Sleep(5000);
                    return true;

                case "4":
                    Clear();
                    //O portfólio representa os vários ativos do investidor.
                    //(Arredondar sempre a duas casas decimais e apresentar as colunas alinhadas)
                    //Exemplo:
                    //100 EUR @ 1.00 | 100.00 EUR
                    //99 CHOW @ 1.20 | 118.80 EUR
                    WriteLine("Opção selecionada 4");
                    return true;

                case "5":
                    Clear();
                    //A opção de visualização do câmbio mostra todas as moedas registadas seguidas do câmbio atual.
                    //Exemplo:
                    //CHOW 0.95
                    //DOCE 1.23
                    //GALO 2.03
                    //TUGA 1.15
                    WriteLine("Opção selecionada 5");
                    return true;

                case "6":
                    //Ao sair, deverá persistir a informação dos investidores num ficheiro, para que esta seja também               carregada automaticamente quando reiniciar o programa.
                    return false;

                default:
                    return true;
            }
        }
        #endregion

        #region MenuAdministrador
        public static bool MenuAdministrador(Administrador administrador, CryptoAPI simulacao)
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("MENU ADMINISTRADOR:");
            WriteLine("");
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("1. Adicionar Moeda.");
            WriteLine("2. Remover Moeda.");
            WriteLine("3. Ver Relatório Comissões.");
            WriteLine("4. Sair.");
            Write("\r\nSelecione uma opção: ");

            switch (ReadLine())
            {
                case "1":
                    Clear();
                    simulacao.AddCoin(MenuTipoMoeda());
                    return true;

                case "2":
                    Clear();
                    simulacao.RemoveCoin(MenuTipoMoeda());
                    return true;

                case "3":
                    Clear();
                    administrador.MostraComissoes();
                    return true;

                case "4":
                    return false;

                default:
                    return true;
            }
        }
        #endregion

        #region Moeda MenuTipoMoeda
        public static string MenuTipoMoeda()
        {
            WriteLine("ESCOLHA A MOEDA:\n");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("1. TUGA.");
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("2. CHOW.");
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("3. GALLO.");
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("4. DOCE.");
            ForegroundColor = ConsoleColor.White;
            Write("\r\nSelecione uma opção: ");

            switch (ReadLine())
            {
                case "1":
                    return "TUGA";
                case "2":
                    return "CHOW";
                case "3":
                    return "GALLO";
                case "4":
                    return "DOCE";
                default:
                    WriteLine("Escolha uma opção válida.");
                    return "";
            }
        }
        #endregion
    }
}