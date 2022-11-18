using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP
{
    internal class Nota
    {
        public int CodNota { get; set; }
        public int IDCliente { get; set; }
        public int IDProduto { get; set; }


        public bool cadastrarNota()
        {
            Banco banco = new Banco();

            SqlConnection cn = banco.abrirConexao();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand command = new SqlCommand();


            command.Connection = cn;
            command.Transaction = tran;
            command.CommandType = CommandType.Text;

            command.CommandText = "insert into notas " +
                "values (@CodNota, @IDCliente, @IDProduto);";
            command.Parameters.Add("@CodNota", SqlDbType.Int);
            command.Parameters.Add("@IDCliente", SqlDbType.Int);
            command.Parameters.Add("@IDProduto", SqlDbType.Int);
            command.Parameters[0].Value = CodNota;
            command.Parameters[1].Value = IDCliente;
            command.Parameters[2].Value = IDProduto;

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
        public Nota filtrarNotas()
        {
            Banco bd = new Banco();

            try
            {
                SqlConnection cn = bd.abrirConexao();
                SqlCommand command = new SqlCommand("select * from notas",
                    cn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var CodNotaString = CodNota.ToString();
                    CodNotaString = reader.GetString(1);
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
