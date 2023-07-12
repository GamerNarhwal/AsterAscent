using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //to follow player :D
    public GameObject player;
    //smooth camera follow, see more in the direction where the player is facing
    //offset is how far the camera is from the player, higher number means farther camera from player
    public float offset;
    //offsetSmoothing is how fast the camera moves when the player changes direction, higher number means faster camera change, but very janky
    public float offsetSmoothing;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //camera follow
    //code below for regular camera follow
    //player.position = new Vector3(player.transform.position.x, transform.position.y, transform.positionz);
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        //checking player movement direction to change camera direction
        if(player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
