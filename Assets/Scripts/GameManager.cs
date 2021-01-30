using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gm = null;
	public bool isGameOver = true;
	public string SceneToLoad = "";

	private void Awake() {
		if(gm == null) {
			gm = this;
		} else if(gm != this) {
			Destroy(gameObject);
		}

		if(SceneToLoad =="") {
			SceneToLoad = SceneManager.GetActiveScene().name;
		}
	}

	private void reloadGame() {
		SceneManager.LoadScene(SceneToLoad);
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
