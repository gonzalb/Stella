using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	public int sceneID;
	//public Text textComponent;
	public CanvasGroup canvasGroup;
 
    void Start(){
		//textComponent.gameObject.SetActive(true);
		
    }

	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			
			StartCoroutine(DoFade());
			StartCoroutine(NextLevelAfterWait()); 
		}	
	}  

	IEnumerator NextLevelAfterWait() 
	{
		//textComponent.gameObject.SetActive(false);
		//yield return new WaitForSeconds(3.0f);	
		SoundManager.PlaySound("skip");
		yield return new WaitForSeconds(4f);	
		SceneManager.LoadScene(sceneID);
	}
	

	IEnumerator DoFade()
	{		
		while (canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += Time.deltaTime / 4;
			yield return null;
		}
		//canvasGroup.interactable = false;
		yield return null;
	}
}