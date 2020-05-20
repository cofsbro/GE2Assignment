using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    // ship chases other ship

    public Transform target;
    
    public  float speed = 10f;
    public  float turning = 40f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //As long as it is within a certain radius it follows or orbits the ship
        //was trying various meathods researched yet not working right.
        if (Vector3.Distance(transform.position, target.position) > 111f)
        {
            Rotation();
            Travel();

        }


        //as the model was oddly shaped had to scale it down
        if (Vector3.Distance(transform.position, target.position) < 111f)
        {
            Orbit();

        }




    }

    void Rotation()
    {
        Vector3 flying = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(flying);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turning * Time.deltaTime);


    }


    void Travel()
    {

        transform.position += transform.forward * speed * Time.deltaTime;

    }


    //drew a sphere to make sure it obit was at least large enough from all angles of the ship to avoid it from going into the ship itself
    void Orbit()
    {
        Vector3 shiporbit = (target.position + new Vector3(110f, 110f, 110f)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(shiporbit);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(0, 0, 3 * Time.deltaTime);
    }

}

