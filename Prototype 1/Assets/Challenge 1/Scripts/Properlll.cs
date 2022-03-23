using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properlll : MonoBehaviour
{
    private float rotationSpeed = 530;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (Vector3.forward * Time.deltaTime *  rotationSpeed );
    }
}
