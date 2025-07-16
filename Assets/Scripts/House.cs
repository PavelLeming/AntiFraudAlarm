using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _trigger.IsEnter += TurnOn;
        _trigger.IsExit += TurnOff;
    }

    private void OnDisable()
    {
        _trigger.IsEnter -= TurnOn;
        _trigger.IsExit -= TurnOff;
    }

    private void TurnOn()
    {
        _alarm.TurnOnAlarm();
    }

    private void TurnOff()
    {
        _alarm.TurnOffAlarm();
    }
}
