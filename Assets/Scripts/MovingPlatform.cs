using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Player on the platform");
		if(other.gameObject.tag == "Player") {
			other.transform.parent = transform;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			other.transform.parent = null;
		}
	}

	void Update()
	{

	}
}
