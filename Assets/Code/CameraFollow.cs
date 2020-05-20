using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // camera follows player from the back,
    //tried to see if could transistion from first person mode to distance from player
    public Transform cameraTarget;
    public Transform rig;

    Vector3 CamPos;
    

    public float distance = 20f;
    public float rotationSpeed = 10f;
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
