
using System;
using MySqlConnector;
namespace KlSolutions.Models
{
    public class UsuarioBD
    {
        private const string DadosConexao = "Database=klsolutions; Data Source=localhost; User Id=root;";

        public Usuario FazerLogin(Usuario usuario){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM login WHERE login = @Login AND @Senha";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);
            ComandoQuery.Parameters.AddWithValue("@Login", usuario.Login);
            ComandoQuery.Parameters.AddWithValue("@Senha", usuario.Senha);
            MySqlDataReader  DadosEncontrados = ComandoQuery.ExecuteReader();

            Usuario User = null;
            if(DadosEncontrados.Read()){

                User.Id = DadosEncontrados.GetInt32("Id");
                User.Nome = DadosEncontrados.GetString("Nome");
                User.Login = DadosEncontrados.GetString("Login");
                User.Senha = DadosEncontrados.GetString("Senha");
            }
            Conexao.Close();

            return User;
        }



        public static void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados Funcionando.");
            Conexao.Close();
        }

        
    }
}