using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject SettingsPage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayIsPressed()
    {
        Invoke("ChangeToGame", 2f);
    }

    public void SettingsIsPressed()
    {
        SettingsPage.SetActive(true);
    }

    public void RemoveSettingsIsPressed()
    {
        SettingsPage.SetActive(false);
    }

    public void QuitGameIsPressed()
    {
        Invoke("CloseMenuScene", 2f);
    }

    void ChangeToGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Testi1");
    }

    void CloseMenuScene()
    {
        Application.Quit();
        Debug.Log("Testi2");
    }
}
