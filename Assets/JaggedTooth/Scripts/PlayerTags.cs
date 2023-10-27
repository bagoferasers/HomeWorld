using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerTags : MonoBehaviour
{
    public LayerMask targetLayer;
    private GameObject[] objects;
    List< GameObject > objectsOnLayer = new List< GameObject >( );
    void Update( )
    {
        objects = FindGameObjectsWithLayer( targetLayer );
        foreach ( var obj in objects )
        {
            obj.tag = "Player";
        }
    }

    private GameObject[] FindGameObjectsWithLayer( LayerMask layer )
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType< GameObject >( );

        foreach ( var obj in allObjects )
        {
            if( (layer.value & ( 1 << obj.layer ) ) > 0 )
            {
                objectsOnLayer.Add( obj );
            }
        }
        return objectsOnLayer.ToArray( );
    }
}
