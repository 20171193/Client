using DummyClient;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class PacketHandler
{
    public static void S_ChatHandler(PacketSession session, IPacket packet)
    {
        S_Chat chatPacket = packet as S_Chat;
        ServerSession serverSession = session as ServerSession;

        if (chatPacket.playerId == 1)
        { 
            Debug.Log(chatPacket.chat);

            // 유니티에서 유니티 메인스레드가 아닌
            // 타 스레드에서의 유니티 오브젝트 접근을 차단.
            GameObject go = GameObject.Find("Player");
            if (go == null)
                Debug.Log("Player not found");
            else
                Debug.Log("Player found");
        }
        //if (chatPacket.playerId == 1)
            //Console.WriteLine(chatPacket.chat);

    }
}
