using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapDIce : MonoBehaviour
{
    private List<Vector3> dir = new List<Vector3>();

    public int currentSpeed;

    void Start()
    {
        dir.Add(new Vector3(-90f, -90f, 0f));
        dir.Add(new Vector3(-180f, 0f, 0f));
        dir.Add(new Vector3(90f, 0f, 0f));
        dir.Add(new Vector3(-90f, 0f, 0f));
        dir.Add(new Vector3(0f, 0f, 0f));
        dir.Add(new Vector3(-90f, 90f, 0f));
    }

    void FixedUpdate()
    {
        var desiredRotation = Quaternion.Euler(dir[currentSpeed]);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * 10f);
    }
}
