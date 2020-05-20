using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathCreator : MonoBehaviour
{

    [HideInInspector]
    public TestPath path;

    public void CreatePath()
    {
        path = new TestPath(transform.position);
    }

}
