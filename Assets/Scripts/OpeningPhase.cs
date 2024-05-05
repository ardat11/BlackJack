using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningPhase : MonoBehaviour
{
    public static OpeningPhase instance;


    [SerializeField] private DeckShuffle Deck;
    private void Awake()
    {
        instance = this;
    }








    public void Overlimitcheck()
    {
        Destroy(Deck.hiddencard); // �
        Deck.hiddencard = Deck.kartDestesi[Deck.hidingcard];
        Instantiate(Deck.hiddencard, new Vector3(Deck.Dealer.position.x + 6 * Deck.dealerdiff, Deck.Dealer.position.y, Deck.Dealer.position.z), Deck.Dealer.rotation);
        Deck.dealerdiff++;
        Deck.dealerside += Deck.kartpuanlari[Deck.hidingcard];

       
        while (Deck.dealerside < 17)
        {
            Deck.takingcard = Random.Range(0, Deck.kartDestesi.Length - 1);

            while (Deck.kartDestesi[Deck.takingcard] == null || Deck.takingcard == Deck.hidingcard)
            {
                Deck.takingcard = Random.Range(0, Deck.kartDestesi.Length - 1);
            }

            Deck.dealerside += Deck.kartpuanlari[Deck.takingcard];
            GameObject newcard = Instantiate(Deck.kartDestesi[Deck.takingcard], new Vector3(Deck.Dealer.position.x + Deck.dealerdiff * 6, Deck.Dealer.position.y, Deck.Dealer.position.z), Deck.Dealer.rotation);
            Deck.dealerdiff++;
            Deck.kartDestesi[Deck.takingcard] = null;
        }
        if(Deck.dealerside > 21)
        {
            print("OYUNCU KAZANDI");
        }
        else
        {
            print("KASA KAZANDI");
        }
    }




}