﻿using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
	public enum States
	{
		gameActive,
		gameDeActive,
		gamePaused,
		gameWon,
		gameLost,

	}

	public States gameState;

	Player player;
	World world;
	//world settings
	public int worldWidth;
	public int worldHeigth;
	public int ladderCount;
	public int maxLadder = 0;
	public float noiseScale;
	public string seed;

	//game state stuff
	public bool gameLoopActive;
	public bool gamePaused;
	public bool gameResetPause;
	public bool roundWon;
	public bool gameLost;
	public bool gameTransition;

	int prevlife;


	//four abilities
	public bool CarpetBombing;
	public bool fbiTroops;
	public bool bearTraps;
	public bool mines;

	public Player Player {
		get
		{
			return player;
		}
	}

	public World World {
		get
		{
			return world;
		}
	}

	void Awake ()
	{
		world = new World (worldWidth, worldHeigth, noiseScale, seed);
		world.GenerateWorld ();
		player = new Player (world);
		prevlife = player.Lives;

		gameState = States.gameDeActive;


	}

	void Update ()
	{
		switch (gameState)
		{
			case States.gameActive:
				UpdateGameActive ();
				break;

			case States.gameDeActive:
				UpdateGameDeActive ();
				break;

			case States.gamePaused:
				UpdateGamePaused ();
				break;

			case States.gameWon:
				UpdateGameWon ();
				break;

			case States.gameLost:
				UpdateGameLost ();
				break;

		}

		if (!player.Alive)
		{
			gameLoopActive = false;
		}

	}
	//handle the game when active
	void UpdateGameActive ()
	{
		gameLoopActive = true;
		gamePaused = false;
		if (Input.GetKeyDown (KeyCode.P))
			gameState = States.gamePaused;

		if (roundWon)
			gameState = States.gameWon;
	}
	//handle the game when deactive
	void UpdateGameDeActive ()
	{
		gameLoopActive = false;
	}

	//handle the game when paused
	void UpdateGamePaused ()
	{
		gamePaused = true;
			
	}
	//handle the game when the player has won
	void UpdateGameWon ()
	{
		//if not last round
		//deactivate cars,lanes,player and everything which will interfeer with the transition
		gameLoopActive = false;

		//move the camera to the top of the wall
		//spawn in politicians
		gameTransition = true;


		//after choose, spin wheel of abilities

		//start next round

		//if last round
		//play victory animation

		//show highscore

	}
	//handle the game when the player has lost
	void UpdateGameLost ()
	{
		//show highscore

		//prompt main menu

		//promt restart
		
	}

	public void ResumeGame ()
	{
		gameState = States.gameActive;
	}

	public void StartGame ()
	{
		gameState = States.gameActive;
	}

	public void RestartLevel ()
	{
		gameResetPause = true;
		GetComponent<CountDown> ().ResetTimer ();

	}

	public void RestartGame ()
	{
		//Application.LoadLevel (0);	



	}

	public void WinRound ()
	{

	}
		
}