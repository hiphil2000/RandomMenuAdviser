using System;
using System.Collections;
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
        private SqlConnection conn;                         // 데이터베이스 연결 변수입니다.
        private bool isRunning;                             // 데이터베이스 연결 가능여부 변수입니다.
        public bool IsRunning { get { return isRunning; } } // 데이터베이스 연결 가능여부 프로퍼티입니다.

        public Database()
        {
            string connectionString = "Data Source=192.168.0.36,1433;Integrated Security=False;User ID=sa;Password=p@ssw0rd;Database=RandomMenuAdvisor;" +
                " Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connectionString);
        }

        /// <summary>
        /// 데이터베이스에 연결이 가능한지 테스트하는 메소드입니다. 
        /// </summary>
        void ConnectTest()
        {
            switch(conn.State)
            {
                case ConnectionState.Open:
                    isRunning = true;
                    break;
                case ConnectionState.Connecting:
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
                        break;
                case ConnectionState.Closed:
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
                        throw ex;
                    }
                    break;
            }
        }

        
        /// <summary>
        /// 프로시저에서 값을 받아오는 메소드입니다.
        /// </summary>
        /// <param name="procedureName">프로시저 명</param>
        /// <param name="tableName">결과 테이블 명</param>
        /// <param name="parameters">프로시저 매개변수</param>
        /// <returns>결과 테이블</returns>
        private DataTable GetDataWithProcedure(string procedureName, string tableName, params Model.SqlParameter[] parameters)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = procedureName;
                if(parameters != null)
                {
                    foreach (Model.SqlParameter param in parameters)
                    {
                        com.Parameters.AddWithValue("@" + param.ParameterName, param.ParameterValue);
                    }
                }
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable(tableName);
                data.Load(sdr);

                return data;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 프로시저로 데이터베이스에 값을 설정하는 메소드입니다.
        /// </summary>
        /// <param name="procedureName">프로시저 명</param>
        /// <param name="parameters">프로시저 매개변수</param>
        private void SetDataWithProcedure(string procedureName, params Model.SqlParameter[] parameters)
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = conn;
                com.CommandText = procedureName;
                foreach (Model.SqlParameter param in parameters)
                {
                    com.Parameters.AddWithValue("@" + param.ParameterName, param.ParameterValue);
                }
                conn.Open();

                com.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 클라이언트에서 뽑은 랜덤 메뉴 값을 업데이트 및 삽입합니다.
        /// </summary>
        /// <param name="random_requested_date">메뉴를 정한 시간입니다.</param>
        /// <param name="random_category_name">카테고리</param>
        /// <param name="random_food_name">음식 명</param> 
        internal void SetRandomRequestedData(DateTime random_requested_date, string random_category_name, string random_food_name)
        {
            try
            {
                Model.SqlParameter[] parameters = new Model.SqlParameter[]
                {
                    new Model.SqlParameter("random_requested_date", random_requested_date.ToString("yyyy-MM-dd HH:mm:ss")),
                    new Model.SqlParameter("random_category_name", random_category_name),
                    new Model.SqlParameter("random_food_name", random_food_name)
                };
                SetDataWithProcedure("[dbo].[sp_insert_or_update_data]", parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 하나 혹은 모든 카테고리의 전체 대비 비율을 구합니다.
        /// </summary>
        /// <param name="category">카테고리의 이름 (0: 모두, 1: 한 달, 2: 두 달...)</param>
        /// <returns>카테고리 비율</returns>
        internal DataTable GetPercentageData(int data_length)
        {
            try
            {
                Model.SqlParameter parameter = new Model.SqlParameter("data_length", data_length);
                DataTable data = GetDataWithProcedure("[dbo].[sp_categoryPercentage]", "카테고리 비율", parameter);
                return data;
            }
            catch (SqlException ex)
            {
                throw ex;
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
        /// <param name="data_length">받아올 데이터의 범위 (0: 모두, 1: 한 달, 2: 두 달...)</param>
        /// <returns>랜덤 메뉴 정보</returns>
        public DataTable GetRandomRequestedData(int data_length)
        { 
            try
            {
                Model.SqlParameter parameter = new Model.SqlParameter("data_length", data_length);
                DataTable data = GetDataWithProcedure("[dbo].[sp_get_random_data]", "랜덤 음식 데이터", parameter);
                return data;
            }
            catch (SqlException ex)
            {
                throw ex;
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
                DataTable data = GetDataWithProcedure("[dbo].[sp_get_food_data]", "음식 리스트", null);
                return data;
            }
            catch (SqlException ex)
            {
                throw ex;
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
                DataTable data = GetDataWithProcedure("[dbo].[sp_get_category_data]", "카테고리 리스트", null);
                return data;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
