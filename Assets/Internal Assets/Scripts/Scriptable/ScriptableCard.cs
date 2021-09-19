using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(menuName = "Scriptable/Scriptable Card", fileName = "Scriptable Card")]
public class ScriptableCard : ScriptableObject
{
    //TEST TEST

    [SerializeField] GameValueRequire[] require;

    [SerializeField] UnityEditor.MonoScript asd;
    void AA()
    {
        System.Type a = asd.GetClass();
    }
    [System.Serializable]
    public struct GameValueRequire
    {
        [SerializeField] GameValueType value_type;
        [SerializeField] Enums.Technology type;
        [SerializeField] GameValue asd;

        [ExecuteInEditMode]
        public void Change()
        {
            if (value_type == GameValueType.Coin)
            {
                asd = new Coins();
            }
            else
            {
                asd = new WarCoins();
            }
        }

        [System.Serializable]
        public class GameValue
        {
            //[SerializeField] int asddd;
        }
        public class Coins : GameValue
        {
            [SerializeField] int asddd;
        }
        public class WarCoins : GameValue
        {
            [SerializeField] string asddddd;
        }
    }
    public enum GameValueType
    {
        Coin,
        Technology,
        WarPoint,
        WictoryPoint
    }
    //TEST TEST

    [SerializeField] Sprite card_front_side;
    [SerializeField] Sprite card_back_side;
    [SerializeField] Enums.Age age;
    [SerializeField] Enums.CardType card_type;
    [SerializeField] int num_of_player;
    [SerializeField] string card_name;
    [SerializeField] Enums.Technology technology_require;
    [SerializeField] Enums.Technology[] technology_give;
    
    public string CardName
    {
        get
        {
            return card_name;
        }
    }
    public Sprite CardFrontSide
    {
        get
        {
            return card_front_side;
        }
    }
    public Sprite CardBackSide
    {
        get
        {
            return card_back_side;
        }
    }
    public Enums.Age Age
    {
        get
        {
            return age;
        }
    }
    public Enums.CardType CardType
    {
        get
        {
            return card_type;
        }
    }
    public int NumOfPlayers
    {
        get
        {
            return num_of_player;
        }
    }
}

[UnityEditor.CustomEditor(typeof(ScriptableCard), true)]
public class TestEditorScripting : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UnityEditor.EditorGUILayout.LabelField("This is aaaaaaaaaaaaaaaaaaa");
    }
}