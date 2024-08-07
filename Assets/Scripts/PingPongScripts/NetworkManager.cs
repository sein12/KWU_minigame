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
        Screen.SetResolution(960, 540, false); // 해상도 변경 필요
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
    public override void OnJoinedRoom() // 방에 접속하면 OnConnectedToMaster의 Callback으로 호출
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
    public override void OnDisconnected(DisconnectCause cause) // 연결 해제
    {
        
    }


    void Start()
    {
        
    }



    void Update()
    {
        
    }
}
