    using System;
using Microsoft.Data.SqlClient;

namespace DocoSoftTest.Test.Helper
{
    public static class TestConstants
    {
        public static SqlException GetSqlException()
        {
            var sqlException = System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject(typeof(SqlException)) as SqlException;

            return sqlException;
        }

        public static Exception GetGeneralException()
        {
            return new Exception("Test Exception");
        }

        public static class UserTest
        {
            private static readonly Random random = new();
            private static readonly int randomNumber = random.Next();

            public static string FirstName = $"Terry{randomNumber}";
            public static string LastName = $"Delahunt{randomNumber}";
            public static string Email = "terrydelahunt@hotmail.com";
            public static string PhoneNumber = "0861921808";
            public static string NewEmail = "terry.delahunt@gmail.com";
        }
    }
}
