using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	bool onetime = false;

	void Update () {

		if (!onetime)
		{
			onetime = true;
			StartCoroutine(PlayWin());
		}
    }
 
	IEnumerator PlayWin()
    {
        Debug.Log("win");
		SoundManager.PlaySound("win");
		yield return new WaitForSeconds(4.0f);	
    }
}