using MicroCredit.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MicroCredit.Infrastructure.Repositories.CreditRepository;

namespace MicroCredit.Infrastructure.Repositories
{
    public class CreditRepository : ICreditRepository
    {
        private readonly string _connectionString;

        public CreditRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public decimal CalculateLimit(decimal rendimentoMensal)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("CalcularLimiteCredito", conn))
                {
                    // Executar a stored procedure

                    /*cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RendimentoMensal", rendimentoMensal);
                    SqlParameter limiteCreditoParam = new SqlParameter("@LimiteCredito", SqlDbType.Decimal);
                    limiteCreditoParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(limiteCreditoParam);

                    cmd.ExecuteNonQuery();

                    return (decimal)limiteCreditoParam.Value;*/

                    if (rendimentoMensal < 1000)
                        return CreditLimitConstant.Min;
                    else if (rendimentoMensal > 1000 && rendimentoMensal < 2000)
                        return CreditLimitConstant.Medium;
                    else
                        return CreditLimitConstant.Max;
                }
            }
        }
    }
}
