using System;
using System.IO;
using System.Text;
using static System.Console;

namespace Workspace_Projetos
{
    //A classe Investidor tem as seguintes propriedades:
    public class Investidor
    {
        public double EurosDepositados { get; set; }
        public int TotalCHOW { get; set; }
        public int TotalDOCE { get; set; }
        public int TotalGALLO { get; set; }
        public int TotalTUGA { get; set; }


        public Investidor()
        {
            EurosDepositados = 0;
            TotalCHOW = 0;
            TotalDOCE = 0;
            TotalGALLO = 0;
            TotalTUGA = 0;
        }

        public void SaveInvestidor()
        {
            //métodos estáticos para gravar um texto em um arquivo; abre e fecha o arquivo automaticamente
            File.WriteAllText("investidor.txt", $"{EurosDepositados};{TotalCHOW};{TotalDOCE};{TotalGALLO};{TotalTUGA}");
        }

        //a conta inicial está a 0 → fazer depósito em €
        public double Depositar()
        {
            double totalDepositar;
                        
            WriteLine($"\r\nSelecione o montante a depositar, em Euros.");
            if (!double.TryParse(ReadLine(), out totalDepositar))
            {
                WriteLine("Por favor insira um valor válido.");
            }

            //this é uma palavra reservada; refª ao próprio objecto → permite saber que se trata de um atributo            
            this.EurosDepositados += totalDepositar;
            SaveInvestidor();

            return totalDepositar;
        }

        public int ComprarMoeda(CryptoAPI simulacao)
        {
            int totalComprar;

            string tipomoedaSelecionada = SubMenus.MenuTipoMoeda();
            if(tipomoedaSelecionada == "") return 0;

            WriteLine($"\r\nSelecione o montante a comprar de {tipomoedaSelecionada}(s).");

            if(!int.TryParse(ReadLine(), out totalComprar))
            {
                WriteLine($"Por favor insira unidades válidas de {tipomoedaSelecionada}(s) a comprar.");
            }

            //TODO
            ////validar se há suficiente numero de moedas no mercado e descontar valores em caixa consoante o preço na simulação
            
            switch (tipomoedaSelecionada)
            {
                 case "CHOW":
                    if(totalComprar > simulacao._mercado.TotalCHOW) 
                    { 
                        WriteLine("Não há CHOW's suficientes"); 
                        return 0;
                    }
                    if(totalComprar * simulacao._mercado.ValorCambioCHOW > this.EurosDepositados) 
                    { 
                        WriteLine($"Não tem valor suficiente para comprar {totalComprar} CHOW's."); 
                        return 0;
                    }
                    
                    this.TotalCHOW += totalComprar;
                    this.EurosDepositados = this.EurosDepositados - (totalComprar * simulacao._mercado.ValorCambioCHOW);
                    simulacao._mercado.TotalCHOW -= totalComprar;                    
                    break;

                case "DOCE":
                    if(totalComprar > simulacao._mercado.TotalDOCE) 
                    { 
                        WriteLine("Não há DOCE's suficientes."); 
                        return 0;
                    }
                    if(totalComprar * simulacao._mercado.ValorCambioDOCE > this.EurosDepositados) 
                    { 
                        WriteLine($"Não tem valor suficiente para comprar {totalComprar} DOCE's."); 
                        return 0;
                    }
                    
                    this.TotalDOCE += totalComprar;
                    this.EurosDepositados -= totalComprar * simulacao._mercado.ValorCambioDOCE;
                    simulacao._mercado.TotalDOCE -= totalComprar;                    
                    break;

                case "GALLO":
                    if(totalComprar > simulacao._mercado.TotalGALLO)
                    { 
                        WriteLine("Não há GALLO's suficientes."); 
                        return 0;
                    }
                    if(totalComprar * simulacao._mercado.ValorCambioGALLO > this.EurosDepositados) 
                    { 
                        WriteLine($"Não tem valor suficiente para comprar {totalComprar} GALLO's."); 
                        return 0;
                    }
                                        
                    this.TotalGALLO += totalComprar;
                    this.EurosDepositados -= totalComprar * simulacao._mercado.ValorCambioGALLO;
                    simulacao._mercado.TotalGALLO -= totalComprar;                    
                    break;

                case "TUGA":
                    if(totalComprar > simulacao._mercado.TotalTUGA)
                    { 
                        WriteLine("Não há TUGA's suficientes"); 
                        return 0;
                    }
                    if(totalComprar * simulacao._mercado.ValorCambioTUGA > this.EurosDepositados) 
                    { 
                        WriteLine($"Não tem valor suficiente para comprar {totalComprar} TUGA's."); 
                        return 0;
                    }
                    
                    this.TotalTUGA += totalComprar;
                    this.EurosDepositados -= totalComprar * simulacao._mercado.ValorCambioTUGA;
                    simulacao._mercado.TotalTUGA -= totalComprar;                    
                    break;
            }

            SaveInvestidor();
            return totalComprar;
        }
                
    }
}