﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace RandomMenuAdvisor.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://192.168.1.69/wcf/MenuAdvisorService", ConfigurationName="ServiceReference1.IMenuAdvisor")]
    public interface IMenuAdvisor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/test", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/testResponse")]
        string test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/test", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/testResponse")]
        System.Threading.Tasks.Task<string> testAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/DatabaseConnectionTest", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/DatabaseConnectionTestRes" +
            "ponse")]
        void DatabaseConnectionTest();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/DatabaseConnectionTest", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/DatabaseConnectionTestRes" +
            "ponse")]
        System.Threading.Tasks.Task DatabaseConnectionTestAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetRandomRequestedData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetRandomRequestedDataRes" +
            "ponse")]
        System.Data.DataTable GetRandomRequestedData(int data_length);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetRandomRequestedData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetRandomRequestedDataRes" +
            "ponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetRandomRequestedDataAsync(int data_length);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetCategoryData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetCategoryDataResponse")]
        System.Data.DataTable GetCategoryData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetCategoryData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetCategoryDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetCategoryDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetFoodData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetFoodDataResponse")]
        System.Data.DataTable GetFoodData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetFoodData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetFoodDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetFoodDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetPercentageData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetPercentageDataResponse" +
            "")]
        System.Data.DataTable GetPercentageData(string category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetPercentageData", ReplyAction="http://192.168.1.69/wcf/MenuAdvisorService/IMenuAdvisor/GetPercentageDataResponse" +
            "")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetPercentageDataAsync(string category);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMenuAdvisorChannel : RandomMenuAdvisor.ServiceReference1.IMenuAdvisor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MenuAdvisorClient : System.ServiceModel.ClientBase<RandomMenuAdvisor.ServiceReference1.IMenuAdvisor>, RandomMenuAdvisor.ServiceReference1.IMenuAdvisor {
        
        public MenuAdvisorClient() {
        }
        
        public MenuAdvisorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MenuAdvisorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuAdvisorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MenuAdvisorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string test() {
            return base.Channel.test();
        }
        
        public System.Threading.Tasks.Task<string> testAsync() {
            return base.Channel.testAsync();
        }
        
        public void DatabaseConnectionTest() {
            base.Channel.DatabaseConnectionTest();
        }
        
        public System.Threading.Tasks.Task DatabaseConnectionTestAsync() {
            return base.Channel.DatabaseConnectionTestAsync();
        }
        
        public System.Data.DataTable GetRandomRequestedData(int data_length) {
            return base.Channel.GetRandomRequestedData(data_length);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetRandomRequestedDataAsync(int data_length) {
            return base.Channel.GetRandomRequestedDataAsync(data_length);
        }
        
        public System.Data.DataTable GetCategoryData() {
            return base.Channel.GetCategoryData();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetCategoryDataAsync() {
            return base.Channel.GetCategoryDataAsync();
        }
        
        public System.Data.DataTable GetFoodData() {
            return base.Channel.GetFoodData();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetFoodDataAsync() {
            return base.Channel.GetFoodDataAsync();
        }
        
        public System.Data.DataTable GetPercentageData(string category) {
            return base.Channel.GetPercentageData(category);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetPercentageDataAsync(string category) {
            return base.Channel.GetPercentageDataAsync(category);
        }
        
    }
}