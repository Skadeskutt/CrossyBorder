﻿using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
	public enum directions
	{
		left,
		right
	}

	public GameObject car;

	public Sprite[] sprites = new Sprite[2];
	GameMaster GM;
	float spawnTimer;
	bool spawned;
	public directions SpawnDir;

	void Start ()
	{	
		GM = GameObject.Find ("GameMaster").GetComponent<GameMaster> ();
	}

	void Update ()
	{
		
		spawnTimer += Time.deltaTime;
		if (spawnTimer > 2)
		{
			SpawnCar ();
			spawnTimer = 0;

		}

	}

	public void SpawnCar ()
	{
        GameObject spawnedCar = Instantiate(car, transform.position, Quaternion.identity) as GameObject;
        CarController carControl = spawnedCar.GetComponent<CarController>();

        if (SpawnDir == directions.left)
        {
            if (GM.fbiTroops)
            {
                spawnedCar.transform.position = new Vector2(transform.position.x - Random.Range(0, 6), transform.position.y);
                carControl.MoveLeft();
                spawnedCar.GetComponent<SpriteRenderer>().sprite = sprites[2];
            }
            else
            {
                spawnedCar.transform.position = new Vector2(transform.position.x - Random.Range(0, 6), transform.position.y);
                carControl.MoveLeft();
                spawnedCar.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }

        }
        else
        {
            if (GM.fbiTroops)
            {
                carControl.MoveRight();
                spawnedCar.transform.position = new Vector2(transform.position.x + Random.Range(0, 10), transform.position.y);
                spawnedCar.GetComponent<SpriteRenderer>().sprite = sprites[3];


            }
            else
            {
                carControl.MoveRight();
                spawnedCar.transform.position = new Vector2(transform.position.x + Random.Range(0, 10), transform.position.y);
                spawnedCar.GetComponent<SpriteRenderer>().sprite = sprites[1];

            }
        }
    }
}
