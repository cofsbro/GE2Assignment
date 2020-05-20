using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Testing with another more advance bezier curve helper to draw the ship path to follow 3 demensionally. 
//Did not get far with these

[System.Serializable]
public class TestPath
{

    [SerializeField, HideInInspector]
    List<Vector3> points;

    public TestPath(Vector3 center)
    {
        points = new List<Vector3>
        {
            center + Vector3.left,
            center+(Vector3.left+Vector3.up) *.5f,
            center+(Vector3.right+Vector3.down) *.5f,
            center + Vector3.right

        };

    }

    public Vector3 this[int i]
    {
        get
        {
            return points[i];
        }

    }

    public int NumberPoint
    {
        get
        {
            return points.Count;
        }

    }


    public int NumberSegments
    {
        get
        {
            return (points.Count - 4) / 3 + 1;
        }

    }

    public void NewPiece(Vector3 anchorPos)
    {

        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
        points.Add((points[points.Count - 1] + anchorPos) * .5f);
        points.Add(anchorPos);
    }

    public Vector3[] GetPointsinSegment(int i)
    {
        return new Vector3[] { points[i*3], points[i * 3 + 1], points[i * 3 + 2], points[i * 3 + 3] };
    }


    public void MovePoint(int i, Vector3 pos)
    {

        Vector2 deltaMove = pos - points[i];
        points[i] = pos;

        if(i % 3 == 0 )
        {
            if(i + 1 < points.Count)
            {
                //points[i + 1] += deltaMove;
            }

            if (i - 1 >= points.Count)
            {
                //points[i - 1] += deltaMove;
            }

        }

        else
        {
            bool nextpoint = (i + 1) % 3 == 0;
            int cci = (nextpoint) ? i + 2 : i - 2;
            int anchi = (nextpoint) ? i + 1 : i - 1;
        }
    }
}
