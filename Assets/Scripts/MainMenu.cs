using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public int sceneID;
	public Text textComponent;
	public CanvasGroup canvasGroup;

	public SpriteRenderer spriteLucesOff;
    public SpriteRenderer spriteLucesOn;
 
    void Start(){
		textComponent.gameObject.SetActive(true);
		spriteLucesOff.enabled = true;
        spriteLucesOn.enabled = false;
    }

	void Update () {
		if ( Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) )
		{
			spriteLucesOff.enabled = false;
        	spriteLucesOn.enabled = true;
			StartCoroutine(DoFade());
			StartCoroutine(NextLevelAfterWait()); 
		}	
	}  

	IEnumerator NextLevelAfterWait() 
	{
		SoundManager.PlaySound("gamestart");
		textComponent.gameObject.SetActive(false);
		yield return new WaitForSeconds(3.0f);	
		SoundManager.PlaySound("next");
		yield return new WaitForSeconds(4.0f);	
		SceneManager.LoadScene(sceneID);
	}
	

	IEnumerator DoFade()
	{		
		while (canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += Time.deltaTime / 5;
			yield return null;
		}
		//canvasGroup.interactable = false;
		yield return null;
	}
}