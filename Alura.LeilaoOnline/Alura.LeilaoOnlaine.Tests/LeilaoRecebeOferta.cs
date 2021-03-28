using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;
namespace Alura.LeilaoOnlaine.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoOMesmoClienteRealizouOUltimoLance()
        {

            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano,800);
            

            // Act - método sobre teste
            leilao.RecebeLance(fulano, 1000);

            //Assert resultado esperado
            var qtEsperada = 1;
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtEsperada, qtdObtida);
        }

        [Fact] // Fatos sem depender de valores de entrada
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {


            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(fulano, 900);
            leilao.TerminaPregao();

            // Act - método sobre teste
            leilao.RecebeLance(fulano, 1000);

            //Assert resultado esperado
            var valoresperado = 1;
            var valorObtifo = leilao.Lances.Count();
            Assert.Equal(valoresperado, valorObtifo);
        }

        [Theory] // Teoria quando vc precisa de varias entradas para realizar seu teste
        [InlineData(4, new double[] { 1000, 1200,1400,1300 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizadoTheory(int qtEsperada, double[] ofertas)
        {


            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];

                if ((i%2)==0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            
            leilao.TerminaPregao();

            // Act - método sobre teste
            leilao.RecebeLance(fulano, 1000);

            //Assert resultado esperado
            var qtdObtida = leilao.Lances.Count();
            Assert.Equal(qtEsperada, qtdObtida);
        }
    }
}
