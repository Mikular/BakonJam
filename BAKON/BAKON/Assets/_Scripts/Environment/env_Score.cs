﻿using UnityEngine;
using System.Collections;

public class env_Score : MonoBehaviour {

	public float timeGameStarted;
	public int winningScore = 10;
	public ent_Statistics[] players;
	public int winnerIndex;
	public float finalDuration = 1f;

	public GameObject startMenu;
	public GameObject playerObjectContainer;

	private bool begun = false;


	// Use this for initialization
	void Begin () {

		GameObject[] playerObjects = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < playerObjects.Length; i++)
		{
			players[i] = playerObjects[i].GetComponent<ent_Statistics>();
		}
		timeGameStarted = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (!begun && !startMenu.activeSelf)
		{
			Begin ();
			begun = true;
		}

		for (int i = 0; i < players.Length; i++)
		{
			if (players[i].Score == winningScore)
			{
				winnerIndex = i;
				EndGame ();
			}
		}
	}

	void EndGame()
	{
		finalDuration = Time.time - timeGameStarted;
		playerObjectContainer.SetActive (false);
	}

	public string winnerMessage()
	{
		if (winnerIndex == null)
		{
			return "Nobody won!";
		}
		else 
		{
			return "Congratulations, player " + winnerIndex + "!";
		}
	}
}
