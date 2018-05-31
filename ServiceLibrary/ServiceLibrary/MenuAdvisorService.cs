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
        string test();

        [OperationContract]
        void DatabaseConnectionTest();

        [OperationContract]
        DataTable GetRandomRequestedData();

        [OperationContract]
        DataTable GetCategoryData();

        [OperationContract]
        DataTable GetFoodData();

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

        public DataTable GetRandomRequestedData()
        {
            return ds.GetRandomRequestedData();
        }

        public string test()
        {
            return "test";
        }
    }
    
}
