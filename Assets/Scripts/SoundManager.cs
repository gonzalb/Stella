using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip jump00Sound;
	public static AudioClip jump01Sound;
	public static AudioClip jump02Sound;

	public static AudioClip death00Sound;
	public static AudioClip death01Sound;
	public static AudioClip death02Sound;

	public static AudioClip barrelSound;
	public static AudioClip stairsSound;
	public static AudioClip footstepsSound;

	public static AudioClip gamestartSound;
	public static AudioClip nextSound;
	public static AudioClip skipSound;
	public static AudioClip winSound;
	public static AudioClip countdownSound;
	public static AudioClip continueSound;

	public static bool musicON = true;

	static AudioSource AudioSource;

	// Use this for initialization
	public void Start () {	

		jump00Sound = Resources.Load<AudioClip>("jump00");
		jump01Sound = Resources.Load<AudioClip>("jump01");
		jump02Sound = Resources.Load<AudioClip>("jump02");

		death00Sound = Resources.Load<AudioClip>("death00");
		death01Sound = Resources.Load<AudioClip>("death01");
		death02Sound = Resources.Load<AudioClip>("death02");

		barrelSound = Resources.Load<AudioClip>("barrel");
		stairsSound = Resources.Load<AudioClip>("stairs");
		footstepsSound = Resources.Load<AudioClip>("footsteps");

		gamestartSound = Resources.Load<AudioClip>("gamestart");
		nextSound = Resources.Load<AudioClip>("next");
		skipSound = Resources.Load<AudioClip>("skip");
		winSound = Resources.Load<AudioClip>("win");
		countdownSound = Resources.Load<AudioClip>("countdown");
		continueSound = Resources.Load<AudioClip>("continue");

		AudioSource = GetComponent<AudioSource>();
	}
	
	public static void PlaySound (string clip)
	{
		if ((musicON) && (AudioSource != null))
		{
			switch (clip)
			{			
				case "gamestart":
					AudioSource.PlayOneShot(gamestartSound);
					break;	

				case "next":
					AudioSource.PlayOneShot(nextSound);
					break;	

				case "barrel":
					AudioSource.PlayOneShot(barrelSound);
					break;	

				case "jump00":
					AudioSource.PlayOneShot(jump00Sound);
					break;

				case "jump01":
					AudioSource.PlayOneShot(jump01Sound);
					break;

				case "jump02":
					AudioSource.PlayOneShot(jump02Sound);
					break;

				case "death00":
					AudioSource.PlayOneShot(death00Sound);
					break;

				case "death01":
					AudioSource.PlayOneShot(death01Sound);
					break;

				case "death02":
					AudioSource.PlayOneShot(death02Sound);
					break;
				
				case "stairs":
					AudioSource.PlayOneShot(stairsSound);
					break;

				case "footsteps":
					AudioSource.PlayOneShot(footstepsSound);
					break;

				case "skip":
					AudioSource.PlayOneShot(skipSound);
					break;

				case "win":
					AudioSource.PlayOneShot(winSound);
					break;				

				case "continue":
					AudioSource.PlayOneShot(continueSound);
					break;
				
				case "countdown":
					AudioSource.PlayOneShot(countdownSound);
					break;
			}
		}			
	}	
	
	public static void PlayMusic()
	{
		AudioSource.Play();
	}

	public static void PauseMusic()
	{
		AudioSource.Pause();
	}
}
