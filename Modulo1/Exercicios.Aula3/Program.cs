namespace Exercicios
{
    internal class Program
    {
        static void VerificaNumeroImparOuPar()
        {
            Console.WriteLine("Entre com um número: ");
            int numero = int.Parse(Console.ReadLine());
            if (VerificaNumero.EhPar(numero))
                Console.WriteLine($"O número {numero} é par.\n");
            else
                Console.WriteLine($"O número {numero} é ímpar.\n");
        }

        static void RealizarOperacoesBasicas()
        {
            Console.WriteLine("Entre com dois números para realizar as operações básicas.");
            decimal v1 = decimal.Parse(Console.ReadLine());
            decimal v2 = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Calculadora.Soma(v1, v2));
            Console.WriteLine(Calculadora.Subtracao(v1, v2));
            Console.WriteLine(Calculadora.Divisao(v1, v2));
            Console.WriteLine(Calculadora.Multiplicacao(v1, v2));
        }

        static void AprovadoEmDisciplina()
        {
            Console.WriteLine("Entre com a nota do aluno.");
            float nota = float.Parse(Console.ReadLine());
            if (VerificaNumero.AprovadoEmDisciplina(nota))
                Console.WriteLine($"Aluno é aprovado com nota {nota}.");
            else
                Console.WriteLine($"Aluno é reprovado com nota {nota}.");
        }

        static void AnalisarString()
        {
            Console.WriteLine("Entre com uma frase para análise: ");
            string frase = Console.ReadLine();
            AnalisaString.AnalisarString(frase);
        }

        static void VerificarTriangulo()
        {
            Console.WriteLine("Entre com os valores dos catetos e da hipotenusa, nesta ordem:");
            float c1 = float.Parse(Console.ReadLine());
            float c2 = float.Parse(Console.ReadLine());
            float h = float.Parse(Console.ReadLine());
            if (VerificaTipoTriangulo.EhValido(c1, c2, h))
            {
                if (VerificaTipoTriangulo.EhEquilatero(c1, c2, h))
                    Console.WriteLine("O triângulo é equilátero!");
                else if (VerificaTipoTriangulo.EhIsosceles(c1, c2, h))
                    Console.WriteLine("O triângulo é isósceles!");
                else if (VerificaTipoTriangulo.EhRetangulo(c1, c2, h))
                    Console.WriteLine("O triângulo é retângulo!");
                else if (VerificaTipoTriangulo.EhEscaleno(c1, c2, h))
                    Console.WriteLine("O triângulo é escaleno!");
            }
            else
                Console.WriteLine("O triângulo não é válido.");
        }

        static void ConverterDecimal()
        {
            Console.WriteLine("Entre com um número decimal.");
            decimal numero = decimal.Parse(Console.ReadLine());
            VerificaNumero.ConversaoDeTipos(numero);
        }

        static void CalcularAreaDeCirculo()
        {
            Console.WriteLine("Entre com o raio do círculo em m:");
            decimal raio = decimal.Parse(Console.ReadLine());
            decimal area = VerificaNumero.CalculaAreaCirculo(raio);
            Console.WriteLine($"A área do círculo de raio {raio}m e {area}m²");
        }

        static void ListarExercicios()
        {
            Console.WriteLine("1. Verificação de número ímpar ou par.");
            Console.WriteLine("2. Calculadora simples."); 
            Console.WriteLine("3. Aprovação em disciplina.");
            Console.WriteLine("4. Verificação de tipo de triângulo.");
            Console.WriteLine("5. Análise de string.");
            Console.WriteLine("6. Conversão de tipos de um decimal.");
            Console.WriteLine("7. Cálculo de área de círculo.");
            Console.WriteLine("Caso queira sair do programa, digite 0.");
        }
        static void Main(string[] args)
        {
            bool validaOpcao;
            uint opcao = 8;

            Console.WriteLine("***** Exercícios da primeira semana *****\n");

            while (opcao != 0)
            {
                switch(opcao)
                {
                    case 0: 
                        Console.WriteLine("Saindo do programa...");
                        
                        break;

                    case 1:
                        VerificaNumeroImparOuPar();
                        break;
                    
                    case 2:
                        RealizarOperacoesBasicas();
                        break;
                    
                    case 3:
                        AprovadoEmDisciplina();
                        break;
                    
                    case 4:
                        VerificarTriangulo();
                        break;
                    
                    case 5:
                        AnalisarString();
                        break;
                    
                    case 6:
                        ConverterDecimal();
                        break;
                    
                    case 7:
                        CalcularAreaDeCirculo();
                        break;
                    
                    case 8:
                        ListarExercicios();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Digite 8 para listar os exercícios novamente ou 0 caso deseja sair do programa.");
                        break;
                }

                Console.WriteLine("\nEscolha um comando: ");
                validaOpcao = uint.TryParse(Console.ReadLine(), out opcao);

                while (!validaOpcao)
                {
                    Console.WriteLine("Escolha um número válido. Tente novamente:");
                    validaOpcao = uint.TryParse(Console.ReadLine(), out opcao);
                }
            }
        }
    }
}
