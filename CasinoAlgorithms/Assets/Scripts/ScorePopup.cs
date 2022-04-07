using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{

    //Makes the text float at the speed(speed), for the time it is alive(timeAlive)

    public float speed;
    public float timeAlive;
    void Start()
    {
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
