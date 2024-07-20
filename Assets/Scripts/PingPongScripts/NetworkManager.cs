using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Screen.SetResolution(960, 540, false); // 해상도 변경 필요
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = "JinWook"; // 플레이어 닉네임으로 수정 필요
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnJoinedRoom() // 방에 접속하면 OnConnectedToMaster의 Callback으로 호출
    {
        SceneManager.LoadScene("PingPong");
        Debug.Log("Success Join"); // Test
    }

    void Start()
    {
        
    }



    void Update()
    {
        
    }
}
