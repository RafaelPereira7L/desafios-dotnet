using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP
{
    internal class Produto
    {
        public int idFornecedor { get; set;}
        public string Nome { get; set; }

        public bool cadastrarProduto()
        {
            Banco banco = new Banco();

            SqlConnection cn = banco.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();

            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into produtos " +
                "values (@idFornecedor, @nome);";
            command.Parameters.Add("@idFornecedor", SqlDbType.Int);
            command.Parameters.Add("@nome", SqlDbType.VarChar);
            command.Parameters[0].Value = idFornecedor;
            command.Parameters[1].Value = Nome;

            try
            {
                command.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                banco.fecharConexao();
            }
        }
            public Produto filtrarProdutos()
            {
                Banco bd = new Banco();

                try
                {
                    SqlConnection cn = bd.abrirConexao();
                    SqlCommand command = new SqlCommand("select * from produtos",
                        cn);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Nome = reader.GetString(1);
                        return this;
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    bd.fecharConexao();
                }
            }
    }
}
