using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private PlayerOne playerOne;
    private PlayerTwo playerTwo;
    private int gameOverScore = 5;
    void Awake()
    {
        playerOne=GameObject.Find("PlayerOne").GetComponent<PlayerOne>();
        playerTwo = GameObject.Find("PlayerTwo").GetComponent<PlayerTwo>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boal") && gameObject.name == "LeftBorder")
        {
            playerTwo.SetPlayerScore();
            CheckGameOver();
            collision.gameObject.GetComponent<BoalMovement>().Restart(-1);
        }
        else if (collision.gameObject.CompareTag("Boal") && gameObject.name == "RightBorder") {
            playerOne.SetPlayerScore();
            collision.gameObject.GetComponent<BoalMovement>().Restart(1);
            CheckGameOver();
        }
    }

    void CheckGameOver() {
        if (playerOne.GetPlayerScore()==gameOverScore || playerTwo.GetPlayerScore() == gameOverScore) {
            SceneManager.LoadScene(2);
        }
    }

}
