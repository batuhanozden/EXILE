using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditScene;

    public void Start()
    {
        creditScene.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("2- Game");
    }

    public void CreditScene()
    {
        creditScene.SetActive(true);
    }

    public void BackButton()
    {
        creditScene.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
