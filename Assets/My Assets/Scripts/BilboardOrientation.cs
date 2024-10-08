using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardOrientation : MonoBehaviour
{
    public Transform targetPosition;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);

        if (targetPosition) transform.position = targetPosition.position;
    }
}
