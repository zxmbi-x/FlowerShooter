using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

	// destroy on trigger
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
	}

	// destroy on collision
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(collision.gameObject);
	}
}
