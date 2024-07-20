﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	public bool ZoomActive;
	public float SizeTarget;
	public Vector3[] Target;

	public Camera Cam;

	public float Speed;

	// Use this for initialization
	void Start () {
		Cam = Camera.main;
	}

	public void LateUpdate()
	{
		if (ZoomActive)
		{
			Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3f, Speed);
			//Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[1], Speed);
		}
		else
		{
			Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, SizeTarget, Speed);
			//Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[0], Speed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
