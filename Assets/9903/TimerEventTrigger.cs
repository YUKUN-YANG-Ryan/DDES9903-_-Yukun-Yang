using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerEventTrigger : MonoBehaviour
{
    [SerializeField] private float duration = 3f;
    [SerializeField] private bool playOnStart = true;

    public UnityEvent onTimerComplete;

    private Coroutine timerCoroutine;

    void Start()
    {
        if (playOnStart)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine(DoTimer());
    }

    private IEnumerator DoTimer()
    {
        yield return new WaitForSeconds(duration);

        if (onTimerComplete != null)
        {
            onTimerComplete.Invoke();
        }

        timerCoroutine = null;
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }
}