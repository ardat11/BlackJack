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

    public GameObject[] kartDestesi; // Kartlar�n bulundu�u desteyi tutacak dizi
    public int[] kartpuanlari;
    
    public Transform Dealer;
    public Transform US;
    public int takingcard;
    public int dealerside;
    public int ourside;
    private int deal = 4;
    public int hidingcard;

    public int ourdiff = 1;
    public int dealerdiff = 1;

    public GameObject hiddencard;
    void Start()
    {
        
        //Shuffle();

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Shuffle();
        }
    }



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
                ourside += kartpuanlari[takingcard]; //bizim 1. kart
                kartDestesi[takingcard] = null;

            }
            else if (deal ==3)
            {
                GameObject newcard = Instantiate(kartDestesi[takingcard], Dealer.position, Dealer.rotation);
                dealerside += kartpuanlari[takingcard]; // kurpiyer 1. kart
                kartDestesi[takingcard] = null;
            }
            else if(deal ==2)
            {
                GameObject newcard = Instantiate(kartDestesi[takingcard], new Vector3(US.position.x+ 6*ourdiff,US.position.y,US.position.z), US.rotation);
                ourside += kartpuanlari[takingcard]; // bizim 2.kart
                ourdiff++;
                kartDestesi[takingcard] = null;
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


}