using System;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Rigidbody _rb;
    public float speedCar = 5.0f;
    private bool isClicked;
    public float speedRotation = 300f;
    
    [NonSerialized]
    public Vector3 finalPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        isClicked = true;
    }

    private void Update()
    {
        if (finalPosition.x != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
finalPosition, speedCar * 3 * Time.deltaTime);
            // transform.LookAt(finalPosition);
            Vector3 lookPos = finalPosition - transform.position;
            lookPos.y = 0;
            transform.rotation =
           Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookPos), Time.deltaTime * speedRotation);
        }
        if (transform.position == finalPosition)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isClicked && finalPosition.x == 0)
        {
            _rb.MovePosition(_rb.transform.position +
           _rb.rotation * Vector3.forward * speedCar * Time.fixedDeltaTime);
        }
    }
}

