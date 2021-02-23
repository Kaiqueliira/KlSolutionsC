
using System;
using MySqlConnector;

namespace KLSOLUTIONSC.Models
{
    public class UsuarioBD
    {
        private const string DadosConexao = "Database=login; Data Source=localhost; User Id=root;";

        public static void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados Funcionando.");
            Conexao.Close();
        }
    }
}