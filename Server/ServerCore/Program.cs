using System;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Text;

namespace ServerCore
{
    class Program
    {
        static Listener _listener = new Listener();

        static void OnAcceptHandler(Socket clientSocket)
        {
            try
            {
                // 받는다
                // 손님이 보내준 데이터는 recvBuff에 저장된다.
                byte[] recvBuff = new byte[1024];
                int recvBytes = clientSocket.Receive(recvBuff); // Blocking 함수

                // recvBuffer에 받은 값을 String으로 변환해준다. 
                // 두번째 인자는 데이터 받을 시작 인덱스
                // 세번째 인자는 몇 바이트를 받을 것인지
                string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                Console.WriteLine($"[From Clinet] {recvData}");

                // 보낸다
                byte[] sendBuff = Encoding.UTF8.GetBytes("Welcome to MMORPG Server !");
                clientSocket.Send(sendBuff); // Blocking 함수

                // 쫓아낸다. 
                clientSocket.Shutdown(SocketShutdown.Both); // 듣기도 싫고 말하기도 싫다.
                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
             
        }

       static void Main(string[] args)
        {
            // DNS (Domain Name System ) 
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];

            // 첫번째 인자는 ip : 식당 이름
            // 두번째 인자는 포트번호 : 식당 정문인지 후문인지
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            _listener.init(endPoint, OnAcceptHandler);

            while (true)
            {
                    
            }
      
        }
    }
}


