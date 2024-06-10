using DummyClient;
using ServerCore;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    ServerSession _session = new ServerSession();

    void Start()
    {
        // DNS (Domain Name System ) 
        string host = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(host);
        IPAddress ipAddr = ipHost.AddressList[0];

        // 첫번째 인자는 ip : 식당 이름
        // 두번째 인자는 포트번호 : 식당 정문인지 후문인지
        IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);


        Connector connector = new Connector();

        // 마지막인자는 몇개의 Client가 접속할 것인지? 일반적인 게임이라면 1개이겠지만
        // 이것은 DummyClient로 여러개의 Client접속 상황을 체크하기위해 사용한다. 
        connector.Connect(endPoint, () => { return _session;  },
             1);

        Debug.Log("NetWorkManager Activated");
    }

    void Update()
    {
        
    }
}
