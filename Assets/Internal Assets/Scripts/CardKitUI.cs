using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardKitUI : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    public Button[] Buttons
    {
        get
        {
            return buttons;
        }
    }
    public void ChooseCard(int num)
    {
        Debug.Log("Cart #" + num + " in CardKit was choosed");
    }
    public void ActivateButtons(int count)
    {
        DisActivateButtons();

        if (count >= 0 && count <= buttons.Length)
            for (int i = 0; i < count; i++)
                buttons[i].gameObject.SetActive(true);
    }
    public void DisActivateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].gameObject.SetActive(false);
    }
    public void PlaceButtons(Vector2[] pos)
    {
        ActivateButtons(pos.Length);

        for (int i = 0; i < pos.Length; i++)
            buttons[i].gameObject.transform.position = pos[i];
    }
}
