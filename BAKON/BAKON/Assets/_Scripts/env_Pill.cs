﻿using UnityEngine;
using System.Collections;

public class env_Pill : MonoBehaviour {

	public env_Level level;

	public RealityState pillReality;

	// Use this for initialization
	void Start () {
		level = GameObject.FindGameObjectWithTag ("Level").GetComponent<env_Level>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		print ("collison");
		if (coll.gameObject.tag == "Player")
		{
			level.currentReality = pillReality;
			level.OnRealityAltered();
		}
		Destroy (gameObject);
	}
}