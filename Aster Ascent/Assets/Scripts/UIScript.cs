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

    void Help(){
        labelFertilizer.text = "Help0";
    }

    // Start is called before the first frame update
    void Start()
    {
        Help();   
    }

    // Update is called once per frame
    void Update()
    {
        Help(); 
        //FUCK
    }
}
