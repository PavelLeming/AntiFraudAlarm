using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public event UnityAction<int> IsEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsEnter?.Invoke(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Mover>(out _))
            IsEnter?.Invoke(0);
    }
}
