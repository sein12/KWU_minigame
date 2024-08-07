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
    public Transform UiJoyStick;

    void Awake()
    {
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    void FixedUpdate()
    {
        Vector2 nextVec = InputVec * Time.fixedDeltaTime * 10;
        RB.MovePosition(RB.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        if (PV.IsMine)
            InputVec = value.Get<Vector2>();
    }


    void Start()
    {
        
    }


    

    void Update()
    {
        
    }
}
