using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string VerticalAxis = "Vertical";
    private const string HorizontalAxis = "Horizontal";

    private float _moveSpeed = 5;
    private float _rotationSpeed = 20f;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis(VerticalAxis);
        transform.Translate(_moveSpeed * direction * Time.deltaTime * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(HorizontalAxis);
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }
}
