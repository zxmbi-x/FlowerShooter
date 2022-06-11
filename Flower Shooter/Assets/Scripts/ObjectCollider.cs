using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectCollider : MonoBehaviour
{
	public float speed = 5f;
	public Vector3 direction;

	void Start()
	{
		// moves on y axis
		direction = new Vector3(0, 1, 0);
	}

	void Update()
	{
		// negative so falling downwards, unlike bullets
		transform.Translate(direction * -speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameObject.CompareTag("Flower") && collision.CompareTag("Bullet"))
		{
			GameManager.instance.AddScore();
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}

		else if (gameObject.CompareTag("Flower") && collision.CompareTag("Player"))
		{
			GameManager.instance.LoseGame();
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}

		else if (gameObject.CompareTag("Coin") && collision.CompareTag("Player"))
		{
			GameManager.instance.AddScore();
			Destroy(gameObject);
		}
	}
}
