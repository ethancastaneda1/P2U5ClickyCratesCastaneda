using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManagerCS gameManager;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();            
        button.onClick.AddListener(SetDifficulty);                                                                          
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerCS>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + "was clicked");
        gameManager.StartGame(difficulty);
    }
}
