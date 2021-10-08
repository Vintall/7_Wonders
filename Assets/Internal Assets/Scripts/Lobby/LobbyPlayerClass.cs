using System.Collections;
using System.Collections.Generic;

public class LobbyPlayerClass
{
    Photon.Realtime.Player network_player;
    bool is_player_ready;
    UnityEngine.Sprite player_icon;
    byte number_in_room;

    public Photon.Realtime.Player NetworkPlayer
    {
        get
        {
            return network_player;
        }
    }
    public bool IsPlayerReady
    {
        get
        {
            return is_player_ready;
        }
        set
        {
            is_player_ready = value;
        }
    }
    public UnityEngine.Sprite PlayerIcon
    {
        get
        {
            return player_icon;
        }
    }
    public string NickName
    {
        get
        {
            return Photon.Pun.PhotonNetwork.NickName;
        }
    }
    public string ID
    {
        get
        {
            return network_player.UserId;
        }
    }
    public byte NumberInRoom
    {
        get
        {
            return number_in_room;
        }
        set
        {
            number_in_room = value;
        }
    }

    public LobbyPlayerClass(LobbyPlayerClass player)
    {
        network_player = player.network_player;
        is_player_ready = player.is_player_ready;
        player_icon = player.player_icon;
    }
    public LobbyPlayerClass(Photon.Realtime.Player player)
    {
        is_player_ready = false;
        player_icon = null;
        network_player = player;
    }
}
