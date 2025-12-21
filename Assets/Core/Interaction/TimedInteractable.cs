using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
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
    
    [Header("Inventory")]
    public string InventoryName;
    
    
    
    private float _timer = 0;
    private bool _isInteractionDone = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }
    

    private void OnTriggerStay2D(Collider2D other)
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

    public void Resale()
    {
        Inventory inventory = Inventory.FindInventory(InventoryName, "Player1");

        for (int i = 0; i < inventory.Content.Length; i++)
        {
            inventory.EmptyInventory();
            
        }
    }


    public void DebugMessage()
    {
        Debug.Log("Debug Timed Interactable");
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        Reset();
    }

    private void OnTriggerExit(Collider other)
    {
        OnInteractionExit.Invoke();
        
    }

    private void Reset()
    {
        _timer = 0;
        _isInteractionDone = false;
        FillableTimer.fillAmount = 0;
    }
}
