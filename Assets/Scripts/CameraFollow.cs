using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    public float offSetX = 0.0f;
    public float offSetY = 0.0f;
    public float offSetZ = 0.0f;

    public float cameraSpeed = 9.8f;

    private Vector3 TargetPos;
    void LateUpdate()
    {
        TargetPos = new Vector3(
            target.transform.position.x + offSetX,
            target.transform.position.y + offSetY,
            target.transform.position.z + offSetZ
        );

        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * cameraSpeed);
    }
}
