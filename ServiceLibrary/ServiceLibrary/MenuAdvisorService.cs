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
        bool GetDatabaseStatus();

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

        public bool GetDatabaseStatus()
        {
            return ds.GetDatabaseStatus();
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
