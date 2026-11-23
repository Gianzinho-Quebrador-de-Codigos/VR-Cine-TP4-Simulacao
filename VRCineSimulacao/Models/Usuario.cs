namespace VRCineSimulacao.Models
{
    public class Usuario
    {
        private int _id;
        private string _nome;
        private string _email;
        private string _senhaHash;
        private int _perfil;

        public Usuario(int id, string nome, string email, string senhaHash, int perfil)
        {
            _id = id;
            _nome = nome;
            _email = email;
            _senhaHash = senhaHash;
            _perfil = perfil;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string SenhaHash { get { return _senhaHash; } set { _senhaHash = value; } }
        public int Perfil { get { return _perfil; } set { _perfil = value; } }
    }
}
