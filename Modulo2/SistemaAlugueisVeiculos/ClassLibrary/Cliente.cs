using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Pagamento;
using static ClassLibrary.Reserva;

namespace ClassLibrary
{
    public class Cliente: Pessoa
    {
        private static int contadorClientes = 1;
        private int idCliente;
        private List<Reserva> reservas;

        public Cliente(string nome, string cpf, Endereco endereco) : base(nome, cpf, endereco)
        {
            idCliente = contadorClientes++;
            reservas = new List<Reserva>();
        }

        public int GetIdCliente()
        {
            return idCliente;
        }

        public List<Reserva> GetReservas()
        {
            return reservas;
        }

        public void ImprimirReservas()
        {
            foreach(var reserva in reservas)
            {
                reserva.ImprimirReserva();
            }
        }

        public Reserva AdicionarReserva(Reserva reserva)
        {
            reservas.Add(reserva);
            return reserva;
        }

        public void DevolverVeiculo(Veiculo veiculo)
        {
            List<Reserva> reservasAtivas = reservas.Where(reserva => reserva.GetEstadoReserva() == EstadoReserva.EmAndamento).ToList();
            Reserva reservaVeiculo = reservasAtivas.FirstOrDefault(reserva => reserva.GetVeiculo() == veiculo);
            
            Funcionario atendente = reservaVeiculo.GetFuncionario();
            if (reservaVeiculo != null)
                atendente.ReceberVeiculo(reservaVeiculo);
            else
                Console.WriteLine("Não existem reservas ativas deste veículo vinculadas ao cliente.");
        }

        public void RealizarPagamento(Dictionary<MetodoDePagamento, float> metodoDePagamentoPorValor)
        {
            Reserva reservaNaoPaga = reservas.FirstOrDefault(reserva => reserva.GetPagamento() == null);
            if (reservaNaoPaga != null)
            {
                reservaNaoPaga.RealizarPagamento(metodoDePagamentoPorValor);
                Console.WriteLine("Pagamento de reserva realizado com sucesso!");
            }
            else
                Console.WriteLine("Pagamento de reserva já foi realizado!");
        }
    }
}
