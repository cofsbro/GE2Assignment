using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormCamera : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform rig;

    Vector3 CamPos;


    public float distance = 0f;
    public float rotationSpeed = 0.5f;
    float angle;




    // Start is called before the first frame update
    void Start()
    {

    }

    void RigCamera()
    {
        transform.position = rig.position;
        transform.rotation = rig.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CamPos = cameraTarget.position - (cameraTarget.forward * distance) + cameraTarget.up * distance * 0.25f;
        transform.position = Vector3.Lerp(transform.position, CamPos, 0.125f);


        angle = Mathf.Abs(Quaternion.Angle(transform.rotation, cameraTarget.rotation));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraTarget.rotation, (rotationSpeed + angle) * Time.deltaTime);

    }
}

