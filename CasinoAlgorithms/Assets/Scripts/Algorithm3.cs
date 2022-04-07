using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm3 : MonoBehaviour
{

    /*summary
      ///////
      Decides the outcome of the turn by weight win pattern probablities
      Although, unexpected wins are possible
     */

    public Algorithm1 algo1;

    //Picks the desired win
    public void weightedWin()
    {
        float topOfStack = 0;
        float position = Random.Range(0, 100);
        for (int i = 0; i < algo1.typesOfWins.Length; i++)
        {
            topOfStack += algo1.typesOfWins[i].probability;
            if (position < topOfStack)
            {
                setWin(algo1.typesOfWins[i]);
                break;
            }
        }
    }

    //Sets up the win, and communicating with ColorChanger
    public void setWin(WinOrder win)
    {
        Material mat = algo1.cardStats[0].mat;
        float topOfStack = 0;
        float position = Random.Range(0, 100);
        for (int i = 0; i < algo1.cardStats.Length; i++)
        {
            topOfStack += algo1.cardStats[i].probability;
            if (position < topOfStack)
            {
                mat = algo1.cardStats[i].mat;
                break;
            }
        }
            this.gameObject.GetComponent<ColorChanger>().lose = false;
            this.gameObject.GetComponent<ColorChanger>().endProduct(win, mat);
    }
}
