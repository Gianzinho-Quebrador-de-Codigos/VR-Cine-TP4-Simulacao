namespace VRCineSimulacao.Models
{
    public class Filme
    {
        private int _id;
        private string _titulo;
        private string _sinopse;
        private int _duracaoMinutos;

        public Filme(int id, string titulo, string sinopse, int duracaoMinutos)
        {
            _id = id;
            _titulo = titulo;
            _sinopse = sinopse;
            _duracaoMinutos = duracaoMinutos;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Sinopse { get { return _sinopse; } set { _sinopse = value; } }
        public int DuracaoMinutos { get { return _duracaoMinutos; } set { _duracaoMinutos = value; } }
    }
}
