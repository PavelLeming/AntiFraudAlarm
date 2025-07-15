using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] AudioSource _alarm;
    private IEnumerator _currentCoroutine;
    private float _speed = 0.1f;
    private bool _isTurnOn;

    public void TurnAlarm(bool isTurnOn)
    {
        _isTurnOn = isTurnOn;

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = ChangeVolume();
        StartCoroutine(_currentCoroutine);
    }
    private IEnumerator ChangeVolume()
    {
        var wait = new WaitForEndOfFrame();

        if (_isTurnOn)
        {
            _alarm.Play();

            while (_alarm.volume < 1)
            {
                _alarm.volume = Mathf.MoveTowards(_alarm.volume, 1, _speed * Time.deltaTime);
                yield return wait;
            }
        }
        else
        {
            while (_alarm.volume > 0)
            {
                _alarm.volume = Mathf.MoveTowards(_alarm.volume, 0, _speed * Time.deltaTime);
                yield return wait;
            }

            _alarm.Stop();
        }
    }
}
