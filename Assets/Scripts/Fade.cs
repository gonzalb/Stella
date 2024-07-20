using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	public CanvasGroup canvasGroup;
	public Button[] buttonComponent;


	void Start()
	{

		for (int i=0; i < buttonComponent.Length; i++)
		{
			buttonComponent[i].gameObject.SetActive(false);
		}

		FadeMe();
		
		
	}

	public void FadeMe()
	{
		StartCoroutine(DoFade());
	}

	IEnumerator DoFade()
	{
		while(canvasGroup.alpha>0)
		{
			canvasGroup.alpha -= Time.deltaTime / 3;
			yield return null;
		}


		for (int i=0; i < buttonComponent.Length; i++)
		{
			buttonComponent[i].gameObject.SetActive(true);
		}

		yield return null;
		
	}
}
