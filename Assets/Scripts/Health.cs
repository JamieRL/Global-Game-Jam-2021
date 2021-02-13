using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
	public int health;
	public int numLives;
	public int invincibilityTimeout;
	private float damageTime = 0;
	public bool isAlive = true;
	public int respawnHealthPoints;
	private Vector2 respawnPosition;
	public string LevelToLoad = "";

	// Start is called before the first frame update
	void Start()
	{
		respawnPosition = transform.position;

		if(LevelToLoad == "") {
			LevelToLoad = SceneManager.GetActiveScene().name;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(GameManager.gm) {
			if(GameManager.gm.isGameOver) {
				return;
			}
		}

		if(health <= 0) {
			if(isAlive) {
				Die();
			}
		}
	}
	public virtual void Die() {
		numLives = numLives - 1;
		isAlive = false;
		if(numLives < 0) {
			GameOver();
		}
	}
	public void damageHealth(int damage) {
		if(Time.time - damageTime > invincibilityTimeout) {
			health -= damage;
			damageTime = Time.time;
		}

		if(health <= 0) {
			Debug.Log("YOU DIED");
		}
	}

	public void heal(int healing) {
		health += healing;
	}

	private void GameOver() {
		SceneManager.LoadScene(LevelToLoad);
	}
}
