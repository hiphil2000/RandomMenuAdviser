using System;
using System.ServiceModel;
using ServiceLibrary;

namespace RandomMenuAdvisor_Service
{
    public class Service
    {
        private ServiceHost host;
        private bool isRunning;

        public bool IsRunning { get => isRunning; }

        public Service()
        {
            
        }

        public bool StartService()
        {
            host = new ServiceHost(typeof(MenuAdvisorService),
                                    new Uri("http://192.168.1.69/wcf/example/RandomMenuAdvisor_Service"));

            host.AddServiceEndpoint(
                typeof(IMenuAdvisor),
                new BasicHttpBinding(),
                "");

            

            host.Open();
            isRunning = true;
            return true;

        }

        public bool StopService()
        {
            host.Close();
            isRunning = false;
            return true;
        }
    }
}