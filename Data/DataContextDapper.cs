using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HelloWorld.Data {
    public class DataContextDapper {
        private string _connectionString = "Data Source=ASHUTOSH\\SQLEXPRESS;Initial Catalog=DOTNETCOURSE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public IEnumerable<T> LoadData<T>(string sql) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql) > 0;
        }   

        public int ExecuteSqlWithCount(string sql) {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
    }
}   