using ServerCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : Player
{
    private NetworkManager _network;

    private void Start()
    {
        StartCoroutine(CoSendPacket());
        _network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
    }

    IEnumerator CoSendPacket()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            C_Move movePacket = new C_Move();
            movePacket.posX = UnityEngine.Random.Range(-50, 50);
            movePacket.posY = 0;
            movePacket.posZ = UnityEngine.Random.Range(-50, 50);

            _network.Send(movePacket.Write());
        }
    }
}
