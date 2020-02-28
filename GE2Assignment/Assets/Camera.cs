using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 camOffset;
    public float camDistance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = new Vector3(0, 90, 90);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position + camOffset, Time.deltaTime * 5.0f);
        transform.LookAt(cameraTarget.parent);
    }


}
