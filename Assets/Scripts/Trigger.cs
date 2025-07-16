using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action<bool> IsEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsEnter?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsEnter?.Invoke(false);
    }
}
