using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	public int sceneID;
	public Text textComponent;
	public Button buttonComponent;
 
    void Start(){
		textComponent.gameObject.SetActive(false);
		buttonComponent.gameObject.SetActive(false);
    }

	void Update () {		
			StartCoroutine(NextLevelAfterWait()); 		
	}  

	IEnumerator NextLevelAfterWait() 
	{
		yield return new WaitForSeconds(4.0f);		
		textComponent.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.0f);	
		buttonComponent.gameObject.SetActive(true);
	}
}
