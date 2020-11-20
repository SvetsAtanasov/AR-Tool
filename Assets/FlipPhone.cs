using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlipPhone : MonoBehaviour
{

    public Text text;

    void Update()
    {
        Flip();
    }

    void Flip()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                SceneManager.LoadScene(1);
                break;

            case ScreenOrientation.LandscapeRight:
                text.text = "Flip counterclockwise";
                break;
        }
    }
}