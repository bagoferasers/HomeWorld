using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
public class faceThePlayer : UdonSharpBehaviour
{
    public Transform playerCamera;

    void Update( )
    {
        // Ensure the playerCamera is set in the Inspector
        if ( playerCamera != null )
        {
            // Make the text always face the player's point of view
            transform.LookAt( playerCamera );
        }
    }
}
