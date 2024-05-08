using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitStand : MonoBehaviour
{
    [SerializeField] private DeckShuffle Deck;
    public void Hit()
    {   if (OpeningPhase.instance.gameon)
        {
            Deck.takingcard = Random.Range(0, Deck.kartDestesi.Length - 1);

            while (Deck.kartDestesi[Deck.takingcard] == null || Deck.takingcard == Deck.hidingcard)
            {
                Deck.takingcard = Random.Range(0, Deck.kartDestesi.Length - 1);
            }
            Deck.AceCheckerUs();
            Deck.ourside += Deck.kartpuanlari[Deck.takingcard];
            Deck.AceValueSwitchUs();
            GameObject newcard = Instantiate(Deck.kartDestesi[Deck.takingcard], new Vector3(Deck.US.position.x + Deck.ourdiff * 6, Deck.US.position.y, Deck.US.position.z), Deck.US.rotation);
            Deck.ourdiff++;
            Deck.kartDestesi[Deck.takingcard] = null;
            VisualUpdater.Instance.NumberUpdater();

            if (Deck.ourside > 21) // Oyuncu Patladý ise
            {
                print("KASA KAZANDI");
                CountMoneyManager.Instance.LoseUp();
                VisualUpdater.Instance.ScoreboardUpdate();
                OpeningPhase.instance.gameon = false;

            }
        }
    }

    public void Stand()
    {   if (OpeningPhase.instance.gameon)
        {
            OpeningPhase.instance.Overlimitcheck();
        }
    }

    public void Reset()
    {
        if (!OpeningPhase.instance.gameon)
        {
            SceneManager.LoadScene(1);
        }
        //Deck.ourside = 0;
        //Deck.dealerside = 0;
        //Deck.takingcard = 0;
        //Deck.ourdiff = 0;
        //Deck.dealerdiff = 0;
        
    }



}

