using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Blinking : MonoBehaviour {

	public float BlinkTime;
    private string textToBlink;
    private Text textComponent;
   
    void Awake()
    {
        textComponent = GetComponent<Text>();
        //Set the Text that will be blinked from the inspector of the text component
        textToBlink = textComponent.text;
    }
 
    private void OnEnable()
    {
        StartCoroutine(Blink());
    }
 
    IEnumerator Blink()
    {
        while (true)
        {
            textComponent.text = textToBlink;
            yield return new WaitForSeconds(BlinkTime);
            textComponent.text = string.Empty;
            yield return new WaitForSeconds(BlinkTime);
        }
    }
}
