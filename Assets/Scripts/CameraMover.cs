using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Func<Vector3> GetCameraMovePositionFunc;

    public void Setup(Func<Vector3> GetCameraMovePositionFunc)
    {
        this.GetCameraMovePositionFunc = GetCameraMovePositionFunc;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMovePosition = GetCameraMovePositionFunc();
        cameraMovePosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraMovePosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraMovePosition, transform.position);
        float cameraMoveSpeed = 1f;

        transform.position = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
    }
}
