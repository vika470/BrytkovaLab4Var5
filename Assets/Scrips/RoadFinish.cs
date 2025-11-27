using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFinish : MonoBehaviour
{
    public Vector3 finalPosition;

    private void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("Car"))
            car.GetComponent<CarController>().finalPosition = finalPosition;
    }
}
