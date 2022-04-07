using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationComplete : MonoBehaviour
{
    //If the top or bottom board is hit by a specific card, the number of spins decreases, Here, 1 real spin is actually 2 spins
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Card")
        {
            if (other.gameObject.GetComponent<CardNumber>() != null)
            {
                if (other.gameObject.GetComponent<CardNumber>().cardRow == 1)
                    other.gameObject.transform.parent.GetComponent<Spin>().numberOfSpins--;
            }
        }
    }
}
