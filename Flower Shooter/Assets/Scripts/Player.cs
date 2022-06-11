using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float playerSpeed = 5f;

	private Camera mainCamera;
	private Vector2 screenBounds;
	private float objectWidth;
	private float objectHeight;

	public GameObject bullet;
	public float timeBetweenBullets = 0.5f;
	private float timeUntilNextBullet;

	void Start()
	{
		mainCamera = Camera.main;
		timeUntilNextBullet = timeBetweenBullets;

		// set the bounds of screen to use in LateUpdate
		screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
		objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
		objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
	}

	void Update()
	{
		Move();
		Shoot();
	}

	void LateUpdate()
	{
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
		viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
		transform.position = viewPos;
	}

	private void Move()
	{
		float horizontalSpeed = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
		float verticalSpeed = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
		gameObject.transform.Translate(horizontalSpeed, verticalSpeed, 0);
	}

	private void Shoot()
	{
		timeUntilNextBullet += Time.deltaTime;

		// gun not ready
		if (timeUntilNextBullet < timeBetweenBullets)
		{
			return;
		}

		if (Input.GetButton("Fire1") || Input.GetButton("Jump"))
		{
			CreateBullet();
			timeUntilNextBullet = 0;
		}
	}

	private void CreateBullet()
	{
		Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
		timeUntilNextBullet = timeBetweenBullets;
	}
}
