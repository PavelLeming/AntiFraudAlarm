using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action IsEnter;
    public event Action IsExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsExit?.Invoke();
    }
}
