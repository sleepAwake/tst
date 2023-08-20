using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    InputField createinput, joininput;

    public void CreateRoom()
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(createinput.text, room);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joininput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
