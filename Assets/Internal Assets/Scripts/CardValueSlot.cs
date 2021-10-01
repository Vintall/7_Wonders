using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardValueSlot : MonoBehaviour
{
    //[SerializeField] SlotType slot_type;
    //[SerializeField] Enums.GameValueType[] type_of_value;

    //enum SlotType
    //{
    //    Require,
    //    Give
    //}
    private void OnDrawGizmos()
    {
        //switch (type_of_value[0])
        //{
        //    case Enums.GameValueType.None:
        //        //Gizmos.color = new Color(1, 0, 0, 0f);
        //        break;
        //    case Enums.GameValueType.Resource:
        //        Gizmos.color = new Color(1, 0.7f, 0.7f);
        //        break;
        //    case Enums.GameValueType.Coin:
        //        Gizmos.color = Color.yellow;
        //        break;
        //    case Enums.GameValueType.Science:
        //        Gizmos.color = Color.green;
        //        break;
        //    case Enums.GameValueType.Technology:
        //        Gizmos.color = Color.cyan;
        //        break;
        //    case Enums.GameValueType.WarPoint:
        //        Gizmos.color = Color.red;
        //        break;
        //    case Enums.GameValueType.WictoryPoint:
        //        Gizmos.color = Color.blue;
        //        break;
        //    default:
        //        //???
        //        break;
        //}
        //Gizmos.color = new Color(Gizmos.color.r, Gizmos.color.g, Gizmos.color.b, 0.7f);

        //switch (slot_type)
        //{
        //    case SlotType.Give:
        //        Gizmos.DrawCube(this.transform.position, new Vector3(0.2f, 0.2f, 0.2f));
        //        break;
        //    case SlotType.Require:
        //        Gizmos.DrawSphere(this.transform.position, 0.1f);
        //        break;
        //}

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
