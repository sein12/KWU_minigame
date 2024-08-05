using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Screen.SetResolution(960, 540, false); // �ػ� ���� �ʿ�
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        if (!(PhotonNetwork.IsConnected))
            Connect();
    }
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnJoinedRoom() // �濡 �����ϸ� OnConnectedToMaster�� Callback���� ȣ��
    {
        Spawn();
        Debug.Log("Success Join"); // Test
    }
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);

    }

    void Start()
    {
        
    }



    void Update()
    {
        
    }
}
