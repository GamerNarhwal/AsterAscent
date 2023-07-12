using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    // Public variables
    public PlayerController player; // Reference to the player controller script
    public GameObject E; // Reference to the "E" gameobject
    public Water puddle; // Reference to the water script
    public bool depositSeed; // Flag to indicate if the seed has been deposited
    public bool depositFertilizer; // Flag to indicate if the fertilizer has been deposited
    public bool pourWater; // Flag to indicate if the water has been poured
    public bool playerProxim; // Flag to indicate if the player is in proximity
    public GameObject FertilizerCheckMark; // Reference to the fertilizer checkmark gameobject
    public GameObject SeedsCheckMark; // Reference to the seeds checkmark gameobject
    public GameObject WaterCheckMark; // Reference to the water checkmark gameobject
    public GameObject Aster; // Reference to the aster gameobject

    private Vector3 startPosition; // The starting position of the gameobject
    private Quaternion startRotation; // The starting rotation of the gameobject

    void Start()
    {
        startPosition = transform.position; // Store the starting position of the gameobject
        startRotation = transform.rotation; // Store the starting rotation of the gameobject
    }

    private void OnTriggerEnter2D()
    {
        // If the player has fertilizer, seed, or a watering can, show the "E" gameobject and set playerProxim to true
        if (player.hasFertilizer || player.hasSeed || player.hasWateringCan)
        {
            E.SetActive(true);
            playerProxim = true;
        }
    }

    private void OnTriggerExit2D()
    {
        // If the player exits the trigger, hide the "E" gameobject and set playerProxim to false
        E.SetActive(false);
        playerProxim = false;
    }

    void Update()
    {
        // If the player presses the "E" key and is in proximity
        if (Input.GetKey(KeyCode.E) && playerProxim)
        {
            // If the player has fertilizer, deposit it and update the UI and player state
            if (player.hasFertilizer)
            {
                Debug.Log("You have put down fertilizer");
                player.hasFertilizer = false;
                depositFertilizer = true;
                player.numOfBagsOFertilizer--;
                FertilizerCheckMark.SetActive(true);
                player.playerSprite.sprite = player.currentPlayerSprite[0];
                E.SetActive(false);
            }
            // If the player has seed and fertilizer has been deposited, deposit the seed and update the UI and player state
            if (player.hasSeed && depositFertilizer)
            {
                Debug.Log("You have put down seed");
                player.hasSeed = false;
                player.numOfSeeds--;
                depositSeed = true;
                SeedsCheckMark.SetActive(true);
                player.playerSprite.sprite = player.currentPlayerSprite[0];
                E.SetActive(false);
            }
            // If there is water in the puddle and fertilizer and seed have been deposited, pour water and update the UI and player state
            if (puddle.hasWater && depositFertilizer && depositSeed && !pourWater)
            {
                Debug.Log("You have watered the seed");
                pourWater = true;
                WaterCheckMark.SetActive(true);
                player.playerSprite.sprite = player.currentPlayerSprite[0];
                player.levelOver = true;
                E.SetActive(false);
            }
        }
        // If the level is over, move the aster gameobject to this gameobject's position
        if (player.levelOver)
        {
         // Move the Aster gameobject upwards by a small amount every frame
        Aster.transform.position += new Vector3(0, 0.01f, 0);
        }
    }
}
