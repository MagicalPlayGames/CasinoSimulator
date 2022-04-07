using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //Keeps score
    public float totalScore;
    public Text totalScoreText;
    public GameObject scoreObj;

    public Vector3 min;
    public Vector3 max;
    void Start()
    {
        
    }

    //Picks a random location between min and max
    private Vector3 randomArea()
    {
        return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
    }

    //Increases the score, and provides a small text for how many points were gained
    public void scoreUp(float score)
    {
        Vector3 position = randomArea();
        GameObject scoreTextInstance = Instantiate(scoreObj, position, Quaternion.identity,GameObject.FindGameObjectWithTag("Canvas").transform);
        scoreTextInstance.GetComponent<Text>().text = "+" + score;
        totalScore += score;
        totalScoreText.text = "Score: "+totalScore;
        
    }
}
