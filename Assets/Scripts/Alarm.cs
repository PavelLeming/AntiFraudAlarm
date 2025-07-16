using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [SerializeField] private AudioSource _alarm;
    private Coroutine _currentCoroutine;
    private float _speed = 0.1f;

    public void TurnOnAlarm()
    {
        if (_currentCoroutine != null)
        {
            _alarm.Play();
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

        while (_alarm.volume != target)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _speed * Time.deltaTime);
            yield return wait;
        }

        if (target == 0 && _alarm.volume == 0)
        {
            _alarm.Stop();
        }
    }
}
