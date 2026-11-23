namespace VRCineSimulacao.Models
{
    public class ProdutoAlimenticio
    {
        private int _id;
        private string _nome;
        private string _descricao;
        private double _preco;
        private bool _disponivel;
        private Cinema _cinema = null!;

        public ProdutoAlimenticio(int id, string nome, string descricao, double preco, bool disponivel)
        {
            _id = id;
            _nome = nome;
            _descricao = descricao;
            _preco = preco;
            _disponivel = disponivel;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Descricao { get { return _descricao; } set { _descricao = value; } }
        public double Preco { get { return _preco; } set { _preco = value; } }
        public bool Disponivel { get { return _disponivel; } set { _disponivel = value; } }
        public Cinema Cinema { get { return _cinema; } set { _cinema = value; } }
    }
}
