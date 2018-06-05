using System;
using System.Data;
using ServiceLibrary.Algorithm;
using ServiceLibrary.Interface;
using ServiceLibrary.Model;

namespace ServiceLibrary.Service
{
    public class MenuAdvisor : IMenuAdvisor
    {
        private Database database;
        private RandomMenu random;
         
        MenuAdvisor()
        {
            database = new Database();
        }

        /// <summary>
        /// 카테고리의 정보를 DataTable형식으로 반환합니다.
        /// </summary>
        /// <returns>카테고리 정보</returns>
        public DataTable GetCategoryData()
        {
            return database.GetCategoryData();
        }

        /// <summary>
        /// 데이터베이스 연결 확인 메소드입니다.
        /// 스레드를 통해 데이터베이스 연결을 확인합니다.
        /// </summary>
        public void DatabaseConnectionTest()
        {
            database.DatabaseConnectionTest();
        }

        /// <summary>
        /// 음식들의 정보를 DataTable 형식으로 받아옵니다.
        /// </summary>
        /// <returns>음식 정보</returns>
        public DataTable GetFoodData()
        {
            return database.GetFoodData();
        }

        /// <summary>
        /// 데이터베이스에서 현재까지 뽑은 랜덤 정보를 DataTable 형식으로 받아옵니다.
        /// </summary>
        /// <param name="data_length">받아올 데이터의 범위입니다. 0: 모두, 1~: 월 단위만큼 </param>
        /// <returns>랜덤 메뉴 정보</returns>
        public DataTable GetRandomRequestedData(int data_length)
        {
            return database.GetRandomRequestedData(data_length);
        }

        /// <summary>
        /// 하나 혹은 모든 카테고리의 전체 대비 비율을 구합니다.
        /// </summary>
        /// <param name="category">카테고리의 이름입니다. 빈 string : 전체 카테고리, 카테고리 이름: 해당 카테고리</param>
        /// <returns>카테고리 비율</returns>
        public DataTable GetPercentageData(string category)
        {
            return database.GetPercentageData(category);
        }

        /// <summary>
        /// 랜덤 알고리즘에 따라 무작위 메뉴를 반환합니다.
        /// </summary>
        /// <returns>랜덤 메뉴</returns>
        public FoodData GetRandomResult()
        {
            throw new NotImplementedException();
        }
    }
}
