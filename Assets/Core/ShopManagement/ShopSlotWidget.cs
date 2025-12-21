/*using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using UnityEngine;

[RequireComponent(typeof(SimpleStateComponent))]
public class ShopSlotWidget : MonoBehaviour, MMEventListener<MMInventoryEvent>
{
    private SimpleStateComponent _animator;
    
    private const string ON_SHOW = "isInventoryON";
    private const string ON_HIDE = "isInventoryOFF";
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<SimpleStateComponent>();
        
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OnHide();
        }
    }

    #region Helpers

    public void OnShow()
    {
        _animator.PlayState(ON_SHOW);
    }

    public void OnHide()
    {
        Hide();
    }

    public void Hide()
    {
        _animator.PlayState(ON_HIDE);
    }
    
    
    #endregion

    public void OnMMEvent(MMInventoryEvent eventType)
    {
        if (eventType.InventoryEventType == MMInventoryEventType.Click)
        {
            Debug.Log("On Clicked Baby");
        }
    }
}*/
