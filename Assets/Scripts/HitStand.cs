using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStand : MonoBehaviour
{
    [SerializeField] private DeckShuffle Deck;
    public void Hit()
    {
        Deck.takingcard = Random.Range(0, Deck.kartDestesi.Length - 1);

        while (Deck.kartDestesi[Deck.takingcard] == null || Deck.takingcard == Deck.hidingcard)
        {
            Deck.takingcard = Random.Range(0, Deck.kartDestesi.Length - 1);
        }

        Deck.ourside += Deck.kartpuanlari[Deck.takingcard];
        GameObject newcard = Instantiate(Deck.kartDestesi[Deck.takingcard], new Vector3(Deck.US.position.x + Deck.ourdiff * 6, Deck.US.position.y, Deck.US.position.z), Deck.US.rotation);
        Deck.ourdiff++;
        Deck.kartDestesi[Deck.takingcard] = null;
        
        if(Deck.ourside > 21)
        {
            print("KASA KAZANDI");

        }
    
    }

    public void Stand()
    {
        OpeningPhase.instance.Overlimitcheck();
    }



}

