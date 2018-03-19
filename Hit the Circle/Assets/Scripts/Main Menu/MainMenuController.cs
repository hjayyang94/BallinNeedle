using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    Button playButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("Practice");
    }

    void GetButton()
    {
        playButton = GameObject.Find("Shoot Button").GetComponent<Button>();
    }
}
