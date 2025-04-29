using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

using DummyClient;
using ServerCore;


public class NetworkManager : MonoBehaviour
{
    private ServerSession _session = new ServerSession();

    // Start is called before the first frame update
    void Start()
    {
        // DSN (Domain Name System)
        // �̸����� IP �ּҸ� ã��
        string host = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(host);
        IPAddress ipAddr = ipHost.AddressList[0];  // ù��°�� ã�� �ּҸ� �Ҵ�
        IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

        Connector connector = new Connector();

        connector.Connect(endPoint,
            () => { return _session; },
            1);
    }

    // Update is called once per frame
    void Update()
    {
        IPacket packet = PacketQueue.Instance.Pop();
        if(packet != null)
        {
            PacketManager.Instance.HandlePacket(_session, packet);
        }
    }
}
