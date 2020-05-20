using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathway : MonoBehaviour
{
    //Uses the Bezier fomular that creates a within curves along mulitple points that can be shaped.
    //This was to try and make a pathway and expand a cylinder tunnel from the points to make it have the ship travel down like a wormhole
    
    [SerializeField]
    private Transform[] controlPoints;
    private Vector3 gpos;

    //using Gizmo to draw
    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            //calculate the curve formula
            gpos = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;

            //used to try and draw a curve line from it.
            //tried following tutorials yet alot we all 2D based and when trying hieght it didnt work completley right.
            Gizmos.DrawSphere(gpos, 30f);
        }

        //draw two lines to show you to manipulate the curve of the path the AI will follow
        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z),
            new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z),
            new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
    }

    //the original way found to calculate the formula by putting all the calculations within indiviual floats to add together
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //formular return = (1-t)3 P0 + 3(1-t)2 tP1 + 3(1-t) t2 P2 + t3 P3

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float ttt = tt * t;
        float uuu = uu * u;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;


        return p;
    }

}
