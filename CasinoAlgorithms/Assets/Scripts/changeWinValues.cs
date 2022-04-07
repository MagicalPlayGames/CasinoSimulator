using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeWinValues : MonoBehaviour
{
    //This script changes the variables of winning. It is connected to the main UI



    //Recorded variables
    public int typeOfWinCap;
    public int winValueCap;
    public int winValueMin;
    public int winProbCap;
    public int winProbMin;

    //Current Values
    public int currentWin = 0;
    public int currentWinValue = 0;
    public int currentWinProb = 0;
    public int currenthotProb = 0;
    public int currentcoldProb = 0;
    public int currentloseProb = 0;

    public VariableManager manager;
    //text for current values
    public Text[] text;

    //Initialize values
    public void Start()
    {
        currentWinValue = manager.winValues.winScores[0];
        currentWinProb = manager.winValues.winScores[0];
        text[0].text = manager.algo1.typesOfWins[0].name;
        currenthotProb = (int)manager.hotStreak;
        currentcoldProb = (int)manager.coldStreak;
        currentloseProb = (int)manager.loseProb;
    }

    //Always have the text set to the current values
    private void Update()
    {
        text[1].text = currentWinValue.ToString();
        text[2].text = currentWinProb.ToString();
        text[3].text = currenthotProb.ToString();
        text[4].text = currentcoldProb.ToString();
        text[5].text = currentloseProb.ToString();
    }

    //If cur is out of range, cur is put on the end of the opposite side of the range
    public int overOrUnder(int cur, int cap, int min)
    {
        if (cur > cap)
            return min;
        else if (cur < min)
            return cap;
        else
            return cur;
    }

    //Each update____ method adds or subtracts from each specific current variable

    public void updateWinValue(int byVal)
    {
        int cur = manager.winValues.winScores[currentWin];
        manager.winValues.winScores[currentWin] = currentWinValue = overOrUnder(cur + byVal, winValueCap, winValueMin);
        manager.changeWinValues();
    }

    public void updateWinProb(int byVal)
    {
        int cur = manager.winValues.winProbablities[currentWin];
        manager.winValues.winProbablities[currentWin] = currentWinProb = overOrUnder(cur + byVal, winProbCap, winProbMin);
        manager.changeWinValues();
    }
    public void updateWinType(int byVal)
    {
        currentWin = overOrUnder(currentWin + byVal, typeOfWinCap, 0);
        text[0].text = manager.algo1.typesOfWins[currentWin].name;
    }
    public void updatehotProb(int byVal)
    {
        manager.hotStreak = currenthotProb = overOrUnder(currenthotProb + byVal, 100, 0);
        manager.changeStreakValues();
    }
    public void updatecoldProb(int byVal)
    {
        manager.coldStreak = currentcoldProb = overOrUnder(currentcoldProb + byVal, 100, 0);
        manager.changeStreakValues();
    }
    public void updateloseProb(int byVal)
    {
        manager.loseProb = currentloseProb = overOrUnder(currentloseProb + byVal, 100, 0);
        manager.changeStreakValues();
    }
}
