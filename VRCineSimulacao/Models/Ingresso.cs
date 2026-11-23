namespace VRCineSimulacao.Models
{
    public class Ingresso
    {
        private int _id;
        private int _tipo;
        private double _preco;
        private int _status;
        private string _codigoQR;
        private DateTime? _dataEmissao;
        private string _necessidadesVR;
        private bool _utilizado = false;
        private Sessao _sessao = null!;
        private Assento _assento = null!;

        public Ingresso(int id, int tipo, double preco, int status, string codigoQR, DateTime? dataEmissao, string necessidadesVR)
        {
            _id = id;
            _tipo = tipo;
            _preco = preco;
            _status = status;
            _codigoQR = codigoQR;
            _dataEmissao = dataEmissao;
            _necessidadesVR = necessidadesVR;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }
        public double Preco { get { return _preco; } set { _preco = value; } }
        public int Status { get { return _status; } set { _status = value; } }
        public string CodigoQR { get { return _codigoQR; } set { _codigoQR = value; } }
        public DateTime? DataEmissao { get { return _dataEmissao; } set { _dataEmissao = value; } }
        public string NecessidadesVR { get { return _necessidadesVR; } set { _necessidadesVR = value; } }
        public bool Utilizado { get { return _utilizado; } set { _utilizado = value; } }
        public Sessao Sessao { get { return _sessao; } set { _sessao = value; } }
        public Assento Assento { get { return _assento; } set { _assento = value; } }

        public string ConsultarEntrada(int sessaoId)
        {
            if (Status != 1) return "Ingresso cancelado ou não emitido.";
            if (Sessao.Id != sessaoId) return "Ingresso de outra sessão. Continua válido na sessão correta.";
            if (Utilizado) return "Este ingresso já foi utilizado.";
            if (Sessao.Cancelada) return "A sessão foi cancelada.";
            return "Ingresso válido. Você pode confirmar a entrada.";
        }
        public bool RegistrarEntrada(int sessaoId)
        {
            if (Status != 1 || Sessao.Id != sessaoId || Utilizado || Sessao.Cancelada) return false;
            Utilizado = true;
            return true;
        }
    }
}
