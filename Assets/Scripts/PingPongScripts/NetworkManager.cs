using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField NickNameInput;
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
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }
    public override void OnJoinedRoom() // �濡 �����ϸ� OnConnectedToMaster�� Callback���� ȣ��
    {
        
        Debug.Log("Success Join"); // Test
    }

    void Start()
    {
        
    }



    void Update()
    {
        
    }
}
