using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Pagamento
    {
        public enum MetodoDePagamento
        {
            CartaoDeCredito = 1,
            CartaoDeDebito = 2,
            DinheiroFisico = 3,
            PIX = 4
        }

        public enum StatusPagamento
        {
            Pago = 1,
            Cancelado = 2,
            AguardandoPagamento = 3
        }
        private readonly double precoReserva;
        private readonly Dictionary<MetodoDePagamento, double> metodoDePagamentoPorValor;
        private StatusPagamento statusPagamento;

        public Pagamento(double precoReserva, Dictionary<MetodoDePagamento, double> metodoDePagamentoPorValor)
        {
            this.precoReserva = precoReserva;
            if (ValidarPagamento(metodoDePagamentoPorValor))
            {
                this.metodoDePagamentoPorValor = metodoDePagamentoPorValor;
                statusPagamento = StatusPagamento.Pago;
            }
            else
                statusPagamento = StatusPagamento.AguardandoPagamento;
        }

        public Dictionary<MetodoDePagamento, double> GetMetodoDePagamentoPorValor()
        {
            return metodoDePagamentoPorValor;
        }

        public bool ValidarPagamento(Dictionary<MetodoDePagamento, double> metodoDePagamentoPorValor)
        {
            double somaTotalPagamento = 0;
            foreach (var (metodoDePagamento, valor) in metodoDePagamentoPorValor)
                somaTotalPagamento += valor;

            if (somaTotalPagamento > precoReserva)
                Console.WriteLine("Valor inserido no pagamento ultrapassa o valor da reserva.");
            else if (somaTotalPagamento < precoReserva)
                Console.WriteLine("Valor inserido no pagamento é menor que o valor da reserva.");
            else
            {
                Console.WriteLine("Pagamento realizado com sucesso!");
                return true;
            }
            return false;
        }

        public StatusPagamento GetStatusPagamento() 
        { 
            return statusPagamento;
        }

        public void AlterarStatusPagamento(StatusPagamento statusPagamento)
        {
            this.statusPagamento = statusPagamento;
        }
    }
}
