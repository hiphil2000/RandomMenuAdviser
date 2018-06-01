using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace ServiceLibrary
{
    [ServiceContract(Namespace = "http://192.168.1.69/wcf/MenuAdvisorService")]
    public interface IMenuAdvisor
    {
        [OperationContract]
        void DatabaseConnectionTest();

        [OperationContract]
        DataTable GetRandomRequestedData(int data_length);

        [OperationContract]
        DataTable GetCategoryData();

        [OperationContract]
        DataTable GetFoodData();

        [OperationContract]
        DataTable GetPercentageData(string category);

        [OperationContract]
        void SetRandomRequestedData(DateTime random_date, string random_category_name, string random_food_name);
    }

    public class MenuAdvisorService : IMenuAdvisor
    {
        DatabaseService ds;
        
        MenuAdvisorService()
        {
            ds = new DatabaseService();
        }

        public DataTable GetCategoryData()
        {
            return ds.GetCategoryData();
        }

        public void DatabaseConnectionTest()
        {
            ds.DatabaseConnectionTest();
        }

        public DataTable GetFoodData()
        {
            return ds.GetFoodData();
        }

        public DataTable GetRandomRequestedData(int data_length)
        {
            return ds.GetRandomRequestedData(data_length);
        }

        public DataTable GetPercentageData(string category)
        {
            return ds.GetPercentageData(category);
        }

        public void SetRandomRequestedData(DateTime random_date, string random_category_name, string random_food_name)
        {
            ds.SetRandomRequestedData(random_date, random_category_name, random_food_name);
        }
    }
    
}
