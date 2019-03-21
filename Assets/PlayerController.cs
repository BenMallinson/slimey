using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        thrust = gameObject.GetComponent<float>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if(Input.GetKeyDown("right")) {
            Debug.Log("right pressed");
            Vector2 vec2 = new Vector2(2, 4);
            rigidBody.AddForce(vec2 * thrust);
        } else if(Input.GetKeyDown("left")) {
            Debug.Log("left pressed");
            Vector2 vec2 = new Vector2(-2, 4);
            rigidBody.AddForce(vec2 * thrust);
        } else if(Input.GetKeyDown("up")) {
             Debug.Log("up pressed");
            Vector2 vec2 = new Vector2(0, 4);
            rigidBody.AddForce(vec2 * thrust);
        }
    }
}
