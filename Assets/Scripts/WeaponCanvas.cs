using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle the rotation of the canvas relative to the camera
/// </summary>
public class WeaponCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation = Camera.main.transform.rotation;
        transform.rotation = lookRotation;
    }
}
