using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool fall = false;

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if(Input.GetButtonDown("Jump")) {
			jump = true;
		} else if(Input.GetButtonUp("Jump")) {
			fall = true;
		}
	}

	void FixedUpdate() {
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, fall);
		jump = false;
		fall = false;
	}
}
