using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int startingHealth = 100; 
	public int currentHealth;          
	bool damaged;      
	public float hSliderValue = 100.0F;


	void Start() {
		currentHealth = startingHealth;
		PlayerPrefs.SetInt ("playerHealth", currentHealth);

//		GameObject healthBar = GameObject.FindGameObjectWithTag ("HealthBar");

	}
		
//	void OnGUI() {
//		GUI.Label(new Rect((Screen.width - 300) /2 - 30, 15, 100, 90), currentHealth.ToString());
//		hSliderValue = GUI.HorizontalSlider(new Rect((Screen.width - 300) /2, 25, 300, 90), currentHealth, 0, 0);
//	}
		
	// Update is called once per frame
	void Update () {
		currentHealth = PlayerPrefs.GetInt ("playerHealth");

//		UpdateHealthBar (currentHealth);

	}

//	void UpdateHealthBar () {
//		hSliderValue.
//		Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)val / MaxHealth);
//	}

	public void LostMinigame() {
		Slider slider;
		GameObject temp = GameObject.Find("HealthBar");
		slider = temp.GetComponent<Slider> ();
		slider.value -= currentHealth; 
		Debug.Log ("CurrentHealth " + currentHealth);

		if (currentHealth >= 70) {
			slider.GetComponent<Image> ().color = Color.green;
//			healthSlider.GetComponent<Image> ().color = Color.green;
		} else if (currentHealth < 70 && currentHealth >= 40) {
			slider.GetComponent<Image> ().color = Color.yellow;
		} else if (currentHealth < 40 && currentHealth > 0) {
			slider.GetComponent<Image> ().color = Color.red;
		} else if (currentHealth <= 0) {			
			Dead ();
		}
	}


	void Dead() {
		// Player is dead
		Debug.Log("DEAD");

	}
}
