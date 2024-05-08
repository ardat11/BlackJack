using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetPanelManager : MonoBehaviour
{   
    public static BetPanelManager Instance;
    public GameObject BETPANEL;
    public GameObject GAMEPANEL;
    public TMP_Text CurrentBet;
    public TMP_Text Bounty;
    private void Awake()
    {
        Instance = this;
    }

    public void AddBett(int value)
    {

        if (CountMoneyManager.Instance.bounty - value >= 0 && CountMoneyManager.Instance.playingbounty + value >= 0)
        {
            CountMoneyManager.Instance.playingbounty += value;
            CountMoneyManager.Instance.bounty -= value;
            print("KUMAR GUNAH YEGENIM");
            MoneyVisualUpdate();

        }

    }

    public void PaybabaPay()
    {
        CountMoneyManager.Instance.bounty += CountMoneyManager.Instance.playingbounty * 2;
        CountMoneyManager.Instance.playingbounty = 0;
        MoneyVisualUpdate();
    }

    public void Fail()
    {
        CountMoneyManager.Instance.playingbounty = 0;
        MoneyVisualUpdate();
    }
    public void Push() // berabere
    {
        CountMoneyManager.Instance.bounty += CountMoneyManager.Instance.playingbounty;
        CountMoneyManager.Instance.playingbounty = 0;
        MoneyVisualUpdate();
    }

    public void StartBlackJack()
    {

        BETPANEL.SetActive(false);
        GAMEPANEL.SetActive(true);
        OpeningPhase.instance.gameon = true;
        DeckShuffle.instance.Shuffle();
    }

    public void MoneyVisualUpdate()
    {
        Bounty.text = "Bakiye: " + CountMoneyManager.Instance.bounty.ToString();
        CurrentBet.text = "Current Bet: " + CountMoneyManager.Instance.playingbounty.ToString();
    }
}
