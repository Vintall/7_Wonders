using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUISlots : MonoBehaviour
{
    [SerializeField] PlayerUISlot[] player_field;
    private int active_slots = 0;
    public PlayerUISlot[] PlayerField
    {
        get
        {
            return player_field;
        }
    }
    void DeactivateAllFields()
    {
        active_slots = 0;
        foreach (PlayerUISlot i in PlayerField)
            i.gameObject.SetActive(false);
    }
    public void RefreshSlots(AllLobbyPlayers players)
    {
        DeactivateAllFields();
        for (int i = 0; i < players.AllPlayers.Count; i++)
        {
            AddPlayer(players[i].NetworkPlayer);
        }
    }
    public void AddPlayer(Photon.Realtime.Player player)
    {
        active_slots++;
        player_field[active_slots - 1].SetPlayer(player);
        player_field[active_slots - 1].gameObject.SetActive(true);
        Debug.Log("Create Field ["+(active_slots - 1));
    }
    public void RemovePlayer(Photon.Realtime.Player player)
    {
        active_slots--;
        player_field[active_slots - 1].ClearSlot(player);
        player_field[active_slots - 1].gameObject.SetActive(false);
    }
}
