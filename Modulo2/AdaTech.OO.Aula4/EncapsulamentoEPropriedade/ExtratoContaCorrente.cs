
namespace EncapsulamentoEPropriedade
{
    public class ExtratoContaCorrente
    {
        public ExtratoContaCorrente(decimal saldoAnterior)
        {
            this.Operacoes = new List<OperacoesContaCorrente>();
            this.SaldoAnterior = saldoAnterior;
        }

        private decimal _saldoAnterior;
        public decimal SaldoAnterior { 
            get
            {
                return _saldoAnterior;
            }
            
            private set {
                if (value < 0) throw new ArgumentException("Valor invalido");
                _saldoAnterior = value;
            } 
        }

        public decimal Total
        {
            get
            {
                return SaldoAnterior + CalcularOperacoesHoje();
            }
        }

        private decimal CalcularOperacoesHoje()
        {
            decimal saldo = 0;

            foreach (var operacao in Operacoes)
            {
                if (operacao.Tipo == TipoOperacoesContaCorrente.Entrada)
                {
                    saldo = saldo + operacao.Valor;
                    continue;
                }

                if (operacao.Tipo == TipoOperacoesContaCorrente.Saida)
                {
                    saldo = saldo - operacao.Valor;
                    continue;
                }

                throw new ArgumentException("Operação Inválida");
            }

            return saldo;
        }

        public List<OperacoesContaCorrente> Operacoes { get; private set; }

        public void Saque(decimal valor) 
        {
            if (valor < Total)
                throw new ArgumentException("Total em C/C insuficiente");

            Operacoes.Add(new OperacoesContaCorrente { Tipo = TipoOperacoesContaCorrente.Saida, Valor = valor });
        }

        public void Deposito(decimal valor)
        {
            if (valor <= 0) 
                throw new ArgumentException("Depósito inválido");

            Operacoes.Add(new OperacoesContaCorrente { Tipo = TipoOperacoesContaCorrente.Entrada, Valor = valor });
        }
    }

    public class OperacoesContaCorrente
    {
        public decimal Valor;
        public TipoOperacoesContaCorrente Tipo;
    }

    public enum TipoOperacoesContaCorrente
    {
        Entrada = 1,
        Saida = 2
    }
}
