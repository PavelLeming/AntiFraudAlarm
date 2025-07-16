using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed = 5;
    private float _rotationSpeed = 20f;
    private string _verticalAxis = "Vertical";
    private string _horizontalAxis = "Horizontal";

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float direction = Input.GetAxis(_verticalAxis);
        transform.Translate(_moveSpeed * direction * Time.deltaTime * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(_horizontalAxis);
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }
}
