using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class DatabaseService
    {
        private SqlConnection conn; // 데이터베이스 연결 변수

        public DatabaseService()
        {
            string connectionString = "server=192.168.1.69; uid=sa; pwd=p@ssw0rd; database:RandomMenuAdvisor";
            conn = new SqlConnection(connectionString);
        }

        public bool GetDatabaseStatus()
        {
            if (conn.State == ConnectionState.Open)
                return true;
            else if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                } catch(SqlException ex)
                {
                    conn.Close();
                    return false;
                }
            }
            else
                return false;
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
                                    tb_random tr,
                                    tb_category tc,
	                                tb_food tf
                                where
                                    tr.random_food_name = tf.food_name AND
                                    tr.random_category_name = tc.category_name";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable();
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
                                        tb_category tc,
	                                    tb_food tf
                                    where
                                        tf.food_category_name = tc.category_name";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable();
                data.Load(sdr);

                return data;

            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public DataTable GetCategoryData()
        {
            try
            {
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandText = @"select
                                        tc.category_name
                                    from
                                        tb_category tc";
                conn.Open();

                SqlDataReader sdr = com.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable();
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
