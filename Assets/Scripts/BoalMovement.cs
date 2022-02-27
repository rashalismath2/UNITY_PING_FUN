using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoalMovement : MonoBehaviour
{
    [SerializeField]
    private float startSpeed=5f;
    [SerializeField]
    private float startDirection = 1f;
    [HideInInspector]
    public float racketSpeed=1f;
    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Launch() {

        yield return new WaitForSeconds(2);

        MoveBall(new Vector2(startDirection,0));
    }

    void MoveBall(Vector2 direction) {
        direction = direction.normalized;
        var ballSpeed = startSpeed * direction;
        rigidBody.velocity = ballSpeed* racketSpeed;
    }

}
