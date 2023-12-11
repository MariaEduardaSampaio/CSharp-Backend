using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Veiculo
    {
        public enum EstadoVeiculo
        {
            Disponivel = 1,
            Alugado = 2,
            EmManutencao = 3
        }

        public enum MarcaVeiculo
        {
            Ford = 1,
            Chevrolet = 2,
            Toyota = 3
            // Adicionar outras marcas
        }

        public enum ModeloVeiculo
        {
            Sedan = 1,
            Hatchback = 2,
            SUV = 3
            // adicionar outros modelos
        }

        public enum TipoVeiculo
        {
            Carro = 1,
            Moto = 2,
            Caminhao = 3
        }
        private static int contadorIdVeiculo = 1;
        private readonly int idVeiculo;
        private readonly TipoVeiculo tipoVeiculo;
        private readonly MarcaVeiculo marca;
        private readonly ModeloVeiculo modelo;
        private string placa;
        private bool integridade;
        private EstadoVeiculo estadoDoVeiculo;
        private readonly float precoAluguelDiario;

        public Veiculo(TipoVeiculo tipoVeiculo, MarcaVeiculo marca, ModeloVeiculo modelo, string placa, bool integridade, EstadoVeiculo estadoDoVeiculo, float precoAluguelDiario)
        {
            this.idVeiculo = contadorIdVeiculo++;
            this.tipoVeiculo = tipoVeiculo;
            this.marca = marca;
            this.modelo = modelo;
            ValidarPlaca(placa);
            this.integridade = integridade;
            this.estadoDoVeiculo = estadoDoVeiculo;
            this.precoAluguelDiario = precoAluguelDiario;
        }

        public void ValidarPlaca(string placa)
        {
            string pattern = @"^[A-Z]{3}\d{4}$";

            if (Regex.IsMatch(placa, pattern))
                SetPlaca(placa);
            else
                Console.WriteLine("Placa não é válida.");
        }

        public void SetPlaca(string placa)
        {
            this.placa = placa;
        }

        public int GetId()
        {
            return idVeiculo;
        }

        public TipoVeiculo GetTipoVeiculo()
        {
            return tipoVeiculo;
        }

        public MarcaVeiculo GetMarca()
        {
            return marca;
        }

        public ModeloVeiculo GetModelo() 
        {
            return modelo;
        }

        public string GetPlaca()
        {
            return placa;
        }

        public float GetAluguelDiario()
        {
            return precoAluguelDiario;
        }

        public bool GetIntegridadeVeiculo()
        {
            return integridade;
        }

        public EstadoVeiculo GetEstadoVeiculo()
        {
            return estadoDoVeiculo;
        }

        public void AlterarEstadoVeiculo(EstadoVeiculo estado)
        {
            if (estado == EstadoVeiculo.EmManutencao)
                integridade = false;
            estadoDoVeiculo = estado;
        }

        public void ImprimirInformacoes()
        {
            Console.WriteLine($"Veículo: {tipoVeiculo}    ID: {idVeiculo}");
            Console.WriteLine($"Marca: {marca}");
            Console.WriteLine($"Modelo: {modelo} ");
            Console.WriteLine($"Placa: {placa}");
            Console.WriteLine($"Preço do aluguel diário: {precoAluguelDiario}");
            Console.WriteLine($"Estado do veículo: {estadoDoVeiculo} ");
        }
    }
}
