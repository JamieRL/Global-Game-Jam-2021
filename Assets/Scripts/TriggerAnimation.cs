using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
	public Animator animator;
	public GameObject triggeringObject;

	// Start is called before the first frame update
	void Start()
	{
		if(animator == null) {
			animator = GetComponent<Animator>();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject == triggeringObject) {
			animator.SetBool("activate", true);
		} else {
			Debug.Log("NOT THE TARGET");
		}
	}
}
