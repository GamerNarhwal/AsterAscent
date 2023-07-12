using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    public PlayerController player;
    private Label labelFertilizer;
    private Label labelSeeds;

    private void OnEnable() {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        labelFertilizer = rootVisualElement.Q<Label>("Fertilizer");
        labelSeeds = rootVisualElement.Q<Label>("Seeds");


    }

    void CollectedPowerUp(){
        labelFertilizer.text = "Fertilizer: " + player.numOfBagsOFertilizer;
        labelSeeds.text = "Seeds: " + player.numOfSeeds;
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hasSeed || player.hasFertilizer){
            CollectedPowerUp();
        }
    }
}
