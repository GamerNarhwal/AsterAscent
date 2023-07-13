using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public variables
    public float horizontalInput; // The horizontal input from the player
    public bool hasSeed; // Flag to indicate if the player has seed
    public bool hasFertilizer; // Flag to indicate if the player has fertilizer
    public bool isOnGround = false; // Flag to indicate if the player is on the ground
    public bool hasWateringCan; // Flag to indicate if the player has a watering can
    public bool levelOver; // Flag to indicate if the level is over
    public int numOfSeeds; // The number of seeds the player has
    public int numOfBagsOFertilizer; // The number of bags of fertilizer the player has
    public int health; // The health of the player
    public int speed; // The speed of the player
    public int jumpForce; // The jump force of the player
    public Rigidbody2D player; // Reference to the player's rigidbody
    public GameObject Fertilizer_UI; // Reference to the fertilizer UI gameobject
    public GameObject Seed_UI; // Reference to the seed UI gameobject
    public GameObject WateringCan_UI; // Reference to the watering can UI gameobject
    public Flower ObjInteract; // Reference to the flower script
    public SpriteRenderer playerSprite; // Reference to the player's sprite renderer
    public List<Sprite> currentPlayerSprite; // List of sprites for the player

    // Private variables
    //private Animator anim; // This is for when we have animations for death/movement

    void Start()
    {
        levelOver = false;
        speed = 5;
        player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        // If the player presses the space key, is on the ground, and the level is not over, make the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !levelOver)
        {
            player.velocity = new Vector2(player.velocity.y, jumpForce);
            isOnGround = false;
        }
    }

    void Movement()
    {
        // If the level is not over, move the player based on horizontal input and update the player's scale based on movement direction
        if (!levelOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
            if (horizontalInput < 0)
            {
                player.transform.localScale = new Vector2(-0.26f, 0.26f);
            }
            else if (horizontalInput > 0)
            {
                player.transform.localScale = new Vector2(0.26f, 0.26f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // If the player collides with a gameobject tagged as "Ground" or "Water", set isOnGround to true
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Water"))
        {
            isOnGround = true;
        }
        // If the player collides with a gameobject tagged as "Wall", stop the player's movement
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("You have hit a wall");
            player.velocity = new Vector2(0, 0);
        }
        // If the player collides with a gameObject tagged as "Damage", force the player to be stopped
        if (other.gameObject.CompareTag("Damage"))
        {
            Debug.Log("You have been oofed");
            player.isKinematic = true;
            //anim.SetTrigger("DeathAnimation") to trigger death/damage animation
            StartCoroutine(WaitAndThenDoSomething(10)); //number supposed to indicate how long to wait
            RestartLevel();
            player.isKinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player triggers a gameobject tagged as "Fertilizer" and does not have seed, give fertilizer to the player and update UI and state
        if (other.gameObject.CompareTag("Fertilizer") && !hasSeed)
        {
            numOfBagsOFertilizer++;
            hasFertilizer = true;
            Fertilizer_UI.SetActive(true);
            Destroy(other.gameObject);
            playerSprite.sprite = currentPlayerSprite[1];
        }
        // If the player triggers a gameobject tagged as "Seeds" and does not have fertilizer but fertilizer has been deposited, give seed to the player and update UI and state
        if (other.gameObject.CompareTag("Seeds") && !hasFertilizer && ObjInteract.depositFertilizer)
        {
            numOfSeeds++;
            hasSeed = true;
            Seed_UI.SetActive(true);
            Destroy(other.gameObject);
            playerSprite.sprite = currentPlayerSprite[2];
        }
        // If the player triggers a gameobject tagged as "Watering Can" and does not have fertilizer or seed but both have been deposited, give watering can to the player and update UI and state
        if (other.gameObject.CompareTag("Watering Can") && !hasFertilizer && !hasSeed && ObjInteract.depositFertilizer && ObjInteract.depositSeed)
        {
            hasWateringCan = true;
            WateringCan_UI.SetActive(true);
            Destroy(other.gameObject);
            playerSprite.sprite = currentPlayerSprite[3];
        }
    }

    // Restarts level either on death or can be on button press
    private void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    //specifically for death wait time before restart
    private IEnumerator WaitAndThenDoSomething(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
