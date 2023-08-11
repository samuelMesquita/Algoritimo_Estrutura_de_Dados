using System.IO;

namespace AlgoritimoEstruturaDados.Lista_1.Model
{
    public class Vendas
    {

        public Vendas()
        {
            VendasFeitas = new double[QuantidadeMesAno, QuantidadeDiasSemana]
            {
                { 1000.00, 1500.00, 1200.00, 1800.00 },
                { 1600.00, 1300.00, 1700.00, 1400.00 },
                { 1100.00, 1400.00, 1300.00, 1900.00 },
                { 1800.00, 1200.00, 1500.00, 1700.00 },
                { 1700.00, 1600.00, 1800.00, 1400.00 },
                { 1300.00, 1400.00, 1200.00, 1700.00 },
                { 1500.00, 1700.00, 1600.00, 1300.00 },
                { 1900.00, 1200.00, 1400.00, 1500.00 },
                { 1400.00, 1800.00, 1300.00, 1600.00 },
                { 1700.00, 1500.00, 1400.00, 1200.00 },
                { 1200.00, 1600.00, 1800.00, 1300.00 },
                { 1500.00, 1400.00, 1700.00, 1600.00 }
            };
        }
        public Vendas(double[,] VendasFeitas)
        {
            if (VendasFeitas.GetLength(0) != QuantidadeMesAno && VendasFeitas.GetLength(0) != QuantidadeDiasSemana)
                throw new ArgumentException("A matriz repassada esta em formato invalido");

            this.VendasFeitas = VendasFeitas;
        }

        public double[,] VendasFeitas { get; private set; }

        private double[] TotalVendidoMes = new double[QuantidadeMesAno];

        private double TotalVendidoAno = 0;

        private double[] MelhoresVendasSemanaDoAno = new double[4];

        private const int QuantidadeMesAno = 12;

        private const int QuantidadeDiasSemana = 4;

       

        public double[] TotalDeVendasDoMes()
        {
            GetVendasDoMes();

            return TotalVendidoMes;
        }

        public double TotalDeVendasDoAno()
        {
            GetVendasDoAno();

            return TotalVendidoAno; 
        }

        public double SemanaMaisVendasAnos()
        {
            double semanaComMaisVendas = RecuperarMaiorVendaDaSemana();

            return semanaComMaisVendas;
        }

        private void GetVendasDoMes()
        {
            ZerarValoresVendidos();
            double vendasFeitasNoMes = 0;

            for (int i = 0; i < QuantidadeMesAno; i++)
            {
                for (int j = 0; j < QuantidadeDiasSemana; j++)
                {
                    vendasFeitasNoMes += this.VendasFeitas[i, j];

                    this.MelhoresVendasSemanaDoAno[j] += this.VendasFeitas[i, j];
                }

                this.TotalVendidoMes[i] = vendasFeitasNoMes;
            }
        }

        private double RecuperarMaiorVendaDaSemana()
        {
            GetVendasDoMes();
            double semanaComMaisVendas = 0;

            foreach(var melhorVendaSemanaAno in MelhoresVendasSemanaDoAno)
            {
                if(melhorVendaSemanaAno > semanaComMaisVendas)
                    semanaComMaisVendas = melhorVendaSemanaAno;
            }

            return semanaComMaisVendas;
        }

        private void GetVendasDoAno()
        {
            GetVendasDoMes();

            double vendaAno = 0;
            foreach (var vendaMes in TotalVendidoMes)
                vendaAno += vendaMes;

            this.TotalVendidoAno = vendaAno;
        }

        private void ZerarValoresVendidos()
        {
            TotalVendidoAno = 0;
            TotalVendidoMes = new double[QuantidadeMesAno];
        }
    }
}
