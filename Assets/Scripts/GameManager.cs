using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int scene = 4;
	public int sceneWin;
	public int sceneLose;
	public GameObject[] spriteLives;
    public Text scoreText;


	public static int lives = 3;
	public static int score = 0;

	
	private void Start()
	{
		NewGame();
	}

	private void NewGame()
	{		
		score = 0;
		scoreText.text = "score "+score.ToString("00000");
		this.spriteLives = GameObject.FindGameObjectsWithTag("Life");
		CountdownTimerLevel.timeStart=60;
		
		for (int i=0; i<3; i++)
		{
			spriteLives[i].gameObject.SetActive(false);
		}

		for (int i=0; i<lives; i++)
		{
			spriteLives[i].gameObject.SetActive(true);
		}
		
	}

	private void LoadLevel(int index)
    {
        scene = index;

        Camera camera = Camera.main;

        // Don't render anything while loading the next scene to create
        // a simple scene transition effect
        if (camera != null) {
            camera.cullingMask = 0;
        }
		
		Invoke("LoadScene", 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

	public void LevelComplete()
	{
		score += (100*(int)CountdownTimerLevel.timeStart);	
		Debug.Log(score);	
		LoadLevel(sceneWin);
	}

	public void LevelFailed()
	{
		lives--;
		Debug.Log(lives);
		
		if (lives <= 0)
		{ 

			lives=3;	
			CountdownTimerLevel.timeStart = 60;		
			LoadLevel(sceneLose);
			//SceneManager.LoadScene("05_Lose");

		} else {
			// Reload current level
			LoadLevel(scene);
		}
	}


	public void IncreaseScore(int barrelScore)
    {
        score = score + barrelScore;
		Debug.Log(score);	
        scoreText.text = "score "+score.ToString("00000");
    }	
}
