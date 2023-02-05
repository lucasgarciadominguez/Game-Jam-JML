using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    public GameManager gameManager;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (gameManager.stateGame==States.Play)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = new Vector3( originalPos.x + Random.insideUnitSphere.x * shakeAmount,camTransform.localPosition.y,camTransform.localPosition.z);


                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                //camTransform.localPosition = originalPos;
            }
        }
        else
        {

        }
    }
}
