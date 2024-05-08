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



}
