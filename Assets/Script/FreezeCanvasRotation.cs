using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCanvasRotation : MonoBehaviour
{
    public Vector3 frozenRotation = Vector3.zero;

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(frozenRotation);
    }
}
