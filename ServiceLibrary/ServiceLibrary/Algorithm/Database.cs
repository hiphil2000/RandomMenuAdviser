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
    public class Database
    {
        private SqlConnection conn;                 // 데이터베이스 연결 변수
        private bool isRunning;                     // 데이터베이스 연결 가능여부 변수
        public bool IsRunning { get => isRunning; } // 데이터베이스 연결 가능여부 변수 외부참조용

        public Database()
        {
            string connectionString = "Data Source=192.168.1.3,1433;Integrated Security=False;User ID=sa;Password=p@ssw0rd;Database=RandomMenuAdvisor; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            else if(conn.State == ConnectionState.Connecting)
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
            Console.WriteLine(isRunning.ToString());
        }

        /// <summary>
        /// 클라이언트에서 뽑은 랜덤 메뉴 값을 업데이트 및 삽입합니다.
        /// </summary>
        /// <param name="random_date">메뉴를 정한 시간입니다.</param>
        /// <param name="random_category_name">카테고리</param>
        /// <param name="random_food_name">음식 명</param>
        internal void SetRandomRequestedData(DateTime random_date, string random_category_name, string random_food_name)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = "[dbo].[sp_insert_or_update_data]";
                com.Parameters.AddWithValue("@random_date", random_date);
                com.Parameters.AddWithValue("@random_category_name", random_category_name);
                com.Parameters.AddWithValue("@random_food_name", random_food_name);
                conn.Open();

                com.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
        }

        /// <summary>
        /// 하나 혹은 모든 카테고리의 전체 대비 비율을 구합니다.
        /// </summary>
        /// <param name="category">카테고리의 이름입니다. 빈 string : 전체 카테고리, 카테고리 이름: 해당 카테고리</param>
        /// <returns>카테고리 비율</returns>
        internal DataTable GetPercentageData(string category)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = "[dbo].[sp_categoryPercentage]";
                com.Parameters.AddWithValue("@category", category);
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("카테고리 비율");
                data.Load(sdr);

                return data;

            }
            catch (SqlException ex)
            {
                return null;
            }
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
        /// <param name="data_length">받아올 데이터의 범위입니다. 0: 모두, 1~: 월 단위만큼 </param>
        /// <returns>랜덤 메뉴 정보</returns>
        public DataTable GetRandomRequestedData(int data_length)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = "[dbo].[sp_get_random_data]";
                com.Parameters.AddWithValue("@data_length", data_length);
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("랜덤 음식 데이터");
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
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = @"[dbo].[sp_get_food_data]";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("음식 리스트");
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
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = "[dbo].[sp_get_category_data]";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable("카테고리 리스트");
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
