using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] AudioSource _alarm;
    private IEnumerator _currentCoroutine;
    private float _speed = 0.1f;

    public void TurnOnAlarm()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = IncreaseVolume();
        StartCoroutine(_currentCoroutine);
    }

    public void TurnOffAlarm()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = DecreaseVolume();
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator IncreaseVolume()
    {
        _alarm.Play();

        while (_alarm.volume < 1)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, 1, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator DecreaseVolume()
    {
        while (_alarm.volume > 0)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, 0, _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        _alarm.Stop();
    }
}
