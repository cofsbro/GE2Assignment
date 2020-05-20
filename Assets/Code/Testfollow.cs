using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testfollow : MonoBehaviour
{

    public Transform first, second, third, forth;



    private int numpoint = 50;
    private Vector3[] shipPos = new Vector3[50];

    private int destination;

    private float tParm;

   

    private float speed = .5f;

    private bool coroutine;


    // Start is called before the first frame update
    void Start()
    {
        tParm = 0f;
        destination = 0;
        coroutine = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (coroutine)
        {
            StartCoroutine(GoByRoute(destination));
        }

    }

    private IEnumerator GoByRoute(int routenum)
    {
        coroutine = false;

        Vector3 p0 = first.position;
        Vector3 p1 = second.position;
        Vector3 p2 = third.position;
        Vector3 p3 = forth.position;


        while (tParm < 1)
        {
            tParm += Time.deltaTime * speed;

            for (int i = 1; i < numpoint; i++)
            {
                float j = i / (float)numpoint;
                shipPos[i - 1] = CalculateCubicBezierPoint(j, first.position, second.position, third.position, forth.position);
  
            }

            //transform.SetPosition(shipPos);


            //Quaternion rotate = Quaternion.LookRotation(shipPos);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotate, .5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        tParm = 0f;






        if (transform.position == forth.position)
            transform.position = first.position;

        coroutine = true;

    }

    Vector3 CalculateCubicBezierPoint(float j, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //formular return = (1-t)3 P0 + 3(1-t)2 tP1 + 3(1-t) t2 P2 + t3 P3

        float u = 1 - j;
        float jj = j * j;
        float uu = u * u;
        float jjj = jj * j;
        float uuu = uu * u;

        Vector3 p = uuu * p0;
        p += 3 * uu * j * p1;
        p += 3 * u * jj * p2;
        p += jjj * p3;


        return p;
    }
}
