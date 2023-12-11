namespace ClassLibrary
{
    public class Pessoa
    {
        private readonly string nome;
        private readonly string cpf;
        private readonly Endereco endereco;

        public Pessoa(string nome, string cpf, Endereco endereco)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.endereco = endereco;
        }

        public string GetNome()
        {
            return nome;
        }

        public string GetCpf()
        {
            return cpf;
        }

        public Endereco GetEndereco()
        {
            return endereco;
        }
    }
}
