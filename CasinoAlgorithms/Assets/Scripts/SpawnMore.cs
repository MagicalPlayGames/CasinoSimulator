using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMore : MonoBehaviour
{
    /*summary
     ////////
     Simple menu expansion script
     If a button has this script, when it is pressed
     it expands the next level of the menu, and gets rid of
     any menu option's children that are in myNeighbors
    */
    //The next level of the menu
    public GameObject[] toSpawn;
    //Any menu option on my level
    public SpawnMore[] myNeighbors;

    //For all myNeighbors, call despawn
    void despawnOthers()
    {
        foreach(SpawnMore script in myNeighbors)
        {
            script.despawn();
        }
    }

    //set all menu options on the next level of this menu to inactive
    public void despawn()
    {
        foreach(GameObject Object in toSpawn)
        {
            if(Object.GetComponent<SpawnMore>()!=null)
            {
                foreach(GameObject obj in Object.GetComponent<SpawnMore>().toSpawn)
                {
                    obj.SetActive(false);
                }
            }
            Object.SetActive(false);
        }
    }

    //If this button is clicked,
    //despawnOthers(), and set all my children in the next level to active,
    //or despawn() if I am clicked when already expanded
    public void spawnMore()
    {
        if(toSpawn[0].activeSelf)
        {
            despawn();
            return;
        }
        despawnOthers();
        foreach(GameObject Object in toSpawn)
        {
            Object.SetActive(true);
            Object.GetComponent<Spawned>().wakeUp();
            if(Object.GetComponent<SpawnMore>()!=false)
            {
                Object.GetComponent<SpawnMore>().despawnOthers();
            }
        }
    }
}
