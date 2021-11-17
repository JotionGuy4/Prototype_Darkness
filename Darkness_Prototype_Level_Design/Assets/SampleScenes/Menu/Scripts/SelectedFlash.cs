using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject selectedObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;



    // Update is called once per frame
    void Update()
    {
        if (lookingAtObject == true)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }

    void OnMouseOver()
    {
        Debug.Log("MouseOver detected.");
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if (startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
        
    }

    void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = new Color32(250, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.03f);
            if (flashingIn == true)
            {
                if (blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    redCol -= 50;
                    greenCol -= 50;
                }
            }
            if (flashingIn == false)
            {
                if (blueCol >=250)
                {
                    flashingIn = true;
                }
                else
                {
                    redCol += 50;
                    greenCol += 50;
                }
            }
        }
    }
}
