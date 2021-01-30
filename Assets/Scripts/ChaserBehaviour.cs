using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour
{
	public Transform target;
	public float speed = 1f;
	public float minFollowDistance = 0;

	private Rigidbody2D rigidBody;


	// Start is called before the first frame update
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>(); 
		if(!target) {
			target = GameObject.FindWithTag("Player").transform;
		}
	}

	// Update is called once per frame
	void Update()
	{
		//transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		Vector2 targetDirection = target.position - transform.position;
		float distance = Vector2.Distance(transform.position, target.position);

		if(distance > minFollowDistance) {
			rigidBody.velocity = new Vector2(targetDirection.x * speed, targetDirection.y * speed);
		} else {
			rigidBody.velocity = new Vector2(0, 0);
		}
	}
}
