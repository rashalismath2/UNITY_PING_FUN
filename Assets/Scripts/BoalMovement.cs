using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoalMovement : MonoBehaviour
{
    [SerializeField]
    private float startSpeed=5f;

    [HideInInspector]
    public float racketSpeed=1f;
    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(Launch(1));
    }

    // Update is called once per frame
    public void Restart(int direction)
    {
        rigidBody.velocity = new Vector2(0f,0f);
        transform.position = new Vector2(0f,0f);
        racketSpeed = 1f;
        StartCoroutine(Launch(direction));
    }

    IEnumerator Launch(int direction) {
        
        yield return new WaitForSeconds(2);

        MoveBall(new Vector2(direction, 0));
    }

    void MoveBall(Vector2 direction) {
        direction = direction.normalized;
        var ballSpeed = startSpeed * direction;
        rigidBody.velocity = ballSpeed* racketSpeed;
    }

}
