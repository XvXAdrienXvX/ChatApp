using AuthGateway.Database;
using AuthGateway.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AuthGateway.Repositories
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(AuthDatabaseContext context) : base(context)
        {

        }
        public async Task<Users> CreateUserWithRole(Users entity)
        {
             int userId = await ExecuteStoredProcedureAsync("createUserWithDefaultRole"
                                ,new SqlParameter("username", entity.Username)
                                ,new SqlParameter("email", entity.Email)
                                ,new SqlParameter("password_hash", entity.PasswordHash)
                                ,new SqlParameter("avatar_url", entity.AvatarUrl)     
                                );

            if (userId == 0)
            {
                throw new Exception("User not created");
            }

            var newUser = await base.FindByConditionAsync(usr => usr.Id == userId).FirstOrDefaultAsync();
            return newUser;
        }

        private async Task<int> ExecuteStoredProcedureAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            try
            {
                // Construct the SQL command text with parameter placeholders
                var parameterNames = string.Join(",", parameters.Select(p => $"@{p.ParameterName}"));
                var commandText = $"EXEC {storedProcedureName} {parameterNames}, @userId OUTPUT";

                // Add output parameter for the return value (generated ID)
                var outputParameter = new SqlParameter("@userId", SqlDbType.Int);
                outputParameter.Direction = ParameterDirection.Output;
                parameters = parameters.Append(outputParameter).ToArray();

                // Execute the stored procedure
                await authContext.Database.ExecuteSqlRawAsync(commandText, parameters);

                // Get the output parameter value (generated ID)
                int userId = (int)outputParameter.Value;
                return userId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing stored procedure", ex);
            }
        }

    }
}
