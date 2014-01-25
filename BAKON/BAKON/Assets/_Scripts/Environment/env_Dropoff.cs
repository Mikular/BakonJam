﻿using UnityEngine;
using System.Collections;

public class env_Dropoff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	void OnCollisionEnter2D (Collision2D coll)
	{
		
		if (coll.gameObject.tag=="Player") 
		{

			ent_Player obj = coll.gameObject.GetComponent<ent_Player>();
			if(obj.HasBacon)
			{

				// Increase player score
				ent_Statistics stats = coll.gameObject.GetComponent<ent_Statistics>();
				stats.AddScore();

				obj.HasBacon = false;


				// Reset bakonz
				foreach(var bacon in GameObject.FindGameObjectsWithTag ("Bakon"))
				{
					bacon.transform.position = GameObject.FindWithTag("bacon_pedestal").transform.position;
					bacon.transform.parent = null;
				}


			} // CLOSE if(obj.HasBacon)
		}
	}

}
