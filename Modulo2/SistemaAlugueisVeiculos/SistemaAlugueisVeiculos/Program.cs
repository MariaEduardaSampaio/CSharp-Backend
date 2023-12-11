using ClassLibrary;
using static ClassLibrary.Veiculo;

namespace SistemaAlugueisVeiculos
{
    internal class Program
    {
        private List<Veiculo> veiculos;
        private List<Cliente> clientesCadastrados;
        private List<Funcionario> funcionarios;
        private List<Reserva> reservas;

        public void ListarTodosOsVeiculos()
        {
            foreach (Veiculo veiculo in veiculos)
                veiculo.ImprimirInformacoes();
        }

        public void ListarTodosOsVeiculosDisponiveis()
        {
            List<Veiculo> veiculosDisponiveis = veiculos.Where(veiculo => veiculo.GetEstadoVeiculo() == EstadoVeiculo.Disponivel).ToList();
            foreach (Veiculo veiculo in veiculosDisponiveis)
                veiculo.ImprimirInformacoes();
        }

        public void CadastrarCliente(Funcionario funcionario)
        {
            Console.WriteLine("Entre com o nome do cliente para cadastrá-lo:");
            string nome = Console.ReadLine();
            Console.WriteLine("Entre com o CPF do cliente:");
            string CPF = Console.ReadLine();
            Endereco endereco = CadastrarEndereco();
            funcionario.CadastrarCliente(nome, CPF, endereco);
        }

        public Endereco CadastrarEndereco()
        {
            Console.WriteLine("Entre com o CEP do endereço do cliente:");
            string cep = Console.ReadLine();
            Console.WriteLine("Entre com o número da casa do cliente:");
            int numero = int.Parse(Console.ReadLine());
            return new Endereco(cep, numero);
        }

        static void Main(string[] args)
        {
            Endereco endereco1 = new Endereco("12345-678", 10);
            Endereco endereco2 = new Endereco("12345-634", 20);
            Endereco endereco3 = new Endereco("45568-909", 84);
            Cliente cliente1 = new Cliente("maria", "12345678-90", endereco1);
            Funcionario funcionario1 = new Funcionario("func1", "234234234-23", endereco2);
            Cliente cliente2 = funcionario1.CadastrarCliente("eduarda", "234123124-21", endereco3);
            Veiculo veiculo1 = funcionario1.AdicionarVeiculo(TipoVeiculo.Carro, MarcaVeiculo.Chevrolet, ModeloVeiculo.Sedan, "ABC1234", true, EstadoVeiculo.Disponivel, 75.00);
             // Reserva reserva1 = cliente2.AdicionarReserva();
        }
    }
}
