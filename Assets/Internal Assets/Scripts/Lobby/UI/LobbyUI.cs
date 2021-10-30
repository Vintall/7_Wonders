using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс
/// </summary>
public class LobbyUI : MonoBehaviour
{
    #region UI Fields And Properties
    [SerializeField] ButtonUIPanel buttons_panel;
    [SerializeField] RoomUIPanel room_panel;
    [SerializeField] RoomListUIPanel room_list_panel;
    public ButtonUIPanel ButtonsPanel
    {
        get
        {
            return buttons_panel;
        }
    }
    public RoomUIPanel RoomPanel
    {
        get
        {
            return room_panel;
        }
    }
    public RoomListUIPanel RoomListPanel
    {
        get
        {
            return room_list_panel;
        }
    }
    #endregion
    public static LobbyUI instance;
    private void Awake()
    {
        instance = this;
    }
    

    public void CreateRoom()
    {
        RoomPanel.gameObject.SetActive(true);
        RoomListPanel.gameObject.SetActive(false);
        ButtonsPanel.gameObject.SetActive(false);
    }
    public void JoinRandomRoom()
    {

    }
    public void JoinRoom()
    {
        RoomPanel.gameObject.SetActive(true);
        RoomListPanel.gameObject.SetActive(false);
        ButtonsPanel.gameObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        RoomPanel.gameObject.SetActive(false);
        RoomListPanel.gameObject.SetActive(false);
        ButtonsPanel.gameObject.SetActive(true);
    }
}
