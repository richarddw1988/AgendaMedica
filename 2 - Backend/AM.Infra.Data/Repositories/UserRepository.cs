using AM.Domain.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using AM.Infra.Data.Context;
using AM.Domain.Interface;

namespace AM.Infra.Data.Repositories
{
  public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
    public UserRepository(DatabaseContext context) : base(context) { }

    //public void Teste1()
    //{
    //  string id = "valor";

    //  using (var context = new Context.DatabaseContext())
    //  {
    //      var conn = context.Database.GetDbConnection();

    //      using (DbCommand cmd = conn.CreateCommand())
    //      {
    //          cmd.CommandText = "EXECUTE Funcao(@id)";
    //          cmd.CommandType = CommandType.Text;         //CommandType.StoredProcedure / CommandType.TableDirect

    //          cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
    //          //cmd.Parameters["@id"].Value = id;

    //          var value = (DateTime) cmd.ExecuteScalar();
    //      }
    //  }
    //}
  }
}
