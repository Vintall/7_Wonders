using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    #region UIFields
    [SerializeField] GameObject text;
    [SerializeField] LobbyUI lobby_ui;
    #endregion

    bool is_connected_to_master;
    AllLobbyPlayers room_players;
    string room_name;

    void Start()
    {
        room_players = new AllLobbyPlayers();
        is_connected_to_master = false;

        PhotonNetwork.NickName = System.DateTime.Now.Second.ToString();
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();


        Log(PhotonNetwork.NickName);
        
        Screen.SetResolution(700, 400, false);
    }

    #region BUTTONS
    public void CreateRoomButton() //Игрок нажимает кнопку "CreateRoom"
    {
        if (!is_connected_to_master) 
            return;

        CreateRoom();
    }
    public void JoinRandomRoomButton() //Игрок нажимает кнопку "JoinRandom"
    {
        if (!is_connected_to_master) 
            return;
        
        lobby_ui.JoinRandomRoom();
    }
    public void JoinRoomButton() //Игрок нажимает кнопку "JoinRoom"
    {
        if (!is_connected_to_master) 
            return;

        JoinRoom();

        //lobby_ui.JoinRoomButton();
    }
    public void LeftRoomButton() //Игрок закрывает "Room Panel"
    {
        if(!PhotonNetwork.InRoom)
        {
            lobby_ui.BackToMainMenu();
            return;
        }
        PhotonNetwork.LeaveRoom();
    }
    public void StartButtonPressed()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        StartGame(); //REMOVE // TEST
        
        if (room_players.IsAllPlayersReady)
        {
            Debug.Log("Successfully started the game");
            //StartGame();
        }
    }
    void StartGame()
    {
        
        PhotonNetwork.LoadLevel("Game");
    }
    public void ReadyButtonPressed()
    {
        room_players.ChangeSeldReadyState();

        if (room_players.IsSelfReady)
            lobby_ui.RoomPanel.ReadyButton.GetComponent<UnityEngine.UI.Image>().color = Color.green;
        else
            lobby_ui.RoomPanel.ReadyButton.GetComponent<UnityEngine.UI.Image>().color = Color.red;

        for (int i = 0; i < lobby_ui.RoomPanel.PlayerSlots.PlayerField.Length; i++)
        {
            if (lobby_ui.RoomPanel.PlayerSlots.PlayerField[i].Player.UserId == PhotonNetwork.LocalPlayer.UserId) //REMOVE
            {
                lobby_ui.RoomPanel.PlayerSlots.PlayerField[i].ChangeReadyMarkColor(lobby_ui.RoomPanel.ReadyButton.GetComponent<UnityEngine.UI.Image>().color);  //REMOVE
                break;
            }
        }
    }
    private void Update()
    {
        //if (room_players.IsSelfReady)
        //    lobby_ui.RoomPanel.ReadyButton.GetComponent<UnityEngine.UI.Image>().color = Color.green;
        //else
        //    lobby_ui.RoomPanel.ReadyButton.GetComponent<UnityEngine.UI.Image>().color = Color.red;
    }
    #endregion
    #region PHOTON.CALLBACKS
    public override void OnJoinedLobby() //Joined to lobby on MacterServer
    {

    }
    public override void OnConnectedToMaster()
    {
        lobby_ui.ButtonsPanel.gameObject.SetActive(true);
        is_connected_to_master = true;
        Log("Connected to Master");
    }
    
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        room_players.AddPlayer(newPlayer);
        lobby_ui.RoomPanel.RefreshPlayers(room_players);
        Debug.Log(newPlayer.ActorNumber);
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log(room_players.AllPlayers.Count);
        room_players.RemovePlayer(otherPlayer);
        Debug.Log(room_players.AllPlayers.Count);
        lobby_ui.RoomPanel.RefreshPlayers(room_players);
    }
    public override void OnLeftRoom()
    {
        lobby_ui.BackToMainMenu();
    }
    public override void OnCreatedRoom()
    {
        lobby_ui.CreateRoom();
        Log(PhotonNetwork.CurrentRoom.Players.Count.ToString());
    }
    
    public override void OnJoinedRoom()
    {
        room_players = new AllLobbyPlayers(PlayersDictionaryToList(PhotonNetwork.CurrentRoom.Players));
        lobby_ui.CreateRoom();
        lobby_ui.RoomPanel.RefreshPlayers(room_players);

        PhotonNetwork.Instantiate("LobbyPlayerObject", new Vector3(Random.Range(-5, 5), 0, -7), Quaternion.identity);
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);                                                                               //Remove
    }
    #endregion
    #region METHODS
    public List<Photon.Realtime.Player> PlayersDictionaryToList(Dictionary<int, Photon.Realtime.Player> players)
    {
        List<Photon.Realtime.Player> out_players = new List<Photon.Realtime.Player>();
        foreach (KeyValuePair<int, Photon.Realtime.Player> key in players)
        {
            out_players.Add(key.Value);
        }
        return out_players;
    }
    public void InitializePlayer()
    {
        
    }
    void Log(string log)
    {
        Debug.Log(log);
        text.GetComponent<UnityEngine.UI.Text>().text += "\n" + log;
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 7, PublishUserId = true });
    }
    public void JoinRoom(RoomInfo room)
    {
        PhotonNetwork.JoinRoom(room.Name);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    #endregion
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting)
        {
            stream.SendNext(room_players.IsSelfReady);
            stream.SendNext(PhotonNetwork.LocalPlayer.UserId);
            
        }
        if (stream.IsReading)
        {
            room_players.SelfPlayerObject.IsPlayerReady = (bool)stream.ReceiveNext();
            string id = (string)stream.ReceiveNext();

        }
    }
}
