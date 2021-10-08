using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUISlot : MonoBehaviour
{
    [SerializeField] Text nickname_field;
    [SerializeField] GameObject ready_mark;
    Photon.Realtime.Player player;

    public Photon.Realtime.Player Player
    {
        get
        {
            return player;
        }
    }
    public Text NicknameField
    {
        get
        {
            return nickname_field;
        }
    }
    public GameObject ReadyMark
    {
        get
        {
            return ready_mark;
        }
    }
    
    public void ChangeReadyMarkColor(Color color)
    {
        ReadyMark.GetComponent<UnityEngine.UI.Image>().color = color;
    }
    public void SetPlayer(Photon.Realtime.Player player)
    {
        this.player = player;
        NicknameField.text = player.NickName;
    }
    public void ClearSlot(Photon.Realtime.Player player)
    {
        this.player = null;
        NicknameField.text = "";
    }
}
