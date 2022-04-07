using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmLink : MonoBehaviour
{

    /*This script decides what algorithm to use*/

    //Currently selected Algorithm (1-4)
    public int algorithmSelect;
    //Next Algorithm to accept
    public int selected;
    //If the current toggle is on or off
    private bool yOff = false;
    //Algorithms SEE DESCRIPTIONS GAMEOBJECT FOR CONCISE
    public Algorithm1 algo1;
    public Algorithm2 algo2;
    public Algorithm3 algo3;
    public Algorithm4 algo4;

    public ColorChanger colorScript;
    //The toggles for each algorithm
    public Toggle[] toggles;

    void Start()
    {
        activate(1);
        spin();
    }

    //Makes the toggle selected as the only selected toggle,
    //and makes that toggle non-interactable.
    //One toggle at a time, but never twice
    public void despawnOthers(Toggle y)
    {
        if (!y.isOn)
        {
            yOff = true;
            return;
        }
        yOff = false;
        foreach(Toggle x in toggles)
        {
            if (y != x)
            {
                x.interactable = true;
                x.isOn = false;
            }
            else
            {
                x.interactable = false;
            }
        }
    }

    //selects the next selected algorithm
    public void activate(int select)
    {
        if (select != selected)
            yOff = false;
        if (!yOff)
        {
            selected = select;
        }
    }

    //Picks the next algorithm
    //resets each algorithm needed, and sets up parameters for each
    public void spin()
    {
        algo1.reset();
        if (algorithmSelect == 3)
        {
            algo3.weightedWin();
        }
        else if (algorithmSelect == 4)
            algo4.reset();
        if (algorithmSelect != 4)
            colorScript.lose = false;
    }

    //Changes the color of the card based on the algorithm being used
    public void useAlgorithm(GameObject currentCard)
    {
        switch (algorithmSelect)
        {
            case 1:
                algo1.randomChange(currentCard);
                break;
            case 2:
                algo2.weightedChange(currentCard);
                break;
            case 3:
                colorScript.setMatrix(currentCard);
                break;
            case 4:
                if (colorScript.lose)
                {
                    algo4.changeToLose(currentCard);
                }
                else
                    colorScript.setMatrix(currentCard);
                break;
        }
    }
}
