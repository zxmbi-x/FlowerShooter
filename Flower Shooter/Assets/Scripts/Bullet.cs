using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 5f;
	private Vector3 direction;

	void Start()
	{
		// moving on the y axis
		direction = new Vector3(0, 1, 0);
	}

	void Update()
	{
		transform.Translate(direction * speed * Time.deltaTime);
	}
}
