using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GmaeManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public GameObject startScreen;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playerController =GameObject.Find("player 1").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
        if (playerController.health <= 0)
        {
            gameOver();
        }
    }
    public void pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    public void restart()
    {
        SceneManager.LoadScene("Demo");
        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void start()
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
    }
    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
