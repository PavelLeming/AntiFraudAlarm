using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [SerializeField] AudioSource _alarm;
    private Coroutine _currentCoroutine;
    private float _speed = 0.1f;
    private float _targetVolume;

    public void TurnAlarm(bool isEnter)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        if (isEnter)
        {
            _targetVolume = MaxVolume;
        }
        else
        {
            _targetVolume = MinVolume;
        }
        _currentCoroutine = StartCoroutine(ChangeVolume(_targetVolume));
    }
    private IEnumerator ChangeVolume(float target)
    {
        var wait = new WaitForEndOfFrame();

        _alarm.Play();

        while (_alarm.volume != target)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _speed * Time.deltaTime);
            yield return wait;
        }
    }
}
