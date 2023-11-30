using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    internal static class Matriz
    {
        internal static int SomaElementos(int[,] matriz)
        {
            int soma = 0;
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    soma += matriz[linha, coluna];
                }
            }
            return soma;
        }
        internal static int[,] CriaMatriz()
        {
            int tamLinhas, tamColunas = 0;
            bool validaLinhas, validaColunas;
            Console.WriteLine("Entre com a quantidade de linhas e colunas da matriz:");
            do
            {
                validaLinhas = int.TryParse(Console.ReadLine(), out tamLinhas);
                validaColunas = int.TryParse(Console.ReadLine(), out tamColunas);
            } while (!validaLinhas || !validaColunas);

            int[,] matriz = new int[tamLinhas, tamColunas];
            return matriz;
        }

        internal static int[,] PreencheMatriz(int[,] matriz)
        {
            int tamLinhas = matriz.GetLength(0);
            int tamColunas = matriz.GetLength(1);
            int valor;
            bool validaValor;

            for (int linha = 0; linha < tamLinhas; linha++)
            {
                for (int coluna = 0; coluna < tamColunas; coluna++)
                {
                    do
                    {
                        Console.WriteLine($"Entre com um valor para a posição ({linha}, {coluna}): ");
                        validaValor = int.TryParse(Console.ReadLine(), out valor);
                    } while (!validaValor);
                    matriz[linha, coluna] = valor;
                }
            }
            return matriz;
        }
        internal static bool VerificaMatrizQuadrada(int[,] matriz)
        {
            int tamLinhas = matriz.GetLength(0);
            int tamColunas = matriz.GetLength(1);
            if (tamColunas == tamLinhas)
                return true;
            else
                return false;
        }

        internal static bool VerificaMatrizIdentidade(int[,] matriz)
        {
            int tamLinhas = matriz.GetLength(0);
            int tamColunas = matriz.GetLength(1);

            for (int linha = 0; linha < tamLinhas; linha++)
            {
                for (int coluna = 0; coluna < tamColunas; coluna++)
                {
                    if (linha == coluna && matriz[linha, coluna] != 1)
                        return false;

                    if (linha != coluna && matriz[linha, coluna] != 0)
                        return false;
                }
            }
            return true;
        }

        internal static void ImprimeMatriz(int[,] matriz)
        {
            int tamLinhas = matriz.GetLength(0);
            int tamColunas = matriz.GetLength(1);


            for (int linha = 0; linha < tamLinhas; linha++)
            {
                for (int coluna = 0; coluna < tamColunas; coluna++)
                {
                    Console.Write($" {matriz[linha, coluna]}");
                }
                Console.WriteLine();
            }
        }

        internal static bool VerificaMultMatrizes(int[,] A, int[,] B)
        {
            int tamLinhasA = A.GetLength(0);
            int tamColunasA = A.GetLength(1);
            int tamLinhasB = B.GetLength(0);
            int tamColunasB = B.GetLength(1);

            return (tamLinhasA == tamColunasB && tamColunasA == tamLinhasB);
        }

        internal static int[,] MultiplicaMatrizes(int[,] A, int[,] B)
        {
            int tamLinhasA = A.GetLength(0);
            int tamColunasA = A.GetLength(1);
            int tamLinhasB = B.GetLength(0);
            int tamColunasB = B.GetLength(1);
            int[,] matrizResultante = new int[tamLinhasA, tamColunasB];

            for (int linhaA = 0; linhaA < tamLinhasA; linhaA++)
            {
                for (int colunaB = 0; colunaB < tamColunasB; colunaB++)
                {
                    matrizResultante[linhaA, colunaB] = 0;
                    for (int k = 0; k < tamColunasA; k++)
                    {
                        matrizResultante[linhaA, colunaB] += A[linhaA, k] * B[k, colunaB];
                    }
                }
            }
            return matrizResultante;
        }

        internal static int[] SomaLinhasMatriz(int[,] matriz)
        {
            int tamLinhasA = matriz.GetLength(0);
            int tamColunasA = matriz.GetLength(1);
            int[] soma = new int[tamLinhasA];

            for (int posSoma = 0; posSoma < tamLinhasA; posSoma++)
            {
                for (int linhaA = 0; linhaA < tamLinhasA; linhaA++)
                {
                    for (int colunaA = 0; colunaA < tamColunasA; colunaA++)
                    {
                        if (posSoma == linhaA)
                        {
                            soma[posSoma] += matriz[linhaA, colunaA];
                        }
                        else
                            continue;
                    }
                }
            }
            return soma;
        }

        internal static int[] SomaColunasMatriz(int[,] matriz)
        {
            int tamLinhasA = matriz.GetLength(0);
            int tamColunasA = matriz.GetLength(1);
            int[] soma = new int[tamColunasA];

            for (int posSoma = 0; posSoma < tamColunasA; posSoma++)
            {
                for (int colunaA = 0; colunaA < tamColunasA; colunaA++)
                {
                    for (int linhaA = 0; linhaA < tamLinhasA; linhaA++)
                    {
                        if (posSoma == colunaA)
                        {
                            soma[posSoma] += matriz[linhaA, colunaA];
                        }
                        else
                            continue;
                    }
                }
            }
            return soma;
        }
    }
}
