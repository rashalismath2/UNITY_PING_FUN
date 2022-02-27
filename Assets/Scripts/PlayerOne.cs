using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOne : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    [SerializeField]
    private float racketSpeed = 1f;
    private Vector2 racketDirection;
    private Text playerScoreText;
    private int playerScore = 0;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerScoreText = GameObject.Find("PlayerOneScore").GetComponent<Text>();
    }
    void Start()
    {
        playerScoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxis("Vertical");
        racketDirection = new Vector2(0,directionY);
    }
    void FixedUpdate()
    {
        Vector2 speed = racketDirection * racketSpeed;
        rigidBody.velocity = speed;
 
    }

	public void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Boal")) {
            var boalScript = collision.gameObject.GetComponent<BoalMovement>();
            boalScript.racketSpeed = boalScript.racketSpeed * rigidBody.velocity.y;
        }
	}
    public void SetPlayerScore() {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }
}
