using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnlaine.ConsoleApp
{
    class Program
    {
        private static void LeilaoComVariosLances()
        {
            //Arranjo - cenário de entrada
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            Console.WriteLine(leilao.Ganhador.Valor);

            
        }

        private static void LeilaoApenasComUmLance()
        {
            //Arranjo - cenário de entrada
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);
            var fulano = new Interessada("Fulano", leilao);
          

            leilao.RecebeLance(fulano, 800);

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            Console.WriteLine(leilao.Ganhador.Valor);

        }
        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoApenasComUmLance();
        }
    }
}
