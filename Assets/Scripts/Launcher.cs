using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    public Joystick joystick;
    public Image TalkWithNpc;
    public Image Fire;
    public Image HeadFrame;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Welcome Wuming77");

        PhotonNetwork.JoinOrCreateRoom("Wuming77", new Photon.Realtime.RoomOptions() { MaxPlayers = 4 }, default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        joystick.gameObject.SetActive(true);
        HeadFrame.gameObject.SetActive(true);
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0), Quaternion.identity, 0);
        Fire.gameObject.SetActive(true);
        TalkWithNpc.gameObject.SetActive(true);
    }
}
