using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed = 5;
    private float _rotationSpeed = 20f;

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");
        transform.Translate(_moveSpeed * direction * Time.deltaTime * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }
}
