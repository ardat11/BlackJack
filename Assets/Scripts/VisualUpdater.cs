using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisualUpdater : MonoBehaviour
{   
    public static VisualUpdater Instance;
    [SerializeField] private TMP_Text DealerText;
    [SerializeField] private TMP_Text OurText;
    [SerializeField] private TMP_Text winCount;
    [SerializeField] private TMP_Text loseCount;
    [SerializeField] private TMP_Text money;
    private DeckShuffle Deck;

    private void Awake()
    {   
        Instance = this;
        Deck = GetComponent<DeckShuffle>();
    }
    private void Start()
    {
        DealerText.text = "0";
        OurText.text = "0";
        ScoreboardUpdate();
    }


    public void NumberUpdater()
    {  
        if(Deck.aceCountUs > 0 && OpeningPhase.instance.gameon)
        {
            OurText.text = (Deck.ourside-10).ToString() +  "/" + Deck.ourside.ToString();
        }
        else
        {
            OurText.text = Deck.ourside.ToString();
        }
        if (Deck.aceCountDealer > 0 && OpeningPhase.instance.gameon)
        {
            DealerText.text = (Deck.dealerside - 10).ToString() + "/" + Deck.dealerside.ToString();
        }
        else
        {
            DealerText.text = Deck.dealerside.ToString();
        }
        
    }

    public void ScoreboardUpdate()
    {
        winCount.text = "Win: " + CountMoneyManager.Instance.win.ToString();
        loseCount.text = "Lose: " + CountMoneyManager.Instance.lose.ToString();
    }



}
