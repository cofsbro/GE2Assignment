using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    //the Ship randomly traveling to diffrent points on the map allowing a min and max loactions the point can be for the ship to travel
    // this was used to increase and help scale the wraith ship as it was so large my original points were already inside the model and therefore
    // did not move
    public float speed = 5f;
    public float rspeed = .5f;
    public float time;
    public float restarttime = 5f;

    


    public Transform moveto;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;


    // Start is called before the first frame update
    void Start()
    {
       


        time = restarttime;

        moveto.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

    }

// Update is called once per frame
void FixedUpdate()
    {

        Vector3 flying = moveto.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(flying);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rspeed * Time.deltaTime);




        transform.position = Vector3.MoveTowards(transform.position, moveto.position, speed * Time.deltaTime);




        if (Vector3.Distance(transform.position, moveto.position) < 0.2f)
        {
            if(time <=0)
            {
                moveto.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                time = restarttime;
            }

            else
            {
                time -= Time.deltaTime;
            }
        }
    }

}
