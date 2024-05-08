using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;
using System.Collections.Generic;

public class DeckShuffle : MonoBehaviour
{
    public static DeckShuffle instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject[] kartDestesi; // Kartlarýn bulunduðu desteyi tutacak dizi
    public int[] kartpuanlari;
    
    public Transform Dealer;
    public Transform US;
    public int takingcard;
    public int dealerside;
    public int ourside;
    private int deal = 4;
    public int hidingcard;
    public int aceCountDealer;
    public int aceCountUs;

    public int ourdiff = 1;
    public int dealerdiff = 1;

    public GameObject hiddencard;
    void Start()
    {

        Invoke("Shuffle", 0.1f);

    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Escape))
    //    {
    //        Shuffle();
    //    }
    //}



    public void Shuffle()
    {
        while (deal > 0)
        {
            takingcard = UnityEngine.Random.Range(0, kartDestesi.Length - 1);

            while (kartDestesi[takingcard] == null || takingcard == hidingcard)
            {
                takingcard = UnityEngine.Random.Range(0, kartDestesi.Length - 1);
            }

            if(deal ==4)
            {
                GameObject newcard = Instantiate(kartDestesi[takingcard], US.position, US.rotation);
                AceCheckerUs();
                ourside += kartpuanlari[takingcard]; //bizim 1. kart
                kartDestesi[takingcard] = null;
                VisualUpdater.Instance.NumberUpdater();
            }
            else if (deal ==3)
            {   
                GameObject newcard = Instantiate(kartDestesi[takingcard], Dealer.position, Dealer.rotation);
                AceCheckerDealer();
                dealerside += kartpuanlari[takingcard]; // kurpiyer 1. kart
                kartDestesi[takingcard] = null;
                VisualUpdater.Instance.NumberUpdater();
            }
            else if(deal ==2)
            {
                GameObject newcard = Instantiate(kartDestesi[takingcard], new Vector3(US.position.x+ 6*ourdiff,US.position.y,US.position.z), US.rotation);
                AceCheckerUs();
                ourside += kartpuanlari[takingcard]; // bizim 2.kart
                AceValueSwitchUs();
                ourdiff++;
                kartDestesi[takingcard] = null;
                VisualUpdater.Instance.NumberUpdater();
            }
            if(deal ==1)
            {
                hiddencard = Instantiate(kartDestesi[52], new Vector3(Dealer.position.x + 6*dealerdiff, Dealer.position.y, Dealer.position.z), Dealer.rotation);
                hidingcard = takingcard;  //kurpiyer 2.kart
                //dealerdiff++;
            }
            deal--;
            
        }



    }


    public void hit()
    {
        takingcard = UnityEngine.Random.Range(0, kartDestesi.Length - 1);
        
        while (kartDestesi[takingcard] == null)
        {
            takingcard = UnityEngine.Random.Range(0, kartDestesi.Length - 1);
        }

        ourside += kartpuanlari[takingcard];
        GameObject newcard = Instantiate(kartDestesi[takingcard], new Vector3(US.position.x + ourdiff*6, US.position.y, US.position.z), US.rotation);
        ourdiff++;
    }







    public void AceCheckerDealer()
    {
        if (kartpuanlari[takingcard] == 11)
        {
            aceCountDealer++;
        }
    }

    public void AceCheckerUs()
    {
        if (kartpuanlari[takingcard] == 11)
        {
            aceCountUs++;
        }
    }

    public void AceValueSwitchDealer()
    {
        if(dealerside > 21 && aceCountDealer > 0)
        {
            dealerside -= 10;
            aceCountDealer--;
        }
    }

    public void AceValueSwitchUs()
    {
        if (ourside > 21 && aceCountUs > 0)
        {
            ourside -= 10;
            aceCountUs--;
        }
    }
    //public void AceControlnAddtoUs()
    //{
    //    if (kartpuanlari[takingcard] == 11) 
    //    {
    //        if(ourside+11 > 21)
    //        {
    //            ourside++;
    //        }
    //        else
    //        {
    //            ourside += kartpuanlari[takingcard];
    //        }
    //    }
    //    else
    //    {
    //        ourside += kartpuanlari[takingcard];
    //    }
    //}

    //public void AceControlnAddtoDealer()
    //{
    //    if (kartpuanlari[takingcard] == 11)
    //    {
    //        if (dealerside + 11 > 21)
    //        {
    //            dealerside++;
    //        }
    //        else
    //        {
    //            dealerside += kartpuanlari[takingcard];
    //        }
    //    }
    //    else
    //    {
    //        dealerside += kartpuanlari[takingcard];
    //    }
    //}


}