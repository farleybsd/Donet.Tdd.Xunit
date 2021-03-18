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
        [Fact] // Fatos sem depender de valores de entrada
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {


            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(fulano, 900);
            leilao.TerminaPregao();

            // Act - método sobre teste
            leilao.RecebeLance(fulano, 1000);

            //Assert resultado esperado
            var valoresperado = 2;
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

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);

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
