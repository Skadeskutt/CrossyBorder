﻿using UnityEngine;
using System.Collections;

public class CatapultController : MonoBehaviour
{
	
	GameMaster GM;
	PlayerController playerControl;

	IntPosition2D targetIntPos;
	IntPosition2D intPos;

	int range = 10;
	public bool playerByCatapult;
	public bool activated;
	public bool deStun;

	void Start ()
	{
		GM = GameObject.Find ("GameMaster").GetComponent<GameMaster> ();
		intPos = IntPosition2D.Vector2ToIntPos2D (transform.position);
	}

	void Update ()
	{
		if (playerByCatapult && Input.GetKeyDown (KeyCode.E))
		{
			playerControl.Player.Imortal = true;
			activated = true;
		}
			
		
		if (activated)
		{
			
			playerControl.StunPlayer ();
			//chose a tile
			ChooseTile ();

			//delay tp the player to the tile
			if (playerControl.tpPlayer (new Vector2 (targetIntPos.X, targetIntPos.Y), 1.5f))
			{
				deStun = true;
			}

			if (deStun)
			{
				playerControl.tpDelayTimer = 0;
				if (playerControl.DeStunPlayerDelay (0.5f))
				{
					playerControl.Player.Imortal = false;

					playerControl.stunTimer = 0;
					deStun = false;
					activated = false;

				}
			}

			//handle animations
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "Player")
		{
			playerByCatapult = true;
			playerControl = other.gameObject.GetComponent<PlayerController> ();
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			playerByCatapult = false;
			//playerControl = null;
		}
	}

	void LaunchPlayer ()
	{
		
		
	}

	void ChooseTile ()
	{
		targetIntPos = new IntPosition2D (Random.Range (0, 11), intPos.Y + range);
		CheckTile (targetIntPos);
	}

	void CheckTile (IntPosition2D pos)
	{
		if (GM.World.Tiles [pos.X, pos.Y].Walkable == true)
		{
			LaunchPlayer ();
		} else
		{
			ChooseTile ();
		}

	}
}