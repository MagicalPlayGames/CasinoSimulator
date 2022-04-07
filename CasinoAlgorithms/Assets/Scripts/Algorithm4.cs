using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Algorithm4 : MonoBehaviour
{
    /*summary
     /////////
     This Algorithm:
        *caculates if the player should win or lose
        *changes card colors so they do not lead to a win
        *Sends data to appropriate Scripts
     */

    //If the player has just won,
    //and is not set up to lose for their current turn,
    //justWon = true;
    public bool justWon = false;

    //win to spin ratio components
    public int winCount;
    public int spinCount;

    //The probabilities the player goes on a hotStreak, and loss/coldStreak, or generally loses
    public float hotStreakProb;
    public float lossStreakProb;
    public float loseProb;

    //How many more spins the player has on their (+)hotStreak or (-)coldStreak
    public int nextWins;
    //Text for win and spin counts
    public Text[] stats;
    
    //A callback to reusable functions
    public Algorithm1 algo1;
    public Algorithm3 algo3;

    /*If the player is on a hotstreak they automatically win (1)
    //If the player is on a coldstreak they automatically lose (2)
    //If the player just won, (3)
        //The algorithm decides between 
        //a hotStreak (3.1), 
        //a coldStreak (3.2),
        //or a general win lose rate (3.3)
    //If the player did not just win, the player loses
     //based off their current win streak (4)*/

    //Displays stats

    private void Update()
    {
        stats[0].text = "Wins: " + winCount;
        stats[1].text = "Turns: " + spinCount;
    }
    public bool shouldWin()
    {
        if (nextWins > 0)//(1)
        {
            nextWins--;
            return true;
        }
        else if (nextWins < 0)//(2)
        {
            nextWins++;
            return false;
        }
        if (justWon)//(3)
        {
            float loseOrWin = Random.Range(0, 100);
            if (loseOrWin < hotStreakProb)//(3.1)
            {
                nextWins = Random.Range(0, 5);
                return true;
            }
            else if (loseOrWin < hotStreakProb + lossStreakProb)//(3.2)
            {
                nextWins = Random.Range(-5, 1);
                return false;
            }
            else
            {
                float loses = Random.Range(0, 100);
                if (loses < loseProb)//(3.3)
                    return false;
                else
                {
                    return true;
                }
            }
        }
        else
        {
            if ((float)winCount / (float)(spinCount) < (loseProb / 100))//(4)
            {
                return true;
            }
            else
            {
                return (Random.Range(0, 100) > loseProb);
            }
        }
    }
    
    //Each card is just set to the card right after the previous card visited
    //It seems to look random, but is not
    public void changeToLose(GameObject card)
    {
        algo1.changedTo++;
        if (algo1.changedTo >= algo1.cardStats.Length)
            algo1.changedTo = 0;
        card.gameObject.GetComponent<Renderer>().material = algo1.cardStats[algo1.changedTo].mat;
    }

    //Sets up the colorChanger with a dontWin condition
    public void dontWin()
    {
            this.gameObject.GetComponent<ColorChanger>().lose = true;
            this.gameObject.GetComponent<ColorChanger>().endProduct(null, null);
    }

    //Activates when the button is pressed
    //Decides whether to win or lose
    public void reset()
    {
        if (shouldWin())
        {
            algo3.weightedWin();
        }
        else
        {
            justWon = false;
            dontWin();
        }
    }
}
