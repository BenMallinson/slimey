using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public float thrust;
    private int chargeTimer = 0;
    public int maxCharge;

    public GameObject playerStart;

    public PlayerCharge playerCharge;

    void Awake () {
        playerCharge = gameObject.GetComponent<PlayerCharge> ();
        playerCharge.setMax (maxCharge);
    }

    void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody2D> ();
        thrust = gameObject.GetComponent<float> ();
        maxCharge = gameObject.GetComponent<int> ();
        playerStart = gameObject.GetComponent<GameObject> ();
    }

    // Update is called once per frame
    void Update () {
        processMovement ();
    }

    void processMovement () {
        if (movementKeyDown () && chargeTimer <= maxCharge) {
            chargeTimer++;
            playerCharge.setCharge (chargeTimer);
        }

        if (Input.GetKeyUp ("right")) {
            addForce (new Vector2 (1, 3));
            resetChargeTimer ();
        } else if (Input.GetKeyUp ("left")) {
            addForce (new Vector2 (-1, 3));
            resetChargeTimer ();
        } else if (Input.GetKeyUp ("up")) {
            addForce (new Vector2 (0, 4));
            resetChargeTimer ();
        }
    }

    void resetChargeTimer () {
        chargeTimer = 0;
        playerCharge.setCharge (chargeTimer);
    }

    void addForce (Vector2 vector2) {
        rigidBody.AddForce (vector2 * ((chargeTimer * 2) + thrust));
    }

    bool movementKeyDown () {
        return Input.GetKey ("right") || Input.GetKey ("left") || Input.GetKey ("up");
    }
}