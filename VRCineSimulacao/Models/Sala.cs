namespace VRCineSimulacao.Models
{
    public class Sala
    {
        private int _id;
        private string _nome;
        private bool _ativa;
        private Cinema _cinema = null!;

        public Sala(int id, string nome, bool ativa)
        {
            _id = id;
            _nome = nome;
            _ativa = ativa;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
        public bool Ativa { get { return _ativa; } set { _ativa = value; } }
        public Cinema Cinema { get { return _cinema; } set { _cinema = value; } }
    }
}
