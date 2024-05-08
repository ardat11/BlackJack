using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountMoneyManager : MonoBehaviour
{
    public static CountMoneyManager Instance;
    public int moneyCount;
    public int win;
    public int lose;
    public int bounty;
    public int playingbounty;
    public GameObject BETPANEL;
    public GameObject GAMEPANEL;
    public TMP_Text CurrentBet;
    public TMP_Text Bounty;

    private void Awake()
    {   if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void WinUp()
    {
        win++;
    }

    public void LoseUp()
    {
        lose++;
        
    }

    //public void AddBett(int value)
    //{   
        
    //    if (bounty - value >= 0 && playingbounty + value >= 0)
    //    {
    //        playingbounty += value;
    //        bounty -= value;
    //        print("KUMAR GUNAH YEGENIM");
    //        MoneyVisualUpdate();

    //    }

    //}

    //public void PaybabaPay()
    //{
    //    bounty += playingbounty * 2;
    //    playingbounty = 0;
    //    MoneyVisualUpdate();
    //}

    //public void Fail()
    //{
    //    playingbounty = 0;
    //    MoneyVisualUpdate();
    //}
    //public void Push() // berabere
    //{
    //    bounty += playingbounty;
    //    playingbounty = 0;
    //    MoneyVisualUpdate();
    //}

    //public void StartBlackJack()
    //{

    //    BETPANEL.SetActive(false);
    //    GAMEPANEL.SetActive(true);
    //    OpeningPhase.instance.gameon = true;
    //    DeckShuffle.instance.Shuffle();
    //}

    //public void MoneyVisualUpdate()
    //{
    //    Bounty.text = "Bakiye: " +bounty.ToString();
    //    CurrentBet.text = "Current Bet: " +playingbounty.ToString();
    //}


}
