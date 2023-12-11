using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Reserva;
using static ClassLibrary.Veiculo;

namespace ClassLibrary
{
    public class Funcionario: Pessoa
    {
        private static int matriculaFuncionario = 2000;
        private readonly int matricula;

        public Funcionario(string nome, string cpf, Endereco endereco): base(nome, cpf, endereco)
        {
            matricula = matriculaFuncionario++;
        }

        public int GetMatricula() 
        {  
            return matricula; 
        }

        public Cliente CadastrarCliente(string nome, string cpf, Endereco endereco)
        {
            Cliente cliente = new Cliente(nome , cpf, endereco);
            Console.WriteLine("Cliente cadastrado com sucesso!");
            return cliente;
        }

        public Veiculo AdicionarVeiculo(TipoVeiculo tipoVeiculo, MarcaVeiculo marca, ModeloVeiculo modelo, string placa, bool integridade, EstadoVeiculo estadoDoVeiculo, double precoAluguelDiario)
        {
            Veiculo veiculoNovo = new Veiculo(tipoVeiculo, marca, modelo, placa, integridade, estadoDoVeiculo, precoAluguelDiario);
            Console.WriteLine("Veículo adicionado com sucesso!");
            veiculoNovo.ImprimirInformacoes();
            return veiculoNovo;
        }

        public void ReceberVeiculo(Reserva reserva)
        {
            Veiculo veiculo = reserva.GetVeiculo();
            if (veiculo.GetEstadoVeiculo() == EstadoVeiculo.Alugado && veiculo.GetIntegridadeVeiculo())
            {
                veiculo.AlterarEstadoVeiculo(EstadoVeiculo.Disponivel);
                reserva.AlterarEstadoReserva(EstadoReserva.Finalizada);
                Console.WriteLine("Veículo recebido e reserva finalizada!");
            }
            else
                Console.WriteLine("Veículo não está alugado ou está em manutenção.");
        }

        public void LiberarVeiculo(Reserva reserva)
        {
            if(reserva.GetPagamento() != null)
                Console.WriteLine("Veículo liberado para cliente!");
            else
                Console.WriteLine("Realize o pagamento da reserva para que o veículo seja liberado!");
        }

        public void VerificarIntegridadeDoVeiculo(Veiculo veiculo)
        {
            if (veiculo.GetIntegridadeVeiculo())
                Console.WriteLine("Integridade do veículo verificada: veículo aprovado para ser devolvido!");
            else
            {
                veiculo.AlterarEstadoVeiculo(EstadoVeiculo.EmManutencao);
                Console.WriteLine("Integridade do veículo verificada: veículo danificado, encaminhado para manutenção!");
            }
        }
    }
}
