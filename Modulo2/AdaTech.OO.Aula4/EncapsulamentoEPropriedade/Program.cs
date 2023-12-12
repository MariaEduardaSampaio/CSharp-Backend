namespace EncapsulamentoEPropriedade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Encapsulamento => 
            //1 - Controle de Acesso
            //2 - Proteção de dados/ algoritmo
            //3 - Escondendo alguma informação
            //4 - Validar Metodos, atributos, propriedades, construtores, delegates etc...

            var saldoCCAnterior = 3000;
            ExtratoBancario extrato = new ExtratoBancario("1", DateTime.Now.Date, saldoCCAnterior);

            var numeroConta = extrato.NumeroConta;

            extrato.DepositoCC(100);
            extrato.DepositoCC(5);

            Console.WriteLine($"O saldo é: {extrato.Saldo}");

            //CC 1000, resgate de 500
            //Derivativos => 2000 em garantia
            //Expert => Grasp
        }
    }
}
