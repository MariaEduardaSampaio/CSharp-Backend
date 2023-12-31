﻿using ClassLibrary;
using static ClassLibrary.Pagamento;
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

        public Cliente CadastrarCliente(Funcionario funcionario)
        {
            Console.WriteLine("Entre com o nome do cliente para cadastrá-lo:");
            string nome = Console.ReadLine();
            Console.WriteLine("Entre com o CPF do cliente:");
            string CPF = Console.ReadLine();
            Endereco endereco = CadastrarEndereco();
            Cliente cliente = funcionario.CadastrarCliente(nome, CPF, endereco);
            clientesCadastrados.Add(cliente);
            return cliente;
        }

        public Funcionario CadastrarFuncionario()
        {
            Console.WriteLine("Entre com o nome do funcionário para cadastrá-lo:");
            string nome = Console.ReadLine();
            Console.WriteLine("Entre com o CPF do funcionário:");
            string CPF = Console.ReadLine();
            Endereco endereco = CadastrarEndereco();
            Funcionario funcionario = new Funcionario(nome , CPF, endereco);
            funcionarios.Add(funcionario);
            return funcionario;
        }

        public Endereco CadastrarEndereco()
        {
            Console.WriteLine("Entre com o CEP do endereço do cliente:");
            string cep = Console.ReadLine();
            Console.WriteLine("Entre com o número da casa do cliente:");
            int numero = int.Parse(Console.ReadLine());
            return new Endereco(cep, numero);
        }

        public Veiculo CadastrarVeiculo(Funcionario funcionario)
        {
            bool entradaValida;
            TipoVeiculo tipoVeiculo;
            ModeloVeiculo modeloVeiculo;
            MarcaVeiculo marcaVeiculo;

            Console.WriteLine("Tipo de veículos");
            Console.WriteLine("Carro = 1\tMoto = 2\tCaminhão = 3");
            do
            {
                Console.WriteLine("Entre com o tipo do veículo:");
                entradaValida = Enum.TryParse(Console.ReadLine(), out tipoVeiculo);
            } while (!entradaValida);

            Console.WriteLine($"Marcas de {tipoVeiculo.ToString().ToLower()}");
            Console.WriteLine("Ford = 1\tChevrolet = 2\tToyota = 3");
            do
            {
                Console.WriteLine($"Entre com a marca do {tipoVeiculo.ToString().ToLower()}:");
                entradaValida = Enum.TryParse(Console.ReadLine(), out marcaVeiculo);
            } while (!entradaValida);


            Console.WriteLine($"Modelo de {tipoVeiculo.ToString().ToLower()}");
            Console.WriteLine("Sedan = 1\tHatchback = 2\tSUV = 3");
            do
            {
                Console.WriteLine($"Entre com o modelo do {tipoVeiculo.ToString().ToLower()}:");
                entradaValida = Enum.TryParse(Console.ReadLine(), out modeloVeiculo);
            } while (!entradaValida);

            Console.WriteLine("Entre com a placa do carro:");
            string placaDoCarro = Console.ReadLine();

            Console.WriteLine($"Entre com o valor do aluguel diário do {tipoVeiculo.ToString().ToLower()}");
            float valorAluguelDiario = float.Parse(Console.ReadLine());

            Veiculo veiculo = funcionario.AdicionarVeiculo(tipoVeiculo, marcaVeiculo, modeloVeiculo, placaDoCarro, true, EstadoVeiculo.Disponivel, valorAluguelDiario);
            veiculos.Add(veiculo);
            
            return veiculo;
        }

        public void RealizarPagamentoDeReserva(Reserva reserva)
        {
            Dictionary<MetodoDePagamento, float> metodoDePagamentoPorValor = new Dictionary<MetodoDePagamento, float>();
            MetodoDePagamento metodoDePagamento;
            bool entradaValida;
            double valorReserva = reserva.CalcularValorDaReserva(reserva.GetDataInicial(), reserva.GetDataFinal());
            float valorPagamento, somaPagamentoTotal = 0;

            do
            {
                Console.WriteLine("Cartão de crédito = 1\tCartão de débito = 2\tDinheiro físico = 3\tPIX = 4");
                do
                {
                    Console.WriteLine("Entre com o método de pagamento: ");
                    entradaValida = Enum.TryParse(Console.ReadLine(), out metodoDePagamento);
                } while (!entradaValida);

                Console.WriteLine("Entre com o valor que deseja pagar neste método de pagamento:");
                valorPagamento = float.Parse(Console.ReadLine());

                metodoDePagamentoPorValor.Add(metodoDePagamento, valorPagamento);
                somaPagamentoTotal += valorPagamento;
            } while (somaPagamentoTotal < valorReserva);

            reserva.RealizarPagamento(metodoDePagamentoPorValor);
        }

        public Reserva CadastrarReserva(Cliente cliente, Funcionario funcionario)
        {
            DateTime dataInicial, dataFinal;
            Veiculo veiculo;
            int idVeiculo;

            Console.WriteLine("Insira uma data de início da reserva (no formato DD/MM/AAAA): ");
            dataInicial = tryParseData();
            Console.WriteLine("Insira uma data final da reserva (no formato DD/MM/AAAA): ");
            dataFinal = tryParseData();

            ListarTodosOsVeiculosDisponiveis();
            do
            {
                Console.WriteLine("Escolha um veículo a partir do seu número de identificação: ");
                idVeiculo = int.Parse(Console.ReadLine());
                veiculo = veiculos.FirstOrDefault(veiculo => veiculo.GetId() == idVeiculo);
            } while (veiculo == null);

            Reserva reserva = new Reserva(dataInicial, dataFinal, cliente, funcionario, veiculo);
            RealizarPagamentoDeReserva(reserva);
            cliente.AdicionarReserva(reserva);
            reservas.Add(reserva);
            return reserva;
        }

        private DateTime tryParseData()
        {
            bool entradaValida;
            DateTime data;
            do
            {
                entradaValida = DateTime.TryParse(Console.ReadLine(), out data);
            } while (!entradaValida);

            return data;
        }

        static void Main(string[] args)
        {
            Endereco endereco1 = new Endereco("12345-678", 10);
            Endereco endereco2 = new Endereco("12345-634", 20);
            Endereco endereco3 = new Endereco("45568-909", 84);

            Funcionario funcionario1 = new Funcionario("func1", "234234234-23", endereco2);

            Cliente cliente1 = new Cliente("maria", "12345678-90", endereco1);
            Cliente cliente2 = funcionario1.CadastrarCliente("eduarda", "234123124-21", endereco3);

            Veiculo veiculo1 = funcionario1.AdicionarVeiculo(TipoVeiculo.Carro, MarcaVeiculo.Chevrolet, ModeloVeiculo.Sedan, "ABC1234", true, EstadoVeiculo.Disponivel, 75);
            
            DateTime diaInicial = DateTime.Now;
            DateTime diaFinal = DateTime.Now.AddDays(4);

            Dictionary<Pagamento.MetodoDePagamento, float> metodoDePagamentoPorValor = new Dictionary<Pagamento.MetodoDePagamento, float>
            {
                { MetodoDePagamento.CartaoDeCredito, 150 },
                { MetodoDePagamento.CartaoDeDebito, 100 },
                { MetodoDePagamento.DinheiroFisico, 50 }
            };

            Reserva reserva1 = new Reserva(diaInicial, diaFinal, cliente1, funcionario1, veiculo1);
            cliente1.AdicionarReserva(reserva1);
            reserva1.CalcularValorDaReserva(diaInicial, diaFinal);
            reserva1.RealizarPagamento(metodoDePagamentoPorValor);
            funcionario1.LiberarVeiculo(reserva1);
            cliente1.DevolverVeiculo(veiculo1);
        }
    }
}
