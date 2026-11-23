namespace VRCineSimulacao.Models
{
    public class Avaliacao
    {
        private int _id;
        private int _notaFilme;
        private int _notaConforto;
        private string _comentario;
        private DateTime _dataAvaliacao;
        private Sessao _sessao = null!;

        public Avaliacao(int id, int notaFilme, int notaConforto, string comentario, DateTime dataAvaliacao)
        {
            _id = id;
            _notaFilme = notaFilme;
            _notaConforto = notaConforto;
            _comentario = comentario;
            _dataAvaliacao = dataAvaliacao;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public int NotaFilme { get { return _notaFilme; } set { _notaFilme = value; } }
        public int NotaConforto { get { return _notaConforto; } set { _notaConforto = value; } }
        public string Comentario { get { return _comentario; } set { _comentario = value; } }
        public DateTime DataAvaliacao { get { return _dataAvaliacao; } set { _dataAvaliacao = value; } }
        public Sessao Sessao { get { return _sessao; } set { _sessao = value; } }

        public bool NotasValidas()
        {
            return NotaFilme >= 1 && NotaFilme <= 5 && NotaConforto >= 1 && NotaConforto <= 5;
        }
    }
}
