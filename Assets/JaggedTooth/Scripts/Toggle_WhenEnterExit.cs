using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

public class Toggle_WhenEnterExit : MonoBehaviour
{
    public CanvasGroup[] objectsToFade;

    public float fadeDuration = 5.0f;
    private bool isFading = false;
    private float timer = 0.0f;
    private float targetAlpha = 0.0f;

    VRCPlayerApi player = null;
    
    void Start( )
    {
        player = Networking.LocalPlayer;
        foreach ( var canvasGroup in objectsToFade )
        {
            canvasGroup.alpha = 0;
        }
    }
    private void Update( )
    {     
        if ( isFading == true )
        {
            timer += Time.fixedDeltaTime;
            float alpha = Mathf.Lerp( objectsToFade[ 0 ].alpha, targetAlpha, timer / fadeDuration );

            foreach ( var canvasGroup in objectsToFade )
            {
                canvasGroup.alpha = alpha;
            }

            if ( timer >= fadeDuration )
            {
                isFading = false;
            }
        }
    }

    public void StartFadeIn( )
    {
        foreach ( var canvasGroup in objectsToFade )
        {
            canvasGroup.interactable = true;
        }

        targetAlpha = 1.0f;
        timer = 0.0f;
        isFading = true;
    }

    public void StartFadeOut( )
    {
        foreach ( var canvasGroup in objectsToFade )
        {
            canvasGroup.interactable = false;
        }

        targetAlpha = 0.0f;
        timer = 0.0f;
        isFading = true;
    }

    private void OnTriggerEnter( Collider other )
    {
        StartFadeIn( );
    }

    private void OnTriggerExit( Collider other )
    {
        StartFadeOut( );
    }
}
