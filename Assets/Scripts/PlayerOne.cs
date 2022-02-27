using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    [SerializeField]
    private float racketSpeed = 1f;
    private Vector2 racketDirection;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
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
}
