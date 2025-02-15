using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image _menu;

    private const int _menuExit = 0;
    private const int _hannah = 1;

    //private int _indexScene = 0;

    public void ExitButten()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void StartButton()
    {
        SceneManager.LoadScene(_hannah);
    }

    public void MenuExits()
    {
        SceneManager.LoadScene(_menuExit);
    }

    public void Pause()
    {
        _menu.gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        _menu.gameObject.SetActive(false);
    }

    public void StartSetting()
    {
        _menu.gameObject.SetActive(true);
    }

    public void MenuSetting()
    {
        _menu.gameObject.SetActive(false);
    }
}
