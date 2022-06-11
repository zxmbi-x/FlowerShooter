using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject[] objectsToSpawn;
	[SerializeField] private GameObject[] endPointsToMoveTo;

	private int currentEndPointCount = 0;
	private float timeToSpawn = 1f;
	private float timeLeftToSpawn;
	public float speed = 5f;

	void Start()
	{
		// if no end points, spawn from spawner's actual position
		if (endPointsToMoveTo.Length < 1)
		{
			endPointsToMoveTo[0] = gameObject;
		}

		timeLeftToSpawn = timeToSpawn;
	}

	void Update()
	{
		SpawnObject();

		if (Vector2.Distance(gameObject.transform.position, endPointsToMoveTo[currentEndPointCount].transform.position) > 0.01f)
		{
			gameObject.transform.position = new Vector2(Random.Range(endPointsToMoveTo[0].transform.position.x, endPointsToMoveTo[1].transform.position.x), gameObject.transform.position.y);
		}

		else
		{
			currentEndPointCount++;
			if (currentEndPointCount >= endPointsToMoveTo.Length)
			{
				currentEndPointCount = 0;
			}
		}
	}

	private void SpawnObject()
	{
		if (timeLeftToSpawn > 0)
		{
			timeLeftToSpawn -= Time.deltaTime;
		}

		else
		{
			timeLeftToSpawn = timeToSpawn;
			GameObject randomObject = objectsToSpawn[UnityEngine.Random.Range(0, objectsToSpawn.Length)];
			Instantiate(randomObject, gameObject.transform.position, gameObject.transform.rotation);
		}
	}
}
