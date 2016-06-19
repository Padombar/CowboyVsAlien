using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiFader : MonoBehaviour {

    private Image image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        image.rectTransform.offsetMin = new Vector2(0, 0);
        image.rectTransform.offsetMax = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
	void Update () {
	    
	}

    public void FadeToClear()
    {
        image.color = Color.Lerp(image.color, Color.clear, Time.deltaTime*1);
        if (image.color.a <= 0.05f)
        {
            image.color = Color.clear;
        }
    }

    public void FadeToBlack()
    {
        image.color = Color.Lerp(image.color, Color.black, Time.deltaTime *2);
        if (image.color.a >= 0.95f)
        {
            image.color = Color.black;
        }
    }

    public bool IsBlack()
    {
        return image.color == Color.black;
    }

    public bool IsClear()
    {
        return image.color == Color.clear;
    }
}
