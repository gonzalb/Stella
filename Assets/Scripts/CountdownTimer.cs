using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {
	public float timeStart = 9;
	public Text textBox;

	bool soundStarted = false;
	bool count = true;


	// Use this for initialization
	void Start () {
		textBox.text = timeStart.ToString();
		textBox.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	
			if (!soundStarted)
			{
				soundStarted = true;
				StartCoroutine(PlayCountdown());
			}
			
			if (timeStart >= 0)
			{
				Debug.Log("score: "+GameManager.score);
				timeStart -= Time.deltaTime;
				textBox.text = Mathf.Round(timeStart).ToString();
				if (timeStart <= 9.5f)
				{
					textBox.gameObject.SetActive(true); 
				}
			}
			else
			{
				SceneManager.LoadScene(0);
			}	
	}

	IEnumerator PlayCountdown()
    {
        //Debug.Log("countdown");
		SoundManager.PlaySound("countdown");
		yield return new WaitForSeconds(0.0f);	
    }	
}
