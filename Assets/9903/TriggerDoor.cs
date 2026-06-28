using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDoor : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("碰到门");
            OnEnter?.Invoke();
        }
    }
}