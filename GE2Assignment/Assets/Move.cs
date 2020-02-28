using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Transform gate;

    // Start is called before the first frame update
    void Start()
    {
        gate = GameObject.FindGameObjectWithTag("Gate").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, gate.position, Time.deltaTime * 0.25f);
        transform.LookAt(gate.parent);

    }
}
