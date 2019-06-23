using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public float thrust;
    private int chargeTimer = 0;
    public int maxCharge;

    public PlayerCharge playerCharge;
    private int jumpCount = 0;
    public int maxJumpCount = 2;
    private bool facingRight = true;

    private SpriteRenderer spriteRenderer;


    void Awake () {
        playerCharge = gameObject.GetComponent<PlayerCharge> ();
        playerCharge.setMax (maxCharge);
        spriteRenderer =  gameObject.GetComponent<SpriteRenderer>();
    }

    void Start () {
        rigidBody = gameObject.GetComponent<Rigidbody2D> ();
        thrust = gameObject.GetComponent<int> ();
        maxCharge = gameObject.GetComponent<int> ();
        maxJumpCount = gameObject.GetComponent<int> ();
    }

    // Update is called once per frame
    void Update () {
        processMovement ();
    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Tile") {
            jumpCount = 0;
        }

          if (col.gameObject.tag == "End") {
            spriteRenderer.color = new Color(255f,255f,255f, Mathf.Lerp(0f, 1f, spriteRenderer.color.a - 0.5f));
            Invoke("LoadNextLevel", 1);
        }

        if (col.gameObject.tag == "Death") {
            ReloadLevel();
        }
    }

    void ReloadLevel() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

       void LoadNextLevel() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene + 1, LoadSceneMode.Single);
    }

    void processMovement () {
        if (canJump () && movementKeyDown () && chargeTimer <= maxCharge) {

            chargeTimer++;
            playerCharge.setCharge (chargeTimer);
        }

        if (canJump ()) {
            if (Input.GetKeyUp ("right")) {
                if (!facingRight) {
                    Flip ();
                    facingRight = true;
                }
                jumpCount++;
                addForce (new Vector2 (2, 3));
                resetChargeTimer ();

            } else if (Input.GetKeyUp ("left")) {
                if (facingRight) {
                    Flip ();
                    facingRight = false;
                }
                jumpCount++;
                addForce (new Vector2 (-2, 3));
                resetChargeTimer ();

            } else if (Input.GetKeyUp ("up")) {
                jumpCount++;
                addForce (new Vector2 (0, 4));
                resetChargeTimer ();
            }
        }
    }

    void Flip () {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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

    bool canJump () {
        return jumpCount < maxJumpCount;
    }
}
