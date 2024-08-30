using ConsoleDotNetFramework.UnitTest;
using System.Data.SqlClient;

namespace ConsoleDotNetFrameworkTests.UnitTest
{
    public class SampleClassTests
    {
        [Fact]
        public void CreateSqlExceptionTest()
        {
            // Arrange            
            var target = new SampleClass();
 
            
            // Act


            // Assert
            
        }

        /// <summary>
        /// SqlExceptionはPublicなコンストラクタを持たないため生成して取得する
        /// SqlExceptionをThrowするメソッドを呼び出す
        /// </summary>
        /// <returns></returns>
        private SqlException CreateSqlException()
        {
            SqlException exception = null;

            try
            {
                // 意図的に不正な接続文字列を指定して例外を発生させる
                var conn = new SqlConnection(@"Data Source=.;Database=TEST;Connection Timeout=1");
                conn.Open();
            }
            catch (SqlException ex)
            {
                exception = ex;
            }
            
            return exception;
        }
    }
}