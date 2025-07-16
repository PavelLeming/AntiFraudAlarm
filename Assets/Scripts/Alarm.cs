using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [SerializeField] private AudioSource _alarm;
    private Coroutine _currentCoroutine;
    private float _speed = 0.1f;
    private float _offset = 0.001f;

    public void TurnOn()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _alarm.Play();
        _currentCoroutine = StartCoroutine(ChangeVolume(MaxVolume));
    }

    public void TurnOff()
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

        if (target < _offset)
        {
            _alarm.Stop();
        }
    }
}
