using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public bool hasSeed;
    public bool hasFertilizer;
    public bool isOnGround = false;
    public int numOfSeeds;
    public int numOfBagsOFertilizer;
    public int health;
    public int speed;
    public int jumpForce;
    public Rigidbody2D player;
    


    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Movement();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            player.velocity = new Vector2(player.velocity.y, jumpForce);
            isOnGround = false;
        }
        
        

    }

    void Movement(){
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        if(horizontalInput < 0){
            player.transform.localScale = new Vector2(-0.26f, 0.26f);
        }else if(horizontalInput > 0){
            player.transform.localScale = new Vector2(0.26f, 0.26f);
        }


    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
        if(other.gameObject.CompareTag("Wall")){
            Debug.Log("You have hit a wall");
            player.velocity = new Vector2(0, 0);
        }
    }
    
}

