using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    //If a button is hovered over, the description gameObject,
    //which is the parent of the text,
    //follows the mouse

    public GameObject desc;

    public void hover()
    {
        desc.SetActive(true);
    }

    public void noHover()
    {
        desc.SetActive(false);
    }
    void Update()
    {
        if(desc.activeSelf)
        {
            desc.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,desc.transform.position.z);
        }
    }
}
