using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using UnityEngine.UI;
using TMPro;

public class PickUpLibertyCap : UdonSharpBehaviour
{
    public TextMeshPro eatText;
    
    private bool isPickedUp = false;

    public string nameOfMushroom = "";

    public void OnPickup( )
    {
        isPickedUp = true;
        SetInteractionText( text: "Eat " + nameOfMushroom + "?" );
    }

    public void OnDrop( )
    {
        isPickedUp = false;
        SetInteractionText( text: "" );
    }

    public void OnUse( )
    {
        if ( isPickedUp )
        {
            Debug.Log( "Eating " + nameOfMushroom + "!" );
            eatText.enabled = false;
            isPickedUp = false;
            Destroy( gameObject );
        }
    }

    private void SetInteractionText( string text )
    {
        eatText.text = text;
        eatText.enabled = true;
    }
}
