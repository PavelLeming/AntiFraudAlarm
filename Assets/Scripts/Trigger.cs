using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action IsFraudEntered;
    public event Action IsFraudExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsFraudEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsFraudExited?.Invoke();
    }
}
