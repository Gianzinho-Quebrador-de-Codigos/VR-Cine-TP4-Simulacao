namespace VRCineSimulacao.Models
{
    public class Sessao
    {
        private int _id;
        private DateTime _inicio;
        private DateTime _fim;
        private double _precoInteira;
        private double _precoMeia;
        private bool _cancelada;
        private Filme _filme = null!;
        private Sala _sala = null!;

        public Sessao(int id, DateTime inicio, DateTime fim, double precoInteira, double precoMeia, bool cancelada)
        {
            _id = id;
            _inicio = inicio;
            _fim = fim;
            _precoInteira = precoInteira;
            _precoMeia = precoMeia;
            _cancelada = cancelada;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public DateTime Inicio { get { return _inicio; } set { _inicio = value; } }
        public DateTime Fim { get { return _fim; } set { _fim = value; } }
        public double PrecoInteira { get { return _precoInteira; } set { _precoInteira = value; } }
        public double PrecoMeia { get { return _precoMeia; } set { _precoMeia = value; } }
        public bool Cancelada { get { return _cancelada; } set { _cancelada = value; } }
        public Filme Filme { get { return _filme; } set { _filme = value; } }
        public Sala Sala { get { return _sala; } set { _sala = value; } }

        public bool EstaEncerrada()
        {
            return DateTime.Now >= Fim;
        }
    }
}
