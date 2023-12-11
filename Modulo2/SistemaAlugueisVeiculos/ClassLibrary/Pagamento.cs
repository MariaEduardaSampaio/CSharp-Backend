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
        private readonly float precoReserva;
        private readonly Dictionary<MetodoDePagamento, float> metodoDePagamentoPorValor;
        private StatusPagamento statusPagamento;

        public Pagamento(float precoReserva, Dictionary<MetodoDePagamento, float> metodoDePagamentoPorValor)
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

        public Dictionary<MetodoDePagamento, float> GetMetodoDePagamentoPorValor()
        {
            return metodoDePagamentoPorValor;
        }

        public bool ValidarPagamento(Dictionary<MetodoDePagamento, float> metodoDePagamentoPorValor)
        {
            float somaTotalPagamento = 0;

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
