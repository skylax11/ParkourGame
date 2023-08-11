using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject panel1;
    [SerializeField] GameObject button;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject panel2;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void settings()
    {
        button.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        panel2.SetActive(true);
    }
    public void mainMenu()
    {
        button.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        panel1.SetActive(false);
        panel2.SetActive(false);

    }
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
    public void howToPlay()
    {
        button.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        panel1.SetActive(true);
    }
}
