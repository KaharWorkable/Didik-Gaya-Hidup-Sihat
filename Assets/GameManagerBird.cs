using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerBird : MonoBehaviour
{

    public GameObject gameOverCanvas;
    public GameObject scoreCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;

    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(2);
    }

    public void menu()
    {
        SceneManager.LoadScene(1);
    }

}
