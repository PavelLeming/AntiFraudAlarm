using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] Trigger _trigger;
    [SerializeField] Alarm _alarm;

    private void OnEnable()
    {
        _trigger.IsEnter += WorkWithAlarm;
    }

    private void OnDisable()
    {
        _trigger.IsEnter -= WorkWithAlarm;
    }

    private void WorkWithAlarm(bool isEnter)
    {
        if (isEnter)
        {
            _alarm.TurnOnAlarm();
        }
        else
        {
            _alarm.TurnOffAlarm();
        }
    }
}
