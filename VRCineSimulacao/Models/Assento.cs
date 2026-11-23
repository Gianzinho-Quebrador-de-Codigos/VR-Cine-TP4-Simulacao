namespace VRCineSimulacao.Models
{
    public class Assento
    {
        private int _id;
        private string _codigo;
        private bool _ativo;
        private Sala _sala = null!;

        public Assento(int id, string codigo, bool ativo)
        {
            _id = id;
            _codigo = codigo;
            _ativo = ativo;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Codigo { get { return _codigo; } set { _codigo = value; } }
        public bool Ativo { get { return _ativo; } set { _ativo = value; } }
        public Sala Sala { get { return _sala; } set { _sala = value; } }
    }
}
