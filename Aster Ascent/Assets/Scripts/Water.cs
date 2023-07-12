using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Public variables
    public PlayerController player; // Reference to the player controller script
    public GameObject E; // Reference to the "E" gameobject
    public GameObject WateringCan; // Reference to the watering can gameobject
    public GameObject WaterInWateringCan; // Reference to the water in watering can gameobject
    public bool hasWater = false; // Flag to indicate if the watering can has water
    public bool playerProxim; // Flag to indicate if the player is in proximity

    private void OnTriggerEnter2D()
    {
        // If the player enters the trigger and the watering can does not have water, show the "E" gameobject and set playerProxim to true
        if (!hasWater)
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
        // If the player presses the "E" key, has a watering can, and is in proximity, fill the watering can with water and update the UI and player state
        if (Input.GetKey(KeyCode.E) && player.hasWateringCan && playerProxim)
        {
            E.SetActive(false);
            WaterInWateringCan.SetActive(true);
            WateringCan.SetActive(false);
            hasWater = true;
            player.playerSprite.sprite = player.currentPlayerSprite[4];
        }
    }
}
