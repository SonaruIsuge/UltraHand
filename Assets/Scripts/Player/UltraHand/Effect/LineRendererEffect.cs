
using System;
using Bind;
using MyEvent;
using UnityEngine;

public class LineRendererEffect : MonoBehaviour, ISelectEffect, IPickItemEffect
{
    [SerializeField] private Transform playerHand;
    [SerializeField] private LineRenderer lineRenderer;

    //private Vector3 playerPoint;
    //private Vector3 itemPoint;
    //private Vector3 itemLocalPosWhenCatch;
    
    private Func<Vector3> getItemPoint;
    private Func<Vector3> getPlayerPoint;

    private void OnEnable()
    {
        EventManager.Register<OnHitBindableItem>(HitItemCallback);
        EventManager.Register<OnResetHitItem>(ResetHitItemCallback);
        EventManager.Register<OnCatchItem>(CatchItemCallback);
        EventManager.Register<OnDropItem>(DropItemCallback);
    }


    private void OnDisable()
    {
        EventManager.Unregister<OnHitBindableItem>(HitItemCallback);
        EventManager.Unregister<OnResetHitItem>(ResetHitItemCallback);
        EventManager.Unregister<OnCatchItem>(CatchItemCallback);
        EventManager.Unregister<OnDropItem>(DropItemCallback);
    }


    private void Update()
    {
        lineRenderer.SetPosition(0, getPlayerPoint());
        lineRenderer.SetPosition(1, getItemPoint());
    }


    public void OnDeselect(Bindable bindItem)
    {
        getPlayerPoint = () => Vector3.zero;
        getItemPoint = () => Vector3.zero;
    }


    public void OnDropDown(Bindable bindItem)
    {
        getPlayerPoint = () => Vector3.zero;
        getItemPoint = () => Vector3.zero;
    }
    
    
    public void OnSelect(Bindable bindItem, RaycastHit hitInfo)
    {
        getPlayerPoint = () => playerHand.position;
        getItemPoint = () => hitInfo.point;
    }
    

    public void OnPickUp(Bindable bindItem, Vector3 hitLocalPoint)
    {
        getPlayerPoint = () => playerHand.position;
        // getItemPoint = () => bindItem.transform.position;
        
        // Use this when want to change catch item method to: always link ray cast hit point.
        getItemPoint = () => bindItem.transform.TransformPoint(hitLocalPoint);
    }


    #region Event Callback

    private void HitItemCallback(OnHitBindableItem e)
    {
        OnSelect(e.Bindable, e.HitInfo);
    }


    private void ResetHitItemCallback(OnResetHitItem e)
    {
        OnDeselect(null);
    }


    private void CatchItemCallback(OnCatchItem e)
    {
        OnPickUp(e.Bindable, e.HitLocalPoint);
    }


    private void DropItemCallback(OnDropItem e)
    {
        OnDropDown(null);
    }
    
    #endregion
}
