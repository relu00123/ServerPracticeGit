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

        // ù��° ���ڴ� ip : �Ĵ� �̸�
        // �ι�° ���ڴ� ��Ʈ��ȣ : �Ĵ� �������� �Ĺ�����
        IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);


        Connector connector = new Connector();

        // ���������ڴ� ��� Client�� ������ ������? �Ϲ����� �����̶�� 1���̰�����
        // �̰��� DummyClient�� �������� Client���� ��Ȳ�� üũ�ϱ����� ����Ѵ�. 
        connector.Connect(endPoint, () => { return _session;  },
             1);

        Debug.Log("NetWorkManager Activated");
    }

    void Update()
    {
        
    }
}
