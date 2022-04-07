using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm2 : MonoBehaviour
{
    /*summary
      ///////
     Changes the card colors according to the probabilities that they occur 
     */
    //callback for usable code
    public Algorithm1 algo1;

    //Checks to see if a random variable is less than a value + any previous value(var topOfStack) in the cardStats,(Script: Algorithm1)
    //Ergo: card 0 probability = 0-20, card 1 probability = 21-30...etc
    //If the variable is less than that value, the card is set to that type of card
    public void weightedChange(GameObject card)
    {
        float topOfStack = 0;
        float position = Random.Range(0, 100);
        for (int i = 0; i < algo1.cardStats.Length; i++)
        {
            topOfStack += algo1.cardStats[i].probability;
            if (position < topOfStack)
            {
                card.gameObject.GetComponent<Renderer>().material = algo1.cardStats[i].mat;
                algo1.changedTo = i;
                break;
            }
        }

    }
}
