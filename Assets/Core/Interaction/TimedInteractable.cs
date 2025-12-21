using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Fire an event after some time
/// </summary>
public class TimedInteractable : MonoBehaviour
{
    [Header("Interaction Settings")] 
    public float InteractionTime;
    public UnityEvent OnInteracted;
    public UnityEvent OnInteractionExit;

    [Header("Visual Settings")] 
    public Image FillableTimer;
    
    private float _timer = 0;
    private bool _isInteractionDone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isInteractionDone)
            return;

        _timer += Time.deltaTime;
        FillableTimer.fillAmount = _timer / InteractionTime;
        if (_timer > InteractionTime)
        {
            OnInteracted.Invoke();
            _isInteractionDone = true;
            FillableTimer.fillAmount = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnInteractionExit.Invoke();
        Reset();
    }

    private void Reset()
    {
        _timer = 0;
        _isInteractionDone = false;
        FillableTimer.fillAmount = 0;
    }
}
