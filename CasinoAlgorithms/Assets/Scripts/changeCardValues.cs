using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeCardValues : MonoBehaviour
{
    //This script changes the variables of the cards. It is connected to the main UI

    //Recorded Variables
    public int colorCap;
    public int colorMin;
    public int cardValueCap;
    public int cardValueMin;
    public int cardProbCap;
    public int cardProbMin;
    public int spinSpeedCap;
    public int spinTurnsCap;
    //Current Variables
    public int currentColor = 0;
    public int currentCardValue = 0;
    public int currentCardProb = 0;
    public int curNumSpins = 0;
    public int curSpinSpeed = 0;

    public VariableManager manager;
    //text for current values
    public Text[] text;
    public enum color { RED, BLUE, GREEN, PURPLE, YELLOW };

    //Initialize values
    public void Start()
    {
        currentCardValue = manager.cardValues.cardScores[0];
        currentCardProb = manager.cardValues.cardProbablities[0];
        curNumSpins = (int)manager.numberOfSpins;
        curSpinSpeed = (int)manager.startSpinSpeed;
    }
    //Always have the text set to the current values
    private void Update()
    {
        text[1].text = currentCardValue.ToString();
        text[2].text = currentCardProb.ToString();
        text[3].text = curNumSpins.ToString();
        text[4].text = curSpinSpeed.ToString();
    }

    //If cur is out of range, cur is put on the end of the opposite side of the range
    public int overOrUnder(int cur,int cap,int min)
    {
        if (cur > cap)
            return min;
        else if (cur < min)
            return cap;
        else
            return cur;
    }

    //Each update____ method adds or subtracts from each specific current variable, or changes it all together
    public void updateCardValue(int byVal)
    {
        int cur = manager.cardValues.cardScores[currentColor];
        manager.cardValues.cardScores[currentColor] = currentCardValue = overOrUnder(cur + byVal, cardValueCap, cardValueMin);
        manager.changeCardValues();
    }

    public void updateCardProb(int byVal)
    {
        int cur = manager.cardValues.cardProbablities[currentColor];
        manager.cardValues.cardProbablities[currentColor] = currentCardProb = overOrUnder(cur + byVal, cardProbCap, cardProbMin);
        manager.changeCardValues();
    }
    public void updateColor(int byVal)
    {
        color curColor = color.RED;
        currentColor = overOrUnder(currentColor + byVal, colorCap, colorMin);
        switch(currentColor)
        {
            case 0:
                curColor = color.RED;
                currentCardValue = manager.cardValues.cardScores[0];
                currentCardProb = manager.cardValues.cardProbablities[0];
                break;
            case 1:
                curColor = color.BLUE;
                currentCardValue = manager.cardValues.cardScores[1];
                currentCardProb = manager.cardValues.cardProbablities[1];
                break;
            case 2:
                curColor = color.GREEN;
                currentCardValue = manager.cardValues.cardScores[2];
                currentCardProb = manager.cardValues.cardProbablities[2];
                break;
            case 3:
                curColor = color.PURPLE;
                currentCardValue = manager.cardValues.cardScores[3];
                currentCardProb = manager.cardValues.cardProbablities[3];
                break;
            case 4:
                curColor = color.YELLOW;
                currentCardValue = manager.cardValues.cardScores[4];
                currentCardProb = manager.cardValues.cardProbablities[4];
                break;

        }
        text[0].text = curColor.ToString();
    }

    public void updateSpinSpeed(int byVal)
    {
        manager.startSpinSpeed = curSpinSpeed = overOrUnder(curSpinSpeed + byVal, spinSpeedCap, 0);
        manager.changeSpinValues();
    }

    public void updateSpinTurns(int byVal)
    {
        manager.numberOfSpins = curNumSpins = overOrUnder(curNumSpins + byVal, spinSpeedCap, 0);
        manager.changeSpinValues();
    }
}
