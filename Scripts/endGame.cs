using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    [SerializeField] GameObject oldManager;
    [SerializeField] GameObject panel;
    public bool isfinal;
    private void Start()
    {
        oldManager = GameObject.Find("GAME_MANAGER");
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Playerr"))
        {
            EndGame(true);
        }
        
    }
    public void EndGame(bool isTrue)
    {
        if (isfinal)
        {
            if (gameObject.GetComponent<Teleport>().TF == true)
            {
                panel.SetActive(true);
                StartCoroutine("backMainMenu", 0.3f);
            }
            return;
        }
        else if (isTrue)
        {
            panel.SetActive(true);
            StartCoroutine("backMainMenu", 0.3f);
        }
    }
    IEnumerator backMainMenu()
    {
        oldManager.SetActive(false);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
