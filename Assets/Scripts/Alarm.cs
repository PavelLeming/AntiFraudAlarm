using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] AudioSource _alarm;
    private float _speed = 0.1f;
    private bool _isPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        Mover componenet;
        if (other.gameObject.TryGetComponent<Mover>(out componenet))
        {
            _isPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Mover componenet;
        if (other.gameObject.TryGetComponent<Mover>(out componenet))
        {
            _isPlaying = false;
        }
    }

    private void Update()
    {
        if (_isPlaying)
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, 1, _speed * Time.deltaTime);
        else
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, 0, _speed * Time.deltaTime);
    }
}
