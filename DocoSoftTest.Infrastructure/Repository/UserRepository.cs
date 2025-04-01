using Dapper;
using DocoSoftTest.Application.Interfaces;
using DocoSoftTest.Domain.Entities;
using DocoSoftTest.Infrastructure.Data;
using DocoSoftTest.Sql.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DocoSoftTest.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IConfiguration configuration;
        private readonly AppDbContext context;

        public UserRepository(IConfiguration configuration, AppDbContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }


        public async Task<IList<User>> GetAllAsync()
        {
            // Entity Framework
            return await context.Users.ToListAsync();
        }

        //public async Task<IReadOnlyList<User>> GetAllAsync()
        //{
        //    // Dapper Implementation of GetAllAsync
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        var result = await connection.QueryAsync<User>(UserQueries.AllUsers);

        //        return result.ToList();
        //    }
        //}

        public async Task<User> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", id, DbType.Int32);

                // Stored Procedure to retrieve User Data
                var result = await connection.QuerySingleOrDefaultAsync<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);

                if (result == null)
                {
                    throw new KeyNotFoundException($"User not found. UserId: {id}");
                }

                return result;
            }
        }

        public async Task<string> AddAsync(User entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.ExecuteAsync(UserQueries.AddUser, entity);

                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(User entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.ExecuteAsync(UserQueries.UpdateUser, entity);

                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                var result = await connection.ExecuteAsync(UserQueries.DeleteUser, new { UserId = id });

                return result.ToString();
            }
        }

    }
}
