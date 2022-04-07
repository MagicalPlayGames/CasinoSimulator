using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script has very important classes to the rest of the algorithms and ColorChanger
 Other than that, it chooses a card at random*/


//CardAttributes have the material, probability of occurance, and cardScore from (cardScore*winScore) for each card
[System.Serializable]
public class CardAttributes
{
    public Material mat;
    public float probability;
    public float score;


}

//Used to make a Serializable 2D array
[System.Serializable]
public class intArray
{
    public int[] row;
}

//WinOrder is the object with the information on how to win
//The name of the win
//The probability of the win
//The winScore in (cardScore*winScore)
//The binary table for the win pattern
//The line of particles that the win pattern associates with
    [System.Serializable]
public class WinOrder
{
    public string name;
    public float probability;
    public float score;
    public intArray[] matchingCardsCollum;
    public GameObject winLine;
}

public class Algorithm1 : MonoBehaviour
{
    //Stack of cards
    public CardAttributes[] cardStats;
    //Types of wins
    public WinOrder[] typesOfWins;
    //The value of a random card
    public int changedTo = 0;

    public Algorithm4 algo4Script;

    //Initialize materials from ColorChanger
    private void Start()
    {
        for (int i = 0; i < cardStats.Length; i++)
        {
            cardStats[i].mat = this.gameObject.GetComponent<ColorChanger>().mats[i];
        }
    }

    //Picks a card at complete random
    public void randomChange(GameObject card)
    {
        card.gameObject.GetComponent<Renderer>().material = cardStats[Random.Range(0, cardStats.Length)].mat;
    }

    //Resets the winLines, and randomly changes changedTo
    public void reset()
    {
        changedTo = Random.Range(0, 4);
        algo4Script.spinCount++;
        for(int i =0;i<typesOfWins.Length;i++)
        {
            typesOfWins[i].winLine.SetActive(false);
        }
    }
}
