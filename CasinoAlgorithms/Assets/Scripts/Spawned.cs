using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawned : MonoBehaviour
{

    //Menu item spawned that moves to a location

    //Where the object is going to be
    public Transform nextLocation;
    //Where the object is coming from
    public Transform parent;

    public float moveSpeed;
    public void wakeUp()
    {
        //Start at the position
        this.transform.position = parent.position;
    }

    //When the script wakes up, it moves to nextLocation
    void Update()
    {
        if(nextLocation.position!=this.transform.position)
        {
            transform.position = Vector3.Lerp(this.transform.position, nextLocation.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
