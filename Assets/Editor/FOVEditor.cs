using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    [CustomEditor (typeof (Detector))]
public class FOVEditor : Editor
{
    void OnSceneGUI()
    {
        Detector fov = (Detector)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius );
        Vector3 viewAngleA = fov.DirFromAngles(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirFromAngles(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB  * fov.viewRadius);

        Handles.color = Color.red;
        if (fov.visible == true)
        {
            Handles.DrawLine(fov.transform.position, fov.player.position);
        }
    }
}
