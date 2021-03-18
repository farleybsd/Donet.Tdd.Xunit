using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnlaine.Tests
{
   public class LeilaoTerminaPregao
    {
        //NomedoMetodo.CenarioPassado.RespostaEsperada
        [Theory] //Teoria teste que sao verdades para um tipo particular de dado
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })] // Passando Dado
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })] // Passando Dado
        [InlineData(800, new double[] { 800})] // Passando Dados
        public  void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valoresperado,double[] ofertas)
        {
            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
               
            }

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);


        }

        [Fact] // Fato sao sempre teste verdades que testa condiçoes e variantes
        public void RetornaZeroDadoLeilaoSemLance()
        {

            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valoresperado = 0;
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);
        }
    }
}
