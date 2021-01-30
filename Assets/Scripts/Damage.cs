using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	public int damageAmount = 1;

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Collision");

		if(collision.gameObject.GetComponent<Health>() != null) {
			collision.gameObject.GetComponent<Health>().damageHealth(damageAmount);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
