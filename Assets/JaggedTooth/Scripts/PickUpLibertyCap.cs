using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using UnityEngine.UI;
using TMPro;

public class PickUpLibertyCap : UdonSharpBehaviour
{
    public TextMeshPro eatText;
    
    private bool isPickedUp = false;

    public void OnPickup()
    {
        isPickedUp = true;
        SetInteractionText("Eat liberty cap?");
    }

    public void OnDrop()
    {
        isPickedUp = false;
        SetInteractionText("");
    }

    public void OnUse()
    {
        if (isPickedUp)
        {
            Debug.Log("Eating Liberty Cap!");
            eatText.enabled = false;
            isPickedUp = false;
        }
    }

    private void SetInteractionText(string text)
    {
        eatText.text = text;
        eatText.enabled = true;
    }
}
