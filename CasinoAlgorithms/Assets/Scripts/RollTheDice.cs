using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    /*summary
     ////////
     If the button is pressed, then AlgorithmLink.spin()
     */

    public CheckMatch checkScript;
    public AlgorithmLink algoScript;
    public Spin[] spinScripts;

    public bool canHit;

    //If the button can be hit (when the wheels are not spinning),
    // used the selected algorithm, spin the AlgorithmLink script, and rest/spin all the Card Rings
    public void press()
    {
        if (canHit)
        {
            algoScript.algorithmSelect = algoScript.selected;
            canHit = false;
            algoScript.spin();
            for (int i = 0; i < spinScripts.Length; i++)
                spinScripts[i].reset();
        }
    }

    //The button can be physically pressed
    private void OnMouseDown()
    {
        press();
    }
}
