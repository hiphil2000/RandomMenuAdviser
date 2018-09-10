using System;
using System.Net.NetworkInformation;
using System.ServiceModel;
using ServiceLibrary.Service;

namespace RandomMenuAdvisor_Service
{
    /// <summary>
    /// 서비스를 핸들링하는 클래스입니다.
    /// </summary>
    public class Service
    {
        // 서비스 호스트 변수입니다.
        private ServiceHost host;

        // 서비스 상태 내부 변수입니다.
        private bool isRunning;

        //서비스 상태 내부 변수 접근자 입니다.
        public bool IsRunning { get { return isRunning; } }

        /// <summary>
        /// 서비스를 시작하는 메소드입니다.
        /// </summary>
        public bool StartService()
        {
            // 현재 로컬의 IP주소입니다.
            string localAddress = null;

            // 현재 로컬의 IP주소를 얻어냅니다.
            foreach (NetworkInterface net in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (net.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || net.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in net.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            localAddress = ip.Address.ToString();
                        }
                    }
                }
            }
            try
            {
                // 호스트를 초기화합니다.
                host = new ServiceHost(typeof(MenuAdvisor),
                                    new Uri("http://" + localAddress + ":5000/wcf/example/randommenuadvisor_service"));

                // 호스트를 시작합니다.
                host.Open();
                // isRunning을 true로 바꿈으로써, 서비스가 실행중임을 알립니다.
                isRunning = true;
                return true;
            } catch(AddressAlreadyInUseException ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// 서비스를 종료하는 메소드입니다.
        /// </summary>
        public bool StopService()
        {
            // 호스트를 종료합니다.
            if(host != null)
                host.Close();
            // isRunning을 false로 바꿈으로써, 서비스가 종료됐을 알립니다.
            isRunning = false;
            return true;
        }
    }
}