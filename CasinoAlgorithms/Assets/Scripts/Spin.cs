using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    /*
     Spins the Card Rings
     */
    //number of spins left (numberOfSpins/2 = actual spins)
    public int numberOfSpins;
    //The number of spins at the start
    public int startNofS;
    //The current rotation speed
    public float rotateSpeed;
    //The starting rotation speed
    public float firstRotationSpeed;

    public ColorChanger colorScript;
    public VariableManager vmScript;

    //Initialize
    void Start()
    {
        vmScript.changeSpinValues();
        reset();
    }

    //Slows down the wheel until it stops
    //and sets the finished trigger when it stops
    IEnumerator slowDown()
    {
        yield return new WaitForSeconds(0.3f);
        if (Mathf.Abs(rotateSpeed) > 10.0f && numberOfSpins > 0)
        {
            rotateSpeed -= 1/firstRotationSpeed*(numberOfSpins);
            StartCoroutine(slowDown());
        }
        else if(!colorScript.isSet)
        {
            colorScript.isSet = true;
            colorScript.drawLine();
        }
    }

   //Rotates the wheel until it stops
    void Update()
    {
        if (Mathf.Abs(rotateSpeed) > 10.0f && numberOfSpins>0)
        {
            transform.Rotate(new Vector3(1, 0, 0), rotateSpeed * Time.deltaTime);
        }
    }



    //Respins the wheel, and resets all variables
    public void reset()
    {
        colorScript.isSet = false;
        numberOfSpins = ((startNofS+1)*2);
        rotateSpeed = firstRotationSpeed;
        StartCoroutine(slowDown());
    }
}
