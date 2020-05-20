using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(TestPathEditor))]

public class TestPathEditor : Editor
{
    TestPathCreator creator;
    TestPath path;

    void OnScreenGUI()
    {
        Draw();
    }

    void Input()
    {
        Event guiEvent = Event.current;
        Vector2 mousepos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;


        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            Undo.RecordObject(creator, "Adding");
            path.NewPiece(mousepos);
        }

    }

    void Draw()
    {
        for(int i = 0; i< path.NumberSegments; i++)
        {
            Vector3[] points = path.GetPointsinSegment(i);

            Handles.DrawLine(points[0], points[1]);
            Handles.DrawLine(points[2], points[3]);
            Handles.color = Color.green;


            Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.white, null, 2);
        }


        Handles.color = Color.red;

        for (int i = 0; i < path.NumberPoint; i++)
        {
            Vector3 newpos = Handles.FreeMoveHandle(path[i], Quaternion.identity, .1f, Vector3.zero, Handles.CylinderHandleCap);

            if (path[i] != newpos)
            {
                Undo.RecordObject(creator, "Move point");
                path.MovePoint(i, newpos);
            }

        }
    }

    void OnEnable()
    {
        creator = (TestPathCreator)target;
        if (creator.path == null)
        {
            creator.CreatePath();
        }
        path = creator.path;
    }

    private void CreatePath()
    {
        throw new NotImplementedException();
    }
}
