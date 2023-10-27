using UnityEngine;
using System.Collections;

public class PlayAudioUponEnter : MonoBehaviour 
{
    private AudioSource audioSource;

    private void Start( ) 
    {
        audioSource = gameObject.GetComponent< AudioSource >( );
    }

    private void OnTriggerEnter( Collider other ) 
    {
        if( other.CompareTag( "Player" ) )
        {
            audioSource.Play( );
        }
    }
}