using System;
using System.IO;
using System.Text;
using System.Threading;
using static System.Console;

namespace Workspace_Projetos
{
    //esta classe estará sempre pública para que possa ser chamada e usada sempre que precisarmos; assim como será a conexão para todo o restante desenvolvimento das acções pretendidas
    public class CryptoAPI 
    {   
        public Mercado _mercado;

        public CryptoAPI(Mercado mercado)
        {
            _mercado = mercado;
        }

        //Permite adicionar uma nova criptomoeda no sistema da corretora;
        public void AddCoin(string coin)
        {
           switch (coin)
            {
                case "TUGA":
                    _mercado.TotalTUGA += 1;
                    break;
                case "CHOW":
                    _mercado.TotalCHOW += 1;
                    break;
                case "GALLO":
                    _mercado.TotalGALLO += 1;
                    break;
                case "DOCE":
                    _mercado.TotalDOCE += 1;
                    break;
                default:
                    WriteLine("Moeda Inválida");
                    break;
            }
        }

        //devolve lista de todas as moedas geridas pela corretora;
        public string[] GetCoins()
        {
             WriteLine("Implementação em curso!!!!");
             Thread.Sleep(10000);
             return null;
        }

        //Retira criptomoeda do sistema de cotações
        public void RemoveCoin(string coin)
        {
            switch (coin)
            {
                case "TUGA":
                    if(_mercado.TotalTUGA > 0) 
                    {
                        _mercado.TotalTUGA -= 1;
                    }
                    break;

                case "CHOW":
                    if(_mercado.TotalCHOW > 0) 
                    {
                        _mercado.TotalCHOW -= 1;
                    }
                    break;

                case "GALLO":
                    if(_mercado.TotalGALLO > 0) 
                    {
                        _mercado.TotalGALLO -= 1;
                    }
                    break;

                case "DOCE":
                    if(_mercado.TotalDOCE > 0) 
                    {
                        _mercado.TotalDOCE -= 1;
                    }
                    break;

                default:
                    WriteLine("Moeda Inválida");
                    break;
            }
        }

        //Devolve os preços atualizados de todas as moedas registadas;
        public void GetPrices(out decimal[] prices, out string[] coins)
        {
            prices = null;
            coins = null;
            WriteLine("Implementação em curso!!!!");
            Thread.Sleep(10000);
        }

        //Permite definir o intervalo de tempo em segundos que o módulo atualiza a cotação das moedas;
        public void DefinePriceUpdateInSeconds(int seconds)
        {
             WriteLine("Implementação em curso!!!!");
             Thread.Sleep(10000);
        }

        //Permite obter o intervalo de tempo (em segundos) em que o módulo calcula novos preços de cotações;
        public int GetPriceUpdateInSeconds()
        {
            WriteLine("Implementação em curso!!!!");
             Thread.Sleep(10000);
            return default(int);
        }

        //Permite gravar as cotações e moedas geridas, bem como a data do último câmbio. Sempre que o método GetPrices() é chamado, deve ser chamado também o método Save() para assegurar que em caso de falha do sistema, os dados tenham sido persistidos.
        public void Save()
        {
            File.WriteAllText("mercado.txt", $"{_mercado.TotalCHOW};{_mercado.ValorCambioCHOW};{_mercado.TotalDOCE};{_mercado.ValorCambioDOCE};{_mercado.TotalGALLO};{_mercado.ValorCambioGALLO};{_mercado.TotalTUGA};{_mercado.ValorCambioTUGA}");
        }

        //Permite ler as moedas, câmbio e data a que dizem respeito. Sempre que o programa é iniciado, o sistema deverá ver se o ficheiro já existe, e se sim, carregar todos os dados previamente persistidos.
        public void Read()
        {
            string pathFileMercado = "mercado.txt"; //ficheiro txt criado

             if(File.Exists(pathFileMercado))
            {
                string fileContent = File.ReadAllText(pathFileMercado);
                string[] fileContentSplit = fileContent.Split(';');
                int conteudoFicheiroInteiro;
                double conteudoFicheiroDouble;

                if (int.TryParse(fileContentSplit[0], out conteudoFicheiroInteiro)) 
                { 
                    _mercado.TotalCHOW = conteudoFicheiroInteiro;
                }
                if (double.TryParse(fileContentSplit[1], out conteudoFicheiroDouble))
                { 
                    _mercado.ValorCambioCHOW = conteudoFicheiroDouble;
                }
                if (int.TryParse(fileContentSplit[2], out conteudoFicheiroInteiro)) 
                { 
                    _mercado.TotalDOCE = conteudoFicheiroInteiro; 
                }
                if (double.TryParse(fileContentSplit[3], out conteudoFicheiroDouble)) 
                { 
                    _mercado.ValorCambioDOCE = conteudoFicheiroDouble; 
                }
                if (int.TryParse(fileContentSplit[4], out conteudoFicheiroInteiro)) 
                { 
                    _mercado.TotalGALLO = conteudoFicheiroInteiro; 
                }
                if (double.TryParse(fileContentSplit[5], out conteudoFicheiroDouble)) 
                { 
                    _mercado.ValorCambioGALLO = conteudoFicheiroDouble; 
                }
                if (int.TryParse(fileContentSplit[6], out conteudoFicheiroInteiro)) 
                { 
                    _mercado.TotalTUGA = conteudoFicheiroInteiro;
                }
                if (double.TryParse(fileContentSplit[7], out conteudoFicheiroDouble))
                { 
                    _mercado.ValorCambioTUGA = conteudoFicheiroDouble;
                }
                
            }
        }
    }
}