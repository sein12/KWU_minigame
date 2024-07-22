using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class PlayerControl : MonoBehaviourPunCallbacks, IPunObservable
{
    public Vector2 InputVec;
    public Rigidbody2D RB;
    public PhotonView PV;
    public Collider2D CD;
    public TextMeshProUGUI NickNameText;
    public Transform UiJoyStick;

    void Awake()
    {
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        NickNameText.color = PV.IsMine ? Color.green : Color.red;
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    void FixedUpdate()
    {
        Vector2 nextVec = InputVec * Time.fixedDeltaTime * 3;
        RB.MovePosition(RB.position + nextVec);
    }

    void OnMove(InputValue value)
    {
            InputVec = value.Get<Vector2>();
    }


    void Start()
    {
        
    }


    

    void Update()
    {
        
    }
}
