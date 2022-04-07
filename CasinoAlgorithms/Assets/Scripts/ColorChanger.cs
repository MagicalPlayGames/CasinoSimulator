using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /*summary
      ///////
      Changes the color of the cards
     */
    //Materials of each card
    public Material[] mats;
    //If the player is meant to loose
    public bool lose = false;

    //The matrix checked for a win pattern
    private int[][] winMatrix;
    //How many cards are out of place (mainly used for algorithm 3
    private int cardsToChange;
    //The final winMaterial and winLine
    private Material winMat;
    private GameObject winLine;

    public CheckMatch matchScript;
    //Trigger for when the ring stops
    public bool isSet = false;

    public AlgorithmLink algoLink;


    //Sets the cards into place by the winMatrix
    //If there is no number associated with the card, or
    //the spot is not needed to change, changeColor(card) changes the color randomly, or by var lose
    public void setMatrix(GameObject card)
    {
        CardNumber cardPlace = card.GetComponent<CardNumber>();
        if (cardPlace!=null)
        {
            if (cardsToChange > 0 || lose)
            {
                if (winMatrix[cardPlace.cardRow][cardPlace.cardCollum] == 1)
                {
                    card.GetComponent<Renderer>().material = winMat;
                    cardsToChange--;
                    winMatrix[cardPlace.cardRow][cardPlace.cardCollum] = 2;
                }
                else if (winMatrix[cardPlace.cardRow][cardPlace.cardCollum] == 0)
                {
                    changeColor(card);
                }
            }
        }
        else
        {
            changeColor(card);
        }
    }

    //Sets the winMatrix, based on the win pattern
    //If there is no win pattern, then the winMatrix is 0
    //If there is a win pattern, the win data and mat is transfered as the win
    public void endProduct(WinOrder win,Material mat)
    {
        cardsToChange = 0;
        if (win == null)
        {
            winMatrix = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                int length = 3;
                winMatrix[i] = new int[length];
                for (int j = 0; j < winMatrix[i].Length; j++)
                {
                    winMatrix[i][j] = 0;
                }
            }
            winMat = null;
            return;
        }

        winLine = win.winLine;
        winMatrix = new int[win.matchingCardsCollum.Length][];
        for(int i =0;i<win.matchingCardsCollum.Length;i++)
        {
            int length = win.matchingCardsCollum[i].row.Length;
            winMatrix[i] = new int[length];
            winMatrix[i] = win.matchingCardsCollum[i].row;
            for (int j = 0; j < winMatrix[i].Length; j++)
            {
                if (winMatrix[i][j] == 1)
                    cardsToChange++;
            }
        }
        winMat = mat;
    }

    //If a card hits this collider, then AlgorithmLink determines the algorithm to use
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Card")
        {
            algoLink.useAlgorithm(other.gameObject);
        }
    }

    //If the player is meant to lose, then lose
    //else change the card by a weighted random algorithm
    public void changeColor(GameObject card)
    {
        if (lose)
        {
            this.GetComponent<Algorithm4>().changeToLose(card);
        }
        else
            this.GetComponent<Algorithm2>().weightedChange(card);

    }

    //Pass through method from Spin to CheckMatch
    public void drawLine()
    {
        matchScript.check();
    }
}
