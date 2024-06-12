using System.Data.SqlClient;
using WebprocessosAPI.Model;

namespace WebprocessosAPI.DAO
{
    public class WebProcessosDAO
    {
        const string CONNECTION_STRING = "Password=admin;Persist Security Info=True;User ID=admin;Initial Catalog=Db_WebProcess;Data Source=DESKTOP-9795GE9";

        internal ClienteModel LoginDao(LoginRequest login)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"PROC_S_ClienteLogin";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Login", login.Username));
                        cmd.Parameters.Add(new SqlParameter("@Senha", login.Password));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ClienteModel C = new ClienteModel
                                {
                                    Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0,
                                    Nome = reader["Nome"] != DBNull.Value ? (string)reader["Nome"] : null,
                                    SobreNome = reader["SobreNome"] != DBNull.Value ? (string)reader["SobreNome"] : null,
                                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null,
                                    Telefone = reader["Telefone"] != DBNull.Value ? (string)reader["Telefone"] : null,
                                    CPF = reader["CPF"] != DBNull.Value ? (string)reader["CPF"] : null,
                                    UsuarioId = reader["UsuarioId"] != DBNull.Value ? (int)reader["UsuarioId"] : 0
                                };

                                return C;
                            }
                        }
                    }
                }
                return null; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
        }

        internal object ReprovarServicoCliente(int codServicoVinculado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"PROC_I_ReprovarServicoCliente";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@CodServicoVinculado", codServicoVinculado));
                        cmd.ExecuteNonQuery();
                        return "serviço Reprovado";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
        }

        internal object GetServicoEtapaClienteDao( int codServico)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"PROC_S_GetServicoEtapaCliente";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@CodServico", codServico));


                        List<Etapa> Result = new List<Etapa>();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Etapa E = new Etapa();

                                E.Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0;
                                E.NomeServico = reader["NomeServico"] != DBNull.Value ? (string)reader["NomeServico"] : null;
                                E.Preco = reader["Preco"] != DBNull.Value ? (float)reader["Preco"] : 0;
                                E.NomeEtapa = reader["NomeEtapa"] != DBNull.Value ? (string)reader["NomeEtapa"] : null;
                                E.DescricaoEtapa = reader["DescricaoEtapa"] != DBNull.Value ? (string)reader["DescricaoEtapa"] : null;
                                E.Status = reader["Status"] != DBNull.Value ? (string)reader["Status"] : null;

                                Result.Add(E);
                            }
                        }
                        return Result;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
        }

        internal object AprovarServicoClienteDao(int codServicoVinculado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"PROC_I_AprovarServicoCliente";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@CodServicoVinculado", codServicoVinculado));
                        cmd.ExecuteNonQuery();
                        return "serviço aprovado com sucesso";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
        }

        internal object GetServicoClienteDao(int clienteID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"PROC_S_GetServicoCliente";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@CodCliente", clienteID));

                        List<Servico> Result = new List<Servico>(); 

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Servico S = new Servico();

                                S.ServicoVinculadoID = reader["ServicoVinculadoID"] != DBNull.Value ? (int)reader["ServicoVinculadoID"] : 0;
                                S.NomeServico = reader["NomeServico"] != DBNull.Value ? (string)reader["NomeServico"] : null;
                                S.Preco = reader["Preco"] != DBNull.Value ? (float)reader["Preco"] : 0;
                                S.Status = reader["Status"] != DBNull.Value ? (string)reader["Status"] : null;

                                Result.Add(S);
                            }
                        }
                        return Result;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
        }
    }

}
