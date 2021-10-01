using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotsGUIDrawer : MonoBehaviour
{
    [SerializeField] Transform require_technology;
    [SerializeField] Transform require_resources;
    [SerializeField] Transform give_technology;
    [SerializeField] Transform give_ability;
    
    private void OnDrawGizmos()
    {
        DrawCardSlot();
    }
    private void DrawCardSlot()
    {
        float radius = 0.1f;
        Gizmos.color = Color.cyan;
        foreach (CardValueSlot i in require_technology.GetComponentsInChildren<CardValueSlot>())
            Gizmos.DrawSphere(i.transform.position, radius);

        foreach (CardValueSlot i in give_technology.GetComponentsInChildren<CardValueSlot>())
            Gizmos.DrawCube(i.transform.position, new Vector3(radius * 2, radius * 2, radius * 2));

        Gizmos.color = Color.red;
        foreach (CardValueSlot i in require_resources.GetComponentsInChildren<CardValueSlot>())
            Gizmos.DrawSphere(i.transform.position, radius);

        foreach (CardValueSlot i in give_ability.GetComponentsInChildren<CardValueSlot>())
            Gizmos.DrawCube(i.transform.position, new Vector3(radius * 2, radius * 2, radius * 2));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
