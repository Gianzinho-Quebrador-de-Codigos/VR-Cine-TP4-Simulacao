namespace VRCineSimulacao.Models
{
    public class Cinema
    {
        private int _id;
        private string _nome;
        private string _endereco;

        public Cinema(int id, string nome, string endereco)
        {
            _id = id;
            _nome = nome;
            _endereco = endereco;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Endereco { get { return _endereco; } set { _endereco = value; } }
    }
}
