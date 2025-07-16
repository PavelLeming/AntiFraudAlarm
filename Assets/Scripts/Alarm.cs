using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [SerializeField] AudioSource _alarm;
    private Coroutine _currentCoroutine;
    private float _speed = 0.1f;

    public void TurnOnAlarm()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume(MaxVolume));
    }

    public void TurnOffAlarm()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume(MinVolume));
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
