using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] AudioSource _alarm;
    private IEnumerator _currentCoroutine;
    private float _speed = 0.1f;
    private bool _isTurnOn;

    public void TurnAlarm(int target)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = ChangeVolume(target);
        StartCoroutine(_currentCoroutine);
    }
    private IEnumerator ChangeVolume(int target)
    {
        var wait = new WaitForEndOfFrame();

        _alarm.Play();

        while (_alarm.volume < 1)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _speed * Time.deltaTime);
            yield return wait;
        }
    }
}
