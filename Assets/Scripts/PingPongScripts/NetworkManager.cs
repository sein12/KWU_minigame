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
        Screen.SetResolution(960, 540, false); // �ػ� ���� �ʿ�
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = "JinWook"; // �÷��̾� �г������� ���� �ʿ�
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnJoinedRoom() // �濡 �����ϸ� OnConnectedToMaster�� Callback���� ȣ��
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
