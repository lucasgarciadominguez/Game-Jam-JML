using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    public Transform targetActual;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    void FixedUpdate()
    {
        FollowObjective();
    }
    public void FollowObjective()
    {

        Vector3 desiredPosition = new Vector3(0,targetActual.position.y,targetActual.position.z)+ targetActual.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = targetActual.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
    }
    public void ChangeTarget(Transform target)
    {
        targetActual = target;
    }


}
