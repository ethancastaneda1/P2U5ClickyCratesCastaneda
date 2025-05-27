using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.Sockets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
public class GameManagerCS : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
  //  public GameObject pauseMenuUI;
    private float spawnRate = 1.0f;
    private int score;
    private int lives;
    //bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           
        }
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
        
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        lives = 3;
        livesText.text = "Lives:" + lives;
        scoreText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);



    }
    public void Updatelives(int livesToChange)
    {
        lives += livesToChange;
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives:" + lives;
    }
  //  void PauseMenu()
  //  {
     //   if (Input.GetKeyDown(KeyCode.Escape)) 
     //   {
      //      if (Input.GetKeyDown(KeyCode.Escape) && isGameActive == true)
      //      {
       //         if (gamePaused == false)
       //         {
        //            Time.timeScale = 0f;
         //           pauseMenuUI.SetActive(true);
         //           gamePaused = true;
        //            isGameActive = false;
      //          }
       //     }
     //   }
      //  else if(gamePaused == true)
     ///   {
       //     gamePaused = false;
     //       Time.timeScale = 1f;
      //      pauseMenuUI.SetActive(false);
       //     isGameActive = true;
      //  }
   // }
}
