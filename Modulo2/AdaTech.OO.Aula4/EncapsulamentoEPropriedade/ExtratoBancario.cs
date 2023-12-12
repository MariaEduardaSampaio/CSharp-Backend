using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulamentoEPropriedade
{
    internal class ExtratoBancario
    {
        //Encapsulamento => 
        //1 - Controle de Acesso
        //2 - Proteção de dados/ algoritmo
        //3 - Escondendo alguma informação
        //4 - Validar Metodos, atributos, propriedades, construtores, delegates etc...

        private string _numeroConta;

        public string NumeroConta { 
            get {
                return _numeroConta;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Valor inválido");

                _numeroConta = "00000" + value;
            } 
        }
        public readonly DateTime Data;

        public ExtratoBancario(string numeroConta, DateTime data, decimal saldoCCAnterior)
        {
            NumeroConta = numeroConta;
            Data = data;
            ExtratoContaCorrente = new ExtratoContaCorrente(saldoCCAnterior);
        }

        public ExtratoContaCorrente ExtratoContaCorrente { get; }

        //Saldo em Aplicacoes, exemplo: RendaFixa

        //ExtratoContaCorrente = HJ É O QUE EU TINHA ONTEM + OPERACOES
        //EXEMPLO: ONTEM TINHA SALDO DE 3000, E HJ FIZ UM SAQUE = 10 E UM DEPOSITO 15
        //LOGO HJ TENH0 =  R$3000 (TINHA ONTEM) - 10 (SAQUE DE HJ) + 15(DEPOSITO DE HJ) = R$ 3005,00

        public void DepositoCC(decimal valor)
        {
            this.ExtratoContaCorrente.Deposito(valor);
        }

        public decimal Saldo { get { return ExtratoContaCorrente.Total; } }
    }
}
