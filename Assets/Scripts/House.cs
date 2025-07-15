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

    private void WorkWithAlarm(int target)
    {
        _alarm.TurnAlarm(target);
    }
}
