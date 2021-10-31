using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameController : MonoBehaviourPunCallbacks, IOnEventCallback
{
    CardsForGame game_cards;
    Structs.RoomPlayersHistory player_history;
    public class CardsForGame
    {
        public List<ScriptableCard> first_age;
        public List<ScriptableCard> second_age;
        public List<ScriptableCard> third_age;

        public CardsForGame()
        {
            first_age = new List<ScriptableCard>();
            second_age = new List<ScriptableCard>();
            third_age = new List<ScriptableCard>();
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        
    }
    public void InitGame()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        player_history = new Structs.RoomPlayersHistory();
        
        foreach(KeyValuePair<int, Photon.Realtime.Player> key in PhotonNetwork.CurrentRoom.Players)
        {
            player_history.AddPlayer(key.Value);
        }

        if(PhotonNetwork.IsMasterClient)
        {
            //InitCardDeck();

            game_cards = new CardsForGame(); //TEST
            for (int i = 0; i < 7; i++)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount >= GameData.instance.CardData.Cards[0].NumOfPlayers) 
                    game_cards.first_age.Add(GameData.instance.CardData.Cards[0]);

                if (PhotonNetwork.CurrentRoom.PlayerCount >= GameData.instance.CardData.Cards[1].NumOfPlayers)
                    game_cards.first_age.Add(GameData.instance.CardData.Cards[1]);

                if (PhotonNetwork.CurrentRoom.PlayerCount >= GameData.instance.CardData.Cards[2].NumOfPlayers)
                    game_cards.first_age.Add(GameData.instance.CardData.Cards[2]);
            }

            InitCardKits(game_cards.first_age);
        }
    }
    public void InitCardDeck()
    {
        int player_count = PhotonNetwork.CurrentRoom.PlayerCount;
        game_cards = new CardsForGame();
        foreach (ScriptableCard i in GameData.instance.CardData.Cards)
        {
            if(player_count >= i.NumOfPlayers)
            {
                switch(i.Age)
                {
                    case Enums.Age.First_age:
                        game_cards.first_age.Add(i);
                        break;
                    case Enums.Age.Second_age:
                        game_cards.second_age.Add(i);
                        break;
                    case Enums.Age.Third_age:
                        game_cards.third_age.Add(i);
                        break;
                }
            }
        }
    }
    public List<List<ScriptableCard>> InitCardKits(List<ScriptableCard> cards)
    {
        if (!PhotonNetwork.IsMasterClient)
            return null;

        List<List<ScriptableCard>> card_kits = new List<List<ScriptableCard>>();
        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
            card_kits.Add(new List<ScriptableCard>());

        int index = -1;
        for (; cards.Count != 0;)
        {
            for (int i = 0; i < card_kits.Count; i++)
            {
                if (cards.Count == 0)
                    break;

                index = Random.Range(0, cards.Count - 1);
                card_kits[i].Add(cards[index]);
                cards.RemoveAt(index);
            }
        }
        Transform[] game_object_card_kits = new Transform[PhotonNetwork.CurrentRoom.PlayerCount];
        
        int[] player_room_id = new int[PhotonNetwork.CurrentRoom.PlayerCount];
        int player_int_key = 0;
        foreach(KeyValuePair<int, Photon.Realtime.Player> key in PhotonNetwork.CurrentRoom.Players)
            player_room_id[player_int_key++] = key.Value.ActorNumber;

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            game_object_card_kits[i] = PhotonNetwork.Instantiate("CardKit", Vector3.zero, Quaternion.identity).transform;
            //game_object_card_kits[i].GetComponent<CardKit>().InstantianeCardKit(card_kits[i]);
        }

        RaiseEventOptions raise_option = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions send_option = new SendOptions { DeliveryMode = DeliveryMode.Reliable };

        List<byte> serialised_card = new List<byte>();

        for (byte i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            serialised_card.Add(i);
            for (int j = 0; j < 7; j++)
            {
                serialised_card.Add(card_kits[i][j].ID);
            }
        }
        PhotonNetwork.RaiseEvent(1, serialised_card, raise_option, send_option); 
        return card_kits;
    }
    void Start()
    {
        InitGame();
    }

    void Update()
    {
        
    }

    public void OnEvent(EventData photonEvent)
    {
        switch(photonEvent.Code)
        {
            case 1: //CardKit generate and transfer code
                EventReceiveKits(photonEvent);
                break;
        }
    }
    void EventReceiveKits(EventData photon_event)
    {
        List<byte> serialised_card = new List<byte>();
        serialised_card = (List<byte>)photon_event.CustomData;
        int kit_count = serialised_card.Count / 8;

        List<List<ScriptableCard>> card_kits = new List<List<ScriptableCard>>();
        for (int i = 0; i < kit_count; i++)
            card_kits.Add(new List<ScriptableCard>());

        for (int i = 0; i < kit_count; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                card_kits[i].Add(GameData.instance.CardData.Cards[serialised_card[i * 7 + j]]);
            }
        }
    }
}
