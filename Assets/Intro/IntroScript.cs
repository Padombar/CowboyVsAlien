using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class IntroScript : MonoBehaviour
{

    public MovieTexture MovieTexture;
    public AudioClip Audio;
    private AudioSource _audio;

    void Start ()
	{
	    GetComponent<RawImage>().texture = MovieTexture;
	    _audio = GetComponent<AudioSource>();
	    _audio.clip = Audio;
        MovieTexture.Play();
        _audio.Play();
        AudioListener.volume = 1f;

    }
	

	void Update () {
	    if (MovieTexture != null && !MovieTexture.isPlaying)
	    {
            MovieTexture.Stop();
            _audio.Stop();
	        SceneManager.LoadScene("MainMenu");

	    }
	}
}
