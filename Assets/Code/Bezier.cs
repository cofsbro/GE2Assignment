using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public Transform point0, point1, point2, point3;
    public LineRenderer lineRenderer;

    private int numpoint = 50;
    private Vector3[] pos = new Vector3[50];


    void Start()
    {
        lineRenderer.positionCount =  numpoint;

        DrawCurve();
    }

    void Update()
    {
        DrawCurve();

    }

    void DrawCurve()
    {
        for (int i = 1; i < numpoint; i++)
        {
            float j = i / (float)numpoint;
            pos[i - 1] = CalculateCubicBezierPoint(j, point0.position, point1.position, point2.position, point3.position);

        }

        lineRenderer.SetPositions(pos);
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
