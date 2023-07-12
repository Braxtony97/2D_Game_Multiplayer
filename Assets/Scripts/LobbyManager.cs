using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField InputNickname;
    [SerializeField] private TMP_InputField _roomCreate;
    [SerializeField] private TMP_InputField _roomJoin;

    private void Start()
    {
        InputNickname.text= PlayerPrefs.GetString("Name");
        PhotonNetwork.NickName = InputNickname.text;
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(_roomCreate.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_roomJoin.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("name", InputNickname.text);
        PhotonNetwork.NickName = InputNickname.text;
    }
}
