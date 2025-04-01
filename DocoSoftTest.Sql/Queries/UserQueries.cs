using System.Diagnostics.CodeAnalysis;

namespace DocoSoftTest.Sql.Queries
{
    [ExcludeFromCodeCoverage]
	public static class UserQueries
	{
		public static string AllUsers => "SELECT * FROM [Users] (NOLOCK)";

		public static string UserById => "SELECT * FROM [Users] (NOLOCK) WHERE [UserId] = @UserId";

		public static string AddUser =>
			@"INSERT INTO [Users] ([FirstName], [LastName], [Email], [PhoneNumber]) 
				VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

		public static string UpdateUser =>
			@"UPDATE [Users] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[Email] = @Email, 
				[PhoneNumber] = @PhoneNumber
            WHERE [UserId] = @UserId";

		public static string DeleteUser => "DELETE FROM [Users] WHERE [UserId] = @UserId";
	}
}
