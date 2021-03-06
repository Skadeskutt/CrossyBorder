﻿using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
	GameMaster GM;
    private bool CHECKED = false;

	void Start ()
	{
		
		GM = GameObject.Find ("GameMaster").GetComponent<GameMaster> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.transform.tag == "Player")
		{
            if(!CHECKED) {
                CHECKED = true;
                GM.ladderCount++;
                GetComponent<CustomAudioSource>().PlayOnce();
                GetComponent<SpriteRenderer>().enabled = false;
			    Destroy (this.gameObject, 0.204f);
            }
            
		}
	}
}
