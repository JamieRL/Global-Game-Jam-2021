using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour
{
	private Transform target;
	private Vector3 spawnPoint;
	public float speed = 1f;
	public float maxFollowDistance = 10;
	public bool isChasing = false;
	private bool isReturning = false;
	public bool hasTriggerRadius = true;

	private Rigidbody2D rigidBody;

	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player") {
			if(!target) {
				target = GameObject.FindWithTag("Player").transform;
				isChasing = true;
				isReturning = false;
			}
		}
	}

	void followTarget() {
		Vector2 targetDirection = target.position - transform.position;
		float distance = Vector2.Distance(transform.position, target.position);

		if(distance > maxFollowDistance) {
			target = null;
			isReturning = true;
			isChasing = false;
		} else {
			moveToPoint(targetDirection);
		}
	}

	void moveToPoint(Vector2 direction) {
		rigidBody.velocity = new Vector2(direction.x * speed, direction.y * speed);
	}

	void returnToSpawn() {
		Vector2 spawnDirection = spawnPoint - transform.position;

		if(spawnPoint == transform.position) {
			isReturning = false;
			stop();
		} else {
			moveToPoint(spawnDirection);
		}
	}

	void stop() {
		rigidBody.velocity = new Vector2(0, 0);
	}

	void Awake() {
		spawnPoint = transform.position;
	}

	// Start is called before the first frame update
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>(); 

		if(!hasTriggerRadius) {
			target = GameObject.FindWithTag("Player").transform;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(isChasing) {
			followTarget();
		} else if(isReturning) {
			returnToSpawn();
		}
	}
}
