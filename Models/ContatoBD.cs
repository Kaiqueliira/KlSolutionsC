using MySqlConnector;

namespace KlSolutions.Models
{
    public class ContatoBD
    {
        
        private const string DadosConexao = "Database=klsolutions; Data Source=localhost; User Id=root;";
        public void Cadastrar(Contato contato){

            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();
            string Query = "INSERT INTO contato(nome, email, assunto, mensagem) values (@Nome, @Email, @Assunto, @Mensagem); ";

            MySqlCommand comandoQuery = new MySqlCommand(Query, conexao);

            comandoQuery.Parameters.AddWithValue("@Nome", contato.nome);
            comandoQuery.Parameters.AddWithValue("@Email", contato.email);
            comandoQuery.Parameters.AddWithValue("@Assunto", contato.assunto);
            comandoQuery.Parameters.AddWithValue("@Mensagem", contato.mensagem);

            comandoQuery.ExecuteNonQuery();
            conexao.Close();
        }
    }

        
}