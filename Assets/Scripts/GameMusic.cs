using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour {

	//private GameObject[] music;

	void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        Debug.Log("Awake");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        Debug.Log("scene> " + currentScene.name);

        if (currentScene.name != "04_MainLevel")
        {
            // Stops playing music in level 1 scene
            
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlaySound()
    {
        SoundManager.PlaySound("barrel");
    }

}
