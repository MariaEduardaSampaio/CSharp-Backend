﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Pagamento;

namespace ClassLibrary
{
    public class Reserva
    {
        public enum EstadoReserva
        {
            Cancelada = 1,
            EmAndamento = 2,
            Finalizada = 3,
        }

        private readonly DateTime diaInicial;
        private DateTime diaFinal;
        private float precoReserva;
        private readonly Cliente cliente;
        private readonly Funcionario funcionario;
        private readonly Veiculo veiculo;
        private EstadoReserva estadoReserva;
        private Pagamento pagamento;

        public Reserva(DateTime diaInicial, DateTime diaFinal, Cliente cliente, Funcionario funcionario, Veiculo veiculo)
        {
            this.diaInicial = diaInicial;
            this.diaFinal = diaFinal;
            this.precoReserva = 0;
            this.cliente = cliente;
            this.funcionario = funcionario;
            this.veiculo = veiculo;
            this.estadoReserva = EstadoReserva.EmAndamento;
            this.pagamento = null;
        }

        public void RealizarPagamento(Dictionary<MetodoDePagamento, float> metodoDePagamentoPorValor)
        {
            Pagamento pagamento = new Pagamento(precoReserva, metodoDePagamentoPorValor);
            this.pagamento = pagamento;
        }
        public DateTime GetDataInicial()
        {
            return diaInicial;
        }

        public DateTime GetDataFinal()
        {
            return diaFinal;
        }
        public Cliente GetCliente()
        {
            return cliente; 
        }
        public Veiculo GetVeiculo() 
        {  
            return veiculo; 
        }

        public Pagamento GetPagamento() 
        { 
            return pagamento; 
        }

        public EstadoReserva GetEstadoReserva()
        {
            return estadoReserva;
        }

        public Funcionario GetFuncionario() 
        {
            return funcionario; 
        } 

        public void AlterarEstadoReserva(EstadoReserva estadoReserva)
        {
            this.estadoReserva = estadoReserva;
        }

        public float CalcularValorDaReserva(DateTime diaInicial, DateTime diaFinal)
        {
            TimeSpan duracaoReserva = diaFinal.Subtract(diaInicial);

            precoReserva = (float)(duracaoReserva.TotalDays * veiculo.GetAluguelDiario());
            
            return precoReserva;
        }

        public void CancelarReserva()
        {
            if (estadoReserva == EstadoReserva.EmAndamento)
            {
                estadoReserva = EstadoReserva.Cancelada;
                Console.WriteLine("Reserva cancelada com sucesso!");
            }
            else
                Console.WriteLine("Não é possível cancelar uma reserva que não está em andamento.");
        }

        public void ImprimirReserva()
        {
            Console.WriteLine($"Data inicial: {diaInicial}");
            Console.WriteLine($"Data final: {diaFinal}");
            Console.WriteLine($"Preço da reserva: {precoReserva} ");
            Console.WriteLine($"Status de pagamento: {pagamento.GetStatusPagamento()}");
            Console.WriteLine($"Cliente: {cliente.GetNome()} (id: {cliente.GetIdCliente()})");
            Console.WriteLine($"Atendente: {funcionario.GetNome()} (id: {funcionario.GetMatricula()})");
            Console.WriteLine($"Marca do veículo: {veiculo.GetMarca()}\n" +
                              $"Modelo do veículo: {veiculo.GetModelo()}" +
                              $"Placa do veículo: {veiculo.GetPlaca()}");
        }

    }
}
