namespace WebprocessosAPI.Model
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool Excluido { get; set; }
        public int UsuarioId { get; set; }
        public string Senha { get; set; }
    }
}
