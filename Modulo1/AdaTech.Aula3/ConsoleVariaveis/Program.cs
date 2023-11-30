namespace ConsoleVariaveis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            dobra(2);
            DateTime date = new(1, 2, 3);
            // console é bom para processos que começam e terminam
        }
        static int dobra(int n)
        {
            return n * 2;
        }
    }
}
