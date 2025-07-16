using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _trigger.IsFraudEntered += TurnOnAlarm;
        _trigger.IsFraudExited += TurnOffAlarm;
    }

    private void OnDisable()
    {
        _trigger.IsFraudEntered -= TurnOnAlarm;
        _trigger.IsFraudExited -= TurnOffAlarm;
    }

    private void TurnOnAlarm()
    {
        _alarm.TurnOn();
    }

    private void TurnOffAlarm()
    {
        _alarm.TurnOff();
    }
}
