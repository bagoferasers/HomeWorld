using UnityEngine;
using VRC.SDKBase;
using System.Collections;
public class GrassAndPlayerInteraction : MonoBehaviour
{
    private Vector3 originalPos;
    private Vector3 loweredPos;
    public float loweredY = 0.15f;
    public float duration = 1.0f;
    public float raiseSpeed = 0.5f;
    public float lowerSpeed = 5.0f;
    private bool isLowering = false;
    private float timePassed = 0.0f;
    public float waitTime = 1.0f;

    private void Start( )
    {
        originalPos = transform.position;
        loweredPos = transform.position;
        loweredPos.y = ( transform.position.y - loweredY );
    }
    void OnTriggerEnter( Collider other )
    {
        if( other.CompareTag( "Player" ) && !isLowering )
        {
            Debug.Log( "Player entered grass object!" ); 
            isLowering = true;
            StopAllCoroutines( );
            StartCoroutine( lowerTheGrass( time: duration ) );            
        }
    }

    void OnTriggerExit( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            Debug.Log( "Player exited grass object!" );
            isLowering = false;
            StopAllCoroutines( );
            StartCoroutine( raiseTheGrass( time: duration ) );
        }
    }

    IEnumerator lowerTheGrass( float time )
    {
        timePassed = 0.0f;
        while( timePassed < time && isLowering )
        {
            transform.position = Vector3.Lerp( transform.position, loweredPos, ( timePassed / time ) );
            timePassed += Time.deltaTime * lowerSpeed;
            yield return null;
        }
        transform.position = loweredPos;
    }

    IEnumerator raiseTheGrass( float time )
    {
        yield return new WaitForSeconds( waitTime );
        timePassed = 0.0f;
        while( timePassed < time )
        {
            transform.position = Vector3.Lerp( transform.position, originalPos, ( timePassed / time ) );
            timePassed += Time.deltaTime * raiseSpeed;
            yield return null;
        }
        transform.position = originalPos;
    }
}