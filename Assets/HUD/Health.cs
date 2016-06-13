using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {
	private Slider slider;
	private int currentHealth;
//	private Color MaxHealthColor = Color.green;
//	private Color MinHealthColor = Color.red;
	public Image Fill;
	GameObject gameOver;
	GameObject gameWon;
	public float waitXsecondsToGoBackToGame = 5.0f;



	// Use this for initialization
	void Start () {
		gameOver = GameObject.FindGameObjectWithTag ("GameOver");
		gameOver.SetActive (false);
	    gameWon = GameObject.FindGameObjectWithTag("GameWon");
        gameWon.SetActive(false);

		slider = GameObject.Find("HealthSlider").GetComponent<Slider>();
		slider.minValue = 0f;
		slider.maxValue = 100f;
		currentHealth = PlayerPrefs.GetInt ("playerHealth");
		slider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
//		gameOver.SetActive(false);
		UpdateHealthBar(); 
	}

	private void UpdateHealthBar() {
		currentHealth = PlayerPrefs.GetInt ("playerHealth");
		slider.value = currentHealth;

		if (currentHealth>= 70) {
//			slider.GetComponent<Image> ().color = Color.green;
			//			healthSlider.GetComponent<Image> ().color = Color.green;
		} else if (currentHealth < 70 && currentHealth >= 40) {
//			slider.GetComponent<Image> ().color = Color.yellow;
		} else if (currentHealth < 40 && currentHealth > 0) {
//			slider.GetComponent<Image> ().color = Color.red;
		} else if (currentHealth <= 0) {			
			Dead ();
		}


//		Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)PlayerPrefs.GetInt ("playerHealth") / 100f);
	}

	void Dead() {
		Debug.Log ("DEAD");
		gameOver.SetActive (true);
		executeWait ();

	}

	private void executeWait()
	{
		StartCoroutine(Wait(waitXsecondsToGoBackToGame));
	}

	private IEnumerator Wait(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		JumpToStartMenu ();
	}

	void JumpToStartMenu () {
		PlayerPrefs.SetInt ("playerHealth", 100);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
	}
}
