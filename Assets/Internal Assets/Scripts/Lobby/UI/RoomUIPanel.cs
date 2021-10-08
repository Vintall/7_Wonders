using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomUIPanel : MonoBehaviour
{
    #region UIFields
    [SerializeField] Button back_to_main;
    [SerializeField] Button ready_button;
    [SerializeField] PlayerUISlots player_slots; //Panel
    [SerializeField] InputField room_name;
    [SerializeField] Button start_button;
    #endregion
    #region Properties
    public Button StartButton
    {
        get
        {
            return start_button;
        }
    }
    public Button BackToMainButton
    {
        get
        {
            return back_to_main;
        }
    }
    public Button ReadyButton
    {
        get
        {
            return ready_button;
        }
    }
    public PlayerUISlots PlayerSlots
    {
        get
        {
            return player_slots;
        }
    }
    public InputField RoomName
    {
        get
        {
            return room_name;
        }
    }
    #endregion

    private void Start()
    {
        IsPlayerMaster();
    }
    public void RefreshPlayers(AllLobbyPlayers players)
    {
        player_slots.RefreshSlots(players);
    }
    public void StartButtonPressed()
    {
        if (!PhotonNetwork.IsMasterClient) 
            return;

    }
    public void ReadyButtonPressed()
    {

    }
    public void IsPlayerMaster() //Use it on create/join lobby.  onSMBDleft   Maybe should make one method
    {
        room_name.interactable = false;
        start_button.gameObject.SetActive(false);

        if(PhotonNetwork.IsMasterClient)
        {
            room_name.interactable = true;
            start_button.gameObject.SetActive(true);
        }
    }

    #region RoomName
    public void ChangeRoomName() //Make Room second name
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        Debug.Log("Try to change room name");
        //room_name
    }
    #endregion
}
