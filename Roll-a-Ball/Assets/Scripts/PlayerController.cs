﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rigidBody;
	private int count;

	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = string.Empty;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rigidBody.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if(count >= 10)
		{
			winText.text = "You fucking win!";
		}
	}
}
