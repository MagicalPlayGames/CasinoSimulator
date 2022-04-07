using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VariableManager : MonoBehaviour
{

    /*summary
      ///////
      A collection of variables that can be adjusted from the changeCardValues and changeWinValues scripts
      This script is essential to change variables of other scripts
     */

    //Scripts with adjustable variables
    public Algorithm1 algo1;
    public Algorithm4 algo4;
    public Spin[] spinScripts;

    //cards
    //each probablity of the cards
    //each score of the cards
    [System.Serializable]
    public class cards
    {
        public int[] cardProbablities;
        public int[] cardScores;
    }

    //wins
    //each probablity of the win patterns
    //each score of the win patterns
    [System.Serializable]
    public class wins
    {
        public int[] winProbablities;
        public int[] winScores;
    }

    public cards cardValues;
    public wins winValues;

    //other variables
    public float hotStreak;
    public float coldStreak;
    public float loseProb;
    public float startSpinSpeed;
    public int numberOfSpins;

    //Initialize
    void Start()
    {
        changeCardValues();
        changeWinValues();
        changeStreakValues();
    }

    //Each change____ method resets the variables of multiple scripts to the variables on this script
    public void changeCardValues()
    {
        for (int i = 0; i < algo1.cardStats.Length; i++)
        {
            algo1.cardStats[i].probability = cardValues.cardProbablities[i];
            algo1.cardStats[i].score = cardValues.cardScores[i];
        }
    }

    public void changeWinValues()
    {
        for (int i = 0; i < algo1.cardStats.Length; i++)
        {
            algo1.typesOfWins[i].probability = winValues.winProbablities[i];
            algo1.typesOfWins[i].score = winValues.winScores[i];
        }
    }

    public void changeSpinValues()
    {
        spinScripts[0].firstRotationSpeed = startSpinSpeed;
        spinScripts[1].firstRotationSpeed = -startSpinSpeed;
        spinScripts[2].firstRotationSpeed = startSpinSpeed;
        for (int i =0;i<spinScripts.Length;i++)
        {
            spinScripts[i].startNofS = numberOfSpins;
        }
    }

    public void changeStreakValues()
    {
        algo4.hotStreakProb = hotStreak;
        algo4.lossStreakProb = coldStreak;
        algo4.loseProb = loseProb;
    }
}
