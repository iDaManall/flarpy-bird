using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //reference to gamecomponent so we can drag drop rigidbody in unity
    public Rigidbody2D myRigidbody;
    //public variable to edit in unity directly
    public float flapStrength;
    //for prompting game over screen on collision
    public LogicScript logic;
    //so you cant still play on game over screen
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // move bird up if space bar is pressed and currently alive
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        // if off screen, game over and dead
        if (transform.position.y > 15 || transform.position.y < -15)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    //bc pipes are solid objects and not triggers
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
