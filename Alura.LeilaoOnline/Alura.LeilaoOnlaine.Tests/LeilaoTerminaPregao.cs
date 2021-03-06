using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnlaine.Tests
{
   public class LeilaoTerminaPregao
    {
        [Theory] //Teoria teste que sao verdades para um tipo particular de dado
        [InlineData(1200,1250, new double[] { 800, 1150, 1400, 1250 })] // Passando Dado
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(
          double valorDestino,
          double valoresperado, 
          double[] ofertas)
        {
            //Arranjo - cenário de entrada
            IModalidadeAvaliacao  modalidade = new OfertaSuperiorMaisProxima(valorDestino);
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];

                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            
            Assert.Equal(valoresperado, leilao.Ganhador.Valor);
        }

        //NomedoMetodo.CenarioPassado.RespostaEsperada
        [Theory] //Teoria teste que sao verdades para um tipo particular de dado
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })] // Passando Dado
        [InlineData(1200, new double[] { 800, 900, 1200, 990 })] // Passando Dado
        [InlineData(800, new double[] { 800})] // Passando Dados
        public  void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valoresperado,double[] ofertas)
        {
            //Arranjo - cenário de entrada
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];

                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);


        }

        [Fact]
        public void LancaInvalidOperationExceptionDadopregaoNaoIniciado()
        {
            //Arrange - cenário
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);

            //Assert
            var excecaoObtida = Assert.Throws<System.InvalidOperationException>(
                //Act - método sob teste
                () => leilao.TerminaPregao()
            );

            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().";
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }


        [Fact] // Fato sao sempre teste verdades que testa condiçoes e variantes
        public void RetornaZeroDadoLeilaoSemLance()
        {

            //Arranjo - cenário de entrada
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh",modalidade);
            leilao.IniciaPregao();
            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valoresperado = 0;
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);
        }
    }
}
