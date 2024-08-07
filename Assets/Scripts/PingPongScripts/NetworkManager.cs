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
        PlayerSpawn();
        BallSpawn();
        Debug.Log("Success Join"); // Test
    }
    public void PlayerSpawn()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
    public void BallSpawn()
    {
        PhotonNetwork.Instantiate("ball", Vector3.zero, Quaternion.identity);
        
    }
    /* public void BallDestory()
    {
        PhotonNetwork.Destroy("ball");
    }
    */
    public override void OnDisconnected(DisconnectCause cause) // ���� ����
    {
        
    }


    void Start()
    {
        
    }



    void Update()
    {
        
    }
}
