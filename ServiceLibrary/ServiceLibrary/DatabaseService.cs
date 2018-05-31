using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class DatabaseService
    {
        private SqlConnection conn;                 // 데이터베이스 연결 변수
        private bool isRunning;                     // 데이터베이스 연결 가능여부 변수
        public bool IsRunning { get => isRunning; } // 데이터베이스 연겨 가능여부 변수 외부참조용

        public DatabaseService()
        {
            string connectionString = "Data Source=192.168.1.69,1433;Integrated Security=False;User ID=sa;Password=p@ssw0rd;Database=RandomMenuAdvisor; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connectionString);
        }

        /// <summary>
        /// 데이터베이스에 연결이 가능한지 테스트하는 메소드입니다.
        /// </summary>
        void ConnectTest()
        {
            if (conn.State == ConnectionState.Open)
                isRunning = true;
            else if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    isRunning = true;
                }
                catch (Exception ex)
                {
                    if (conn != null)
                        conn.Close();
                    isRunning = false;
                }
            }
            else
            {
                isRunning = false;
            }
            Console.WriteLine(isRunning.ToString());
        }

        /// <summary>
        /// 데이터베이스 연결 확인 메소드입니다.
        /// 스레드를 통해 데이터베이스 연결을 확인합니다.
        /// </summary>
        public void DatabaseConnectionTest()
        {
            Thread connect = new Thread(new ThreadStart(ConnectTest));
            connect.Start();

        }
        /// <summary>
        /// 데이터베이스에서 현재까지 뽑은 랜덤 정보를 DataTable 형식으로 받아옵니다.
        /// </summary>
        /// <returns>랜덤 메뉴 정보</returns>
        public DataTable GetRandomRequestedData()
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = @"select
                                    tr.random_index, tr.random_date, tr.random_category_name, tr.random_food_name
                                from
                                    RandomMenuAdvisor.dbo.tb_random tr,
                                    RandomMenuAdvisor.dbo.tb_category tc,
	                                RandomMenuAdvisor.dbo.tb_food tf
                                where
                                    tr.random_food_name = tf.food_name AND
                                    tr.random_category_name = tc.category_name";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("RandomRequestedData");
                data.Load(sdr);

                return data;

            } catch(SqlException ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 음식들의 정보를 DataTable 형식으로 받아옵니다.
        /// </summary>
        /// <returns>음식 정보</returns>
        public DataTable GetFoodData()
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = @"select
                                        tc.category_name, tf.food_name
                                    from
                                        RandomMenuAdvisor.dbo.tb_category tc,
	                                    RandomMenuAdvisor.dbo.tb_food tf
                                    where
                                        tf.food_category_name = tc.category_name";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("FoodList");
                data.Load(sdr);

                return data;

            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 카테고리의 정보를 DataTable형식으로 반환합니다.
        /// </summary>
        /// <returns>카테고리 정보</returns>
        public DataTable GetCategoryData()
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = "select "+
                                        "category_name "+
                                    "from "+
                                        "dbo.tb_category";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("CategoryList");
                data.Load(sdr);

                return data;

            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}
