using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnlaine.Tests
{
   public class LeilaoTestes
    {
        [Fact] //Fato
        public void LeilaoComTresClientes()
        {
            //Arranjo - cenário de entrada
           //Dado Leilao com 3 clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("beltrano",leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(beltrano, 1400);

            // Act - método sobre teste
           //  Quando o pegrão/Leilão termima
            leilao.TerminaPregao();

            //Assert resultado esperado
           //Então o valor esperado é o maior valor dado
          //E o cliente ganhador é o que deu o maior lance
            var valoresperado = 1400;
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);
            Assert.Equal(beltrano,leilao.Ganhador.Cliente);
        }

        [Fact] // Fato
        public void LeilaoComLanceOrdenadasPorValor()
        {
            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valoresperado = 1000;
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);
        }

        [Fact] // FATO
        public  void LeilaoComVariosLances()
        {
            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(fulano, 1000);
            

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valoresperado = 1000;
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);


        }

        [Fact] // FATO
        public void LeilaoApenasComUmLance()
        {
            //Arranjo - cenário de entrada
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);


            leilao.RecebeLance(fulano, 800);

            // Act - método sobre teste
            leilao.TerminaPregao();

            //Assert resultado esperado
            var valoresperado = 800;
            var valorObtifo = leilao.Ganhador.Valor;
            Assert.Equal(valoresperado, valorObtifo);

        }
    }
}
