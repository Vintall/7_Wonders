using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AllLobbyPlayers
{
    List<LobbyPlayerClass> lobby_players;
    
    public AllLobbyPlayers()
    {
        lobby_players = new List<LobbyPlayerClass>();
    }
    public AllLobbyPlayers(List<Photon.Realtime.Player> players)
    {
        lobby_players = new List<LobbyPlayerClass>();
        foreach (Photon.Realtime.Player i in players)
            AddPlayer(i);
    }
    public void AddPlayer(Photon.Realtime.Player player)
    {
        lobby_players.Add(new LobbyPlayerClass(player));
    }
    public void RemovePlayer(Photon.Realtime.Player player)
    {
        for (int i = 0; i < lobby_players.Count; i++) 
        {
            if (lobby_players[i].ID == player.UserId)
            {
                lobby_players.RemoveAt(i);
                break;
            }
        }
    }
    
    public List<LobbyPlayerClass> AllPlayers
    {
        get
        {
            return lobby_players;
        }
    }
    public void ChangeSeldReadyState()
    {
        SelfPlayerObject.IsPlayerReady = !SelfPlayerObject.IsPlayerReady;
    }
    public bool IsAllPlayersReady
    {
        get
        {
            bool all_ready = true;
            foreach (LobbyPlayerClass i in lobby_players)
                if (!i.IsPlayerReady)
                {
                    all_ready = false;
                    break;
                }
            return all_ready;
        }
    }
    public bool IsSelfReady
    {
        get
        {
            return SelfPlayerObject.IsPlayerReady;
        }
    }
    public LobbyPlayerClass this[int i]
    {
        get
        {
            if (i < 0 && i >= lobby_players.Count)
                return null;
            return lobby_players[i];
        }
    }
    public LobbyPlayerClass SelfPlayerObject
    {
        get
        {
            foreach(LobbyPlayerClass i in lobby_players)
                if (i.ID == Photon.Pun.PhotonNetwork.LocalPlayer.UserId)
                    return i;
            return null;
        }
    }
    
}