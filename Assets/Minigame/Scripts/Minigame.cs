using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {
	GameObject[] alienArray = new GameObject[9];

	Renderer rendStrikes1;
	Renderer rendStrikes2;

	Renderer rendCounter0;
	Renderer rendCounter1;
	Renderer rendCounter2;
	Renderer rendCounter4;

	Color defaultColor;


	public int maximumVisibleAliens = 1;
	bool gameActive = true;
	int killedAliens = 0;

	private float nextActionTime = 1.0f;
	private float minimumVisibleTime = 0.5f;
	private float maximumVisibleTime = 1.5f;

	private int strikesAllowed = 3;
	private int strikes = 0;
	public float waitXsecondsToGoBackToGame = 3.0f;

	public int actualAlien;
	GameObject wonText;
	GameObject loseText;

//	void Awake() {
//		if (killedAliens != PlayerPrefs.GetInt ("aliensKilled")) {
//			killedAliens = PlayerPrefs.GetInt ("aliensKilled");
//		}
//		if (strikes != PlayerPrefs.GetInt ("strikes")) {
//			strikes = PlayerPrefs.GetInt ("strikes");
//		}
//	}

	// Use this for initialization
	void Start () {

		UnityEngine.SceneManagement.SceneManager.LoadScene ("HUD", UnityEngine.SceneManagement.LoadSceneMode.Additive);

//		PlayerPrefs.SetInt ("aliensKilled", 0);
//		PlayerPrefs.SetInt ("strikes", 0);

		nextActionTime = Time.time + Random.Range (minimumVisibleTime, maximumVisibleTime);

		wonText = GameObject.FindGameObjectWithTag ("WonText");
		wonText.SetActive (false);
		loseText = GameObject.FindGameObjectWithTag ("LoseText");
		loseText.SetActive (false);

		GameObject alien1 = GameObject.FindGameObjectWithTag ("Alien1");
		GameObject alien2 = GameObject.FindGameObjectWithTag ("Alien2");
		GameObject alien3 = GameObject.FindGameObjectWithTag ("Alien3");
		GameObject alien4 = GameObject.FindGameObjectWithTag ("Alien4");
		GameObject alien5 = GameObject.FindGameObjectWithTag ("Alien5");
		GameObject alien6 = GameObject.FindGameObjectWithTag ("Alien6");
		GameObject alien7 = GameObject.FindGameObjectWithTag ("Alien7");
		GameObject alien8 = GameObject.FindGameObjectWithTag ("Alien8");
		GameObject alien9 = GameObject.FindGameObjectWithTag ("Alien9");

		alienArray [0] = alien1;
		alienArray [1] = alien2;
		alienArray [2] = alien3;
		alienArray [3] = alien4;
		alienArray [4] = alien5;
		alienArray [5] = alien6;
		alienArray [6] = alien7;
		alienArray [7] = alien8;
		alienArray [8] = alien9;

		actualAlien = Random.Range (0, 8);


		GameObject strike1 = GameObject.FindGameObjectWithTag ("Strike1");
		GameObject strike2 = GameObject.FindGameObjectWithTag ("Strike2");

		rendStrikes1 = strike1.GetComponent ("Renderer") as Renderer;
		rendStrikes2 = strike2.GetComponent ("Renderer") as Renderer;


		GameObject counter0 = GameObject.FindGameObjectWithTag ("Counter0");
		GameObject counter1 = GameObject.FindGameObjectWithTag ("Counter1");
		GameObject counter2 = GameObject.FindGameObjectWithTag ("Counter2");
		GameObject counter4 = GameObject.FindGameObjectWithTag ("Counter4");

		rendCounter0 = counter0.GetComponent ("Renderer") as Renderer;
		rendCounter1 = counter1.GetComponent ("Renderer") as Renderer;
		rendCounter2 = counter2.GetComponent ("Renderer") as Renderer;
		rendCounter4 = counter4.GetComponent ("Renderer") as Renderer;

		defaultColor = rendCounter0.material.GetColor ("_Color");
	}
		

	// Update is called once per frame
	void Update () {
		if (gameActive && Time.timeScale == 1) {
			if (Time.time > nextActionTime) {
				if (!(alienArray [actualAlien].GetComponent<ShowAndHide> ().IsAlienUp ())) {				
					GetAlienUp ();
				} else {
					alienArray [actualAlien].GetComponent<ShowAndHide> ().AlienDown ();

					// Not the same Alien two times in a row.
					int temp = Random.Range (0, 8);
					while (actualAlien == temp) {
						temp = Random.Range (0, 8);
					}
					actualAlien = temp;
				}
				nextActionTime = Time.time + Random.Range (minimumVisibleTime, maximumVisibleTime);
			}
		} 
	}



	// Only if more than one alien should be visible
//	int AliensVisible () {
//		int counter = 0;
//		for (int i = 0; i < alienArray.Length; i++) {
//			if (alienArray [i].GetComponent<ShowAndHide>().IsAlienUp() ) {
//				counter++;
//			}
//		}
//		Debug.Log ("Counter " + counter);
//		return counter;
//	}


	void GetAlienUp() {
		if (gameActive) {
			alienArray[actualAlien].GetComponent<ShowAndHide> ().AlienUp ();
		}
	}

	public void AlienKilled() {
		if (Time.timeScale == 1) {
			killedAliens++;	
			if (killedAliens == 1) {
				rendCounter0.material.SetColor ("_Color", Color.green);
				rendCounter1.material.SetColor ("_Color", defaultColor);
				rendCounter2.material.SetColor ("_Color", defaultColor);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 2) {
				rendCounter0.material.SetColor ("_Color", defaultColor);
				rendCounter1.material.SetColor ("_Color", Color.green);
				rendCounter2.material.SetColor ("_Color", defaultColor);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 3) {
				rendCounter0.material.SetColor ("_Color", Color.green);
				rendCounter1.material.SetColor ("_Color", Color.green);
				rendCounter2.material.SetColor ("_Color", defaultColor);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 4) {
				rendCounter0.material.SetColor ("_Color", defaultColor);
				rendCounter1.material.SetColor ("_Color", defaultColor);
				rendCounter2.material.SetColor ("_Color", Color.green);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 5) {
				rendCounter0.material.SetColor ("_Color", Color.green);
				rendCounter1.material.SetColor ("_Color", defaultColor);
				rendCounter2.material.SetColor ("_Color", Color.green);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 6) {
				rendCounter0.material.SetColor ("_Color", defaultColor);
				rendCounter1.material.SetColor ("_Color", Color.green);
				rendCounter2.material.SetColor ("_Color", Color.green);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 7) {
				rendCounter0.material.SetColor ("_Color", Color.green);
				rendCounter1.material.SetColor ("_Color", Color.green);
				rendCounter2.material.SetColor ("_Color", Color.green);
				rendCounter4.material.SetColor ("_Color", defaultColor);
			} else if (killedAliens == 8) {
				rendCounter0.material.SetColor ("_Color", defaultColor);
				rendCounter1.material.SetColor ("_Color", defaultColor);
				rendCounter2.material.SetColor ("_Color", defaultColor);
				rendCounter4.material.SetColor ("_Color", Color.green);
			} else if (killedAliens == 9) {
				rendCounter0.material.SetColor ("_Color", Color.green);
				rendCounter1.material.SetColor ("_Color", defaultColor);
				rendCounter2.material.SetColor ("_Color", defaultColor);
				rendCounter4.material.SetColor ("_Color", Color.green);
			} else if (killedAliens == 10) {
				rendCounter0.material.SetColor ("_Color", defaultColor);
				rendCounter1.material.SetColor ("_Color", Color.green);
				rendCounter2.material.SetColor ("_Color", defaultColor);
				rendCounter4.material.SetColor ("_Color", Color.green);
			} 

			if (killedAliens >= 10) {
				gameActive = false;
				wonText.SetActive (true);
				// game gewonnen = 1 game verloren = 0
				PlayerPrefs.SetInt("gameWon", 1);

			}
		}
	}

	void OnMouseDown() {
		if (Time.timeScale == 1 && strikes < strikesAllowed) {
			strikes++;
			if (strikes == 1) {
				rendStrikes1.material.SetColor ("_Color", Color.red);
				rendStrikes2.material.SetColor ("_Color", defaultColor);
			} else if (strikes == 2) {
				rendStrikes1.material.SetColor ("_Color", defaultColor);
				rendStrikes2.material.SetColor ("_Color", Color.red);
			} else if (strikes == 3) {
				rendStrikes1.material.SetColor ("_Color", Color.red);
				rendStrikes2.material.SetColor ("_Color", Color.red);
			}
	
			if (strikes == strikesAllowed) {
				int health = PlayerPrefs.GetInt("playerHealth") - 10;
				PlayerPrefs.SetInt ("playerHealth", health);
				loseText.SetActive (true);
				gameActive = false;
				PlayerPrefs.SetInt("gameWon", 0);

				executeWait ();

				// Nur zum debuggen
//				strikes = 0;	
				// Nur zum debuggen
			}
		}
	}

	private void executeWait()
	{
		StartCoroutine(Wait(waitXsecondsToGoBackToGame));
	}

	private IEnumerator Wait(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		JumpBackToGame ();
	}

	void JumpBackToGame () {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
	}

}