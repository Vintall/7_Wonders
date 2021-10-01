using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKit : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float space_width;
    [SerializeField, Range(0, 3)] float space_height;
    Vector2[] card_positions;
    bool is_kit_rolled_up = false;
    public void InitCardPositions()
    {
        card_positions = new Vector2[transform.childCount];
        int divider = transform.childCount / 2;
        for (int i = 1; i <= divider; i++)
            card_positions[i - 1] = new Vector2(-((divider-1) / 2f) * space_width + (i - 1) * space_width, -space_height);
        for (int i = divider + 1; i <= transform.childCount; i++)
            card_positions[i - 1] = new Vector2(-((transform.childCount-divider-1) / 2f) * space_width + (i - divider - 1) * space_width, space_height);
    }
    private void OnDrawGizmos()
    {
        InitCardPositions();
        PlaceCardOnPos();

        Gizmos.color = Color.green;
        for (int i = 0; i < card_positions.Length; i++)
            Gizmos.DrawSphere(transform.position + new Vector3(card_positions[i].x, card_positions[i].y, 0), 0.5f);
    }
    void PlaceCardOnPos()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).localPosition = card_positions[i];
    }
    void RollToDeck() //�������� ����� � ���� �����. � �������� ������� ��������
    {
        card_positions = new Vector2[transform.childCount];
        for (int i = 0; i < card_positions.Length; i++)
            card_positions[i] = Vector2.zero;
    }
    void RollToSet() //���������� ����� � ����� ����. � �������� ������� ��������
    {
        InitCardPositions();
    }
    public void ChangeKitState()
    {
        if (!is_kit_rolled_up)
            RollToSet();
        else
            RollToDeck();

        is_kit_rolled_up = !is_kit_rolled_up;

        PlaceCardOnPos();
    }
    void Start()
    {
        //InitCardPositions();
        is_kit_rolled_up = true;
    }
    void Update()
    {
        
    }
}