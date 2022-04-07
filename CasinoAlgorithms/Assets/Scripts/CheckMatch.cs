using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatch : MonoBehaviour
{
    /*summary
     ////////
     Checks to see if there are any matching win patterns
     */
    public Algorithm1 algoScript;
    public Algorithm4 algoScript4;
    public RollTheDice buttonScript;
    public Score scoreScript;

    //used to make a serializable 2D array
    [System.Serializable]
    public class CardCollum
    {
       public GameObject[] row;
    }

    //stack of cards
    public CardCollum[] cards;
    //the value of each card in each spot
    public int[][] values;
    //the score of the card trying to match
    public float cardScore;



    //calls checkWinState()
    //For each color, a binary table is made
    //the binary table of hit(1) and misses(0), is passed to checkWinState()
    //each color also gives a cardScore
    public void check()
    {
        buttonScript.canHit = true;
        values = new int[cards.Length][];
        for (int i = 0; i < cards.Length; i++)
        {
            values[i] = new int[cards[i].row.Length];
            for (int j = 0; j < cards[i].row.Length; j++)
            {
                string matName = cards[i].row[j].gameObject.GetComponent<Renderer>().material.name;
                if (matName.Contains("Red"))
                    values[i][j] = 1;
                else if (matName.Contains("Blue"))
                    values[i][j] = 2;
                else if (matName.Contains("Green"))
                    values[i][j] = 3;
                else if (matName.Contains("Purple"))
                    values[i][j] = 4;
                else if (matName.Contains("Yellow"))
                    values[i][j] = 5;
                else
                    values[i][j] = 0;
            }
        }
        for (int val = 1; val < 6; val++)
        {

            cardScore = algoScript.cardStats[val - 1].score;
            int[][] confirmed = new int[cards.Length][];
            for (int i = 0; i < cards.Length; i++)
            {
                confirmed[i] = new int[cards[i].row.Length];
                for (int j = 0; j < cards[i].row.Length; j++)
                {
                    if (values[j][i] == val)
                    {
                        confirmed[i][j] = 1;
                    }
                    else
                    {
                        confirmed[i][j] = 0;
                    }
                }
            }
            checkWinStates(confirmed);
        }
    }

    //calls checkWin()
    //checks each win pattern for a binary table matching val
    private void checkWinStates(int[][] val)
    {
        for(int num =0;num<algoScript.typesOfWins.Length;num++)
        {
            checkWin(algoScript.typesOfWins[num],val);
        }
        cardScore = 0;
    }

    //calls Score.scoreUp
    //If the win pattern is value,
    //activate the winLine, add score, and adjust Algorithm4
    private void checkWin(WinOrder win, int[][] val)
    {

        for (int i = 0; i < win.matchingCardsCollum.Length; i++)
        {
            for (int j = 0; j < win.matchingCardsCollum[i].row.Length; j++)
            {
                if (val[i][j]==0 && win.matchingCardsCollum[i].row[j]>0)
                {
                    return;
                }
            }
        }
        scoreScript.scoreUp(win.score*cardScore);
        algoScript4.winCount++;
        algoScript4.justWon = true;
        win.winLine.SetActive(true);
    }
}
