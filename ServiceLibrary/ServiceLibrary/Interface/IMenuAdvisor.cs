using ServiceLibrary.Model;
using System;
using System.Data;
using System.ServiceModel;

namespace ServiceLibrary.Interface
{
    [ServiceContract]
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
        FoodData GetRandomResult();
    }
}
