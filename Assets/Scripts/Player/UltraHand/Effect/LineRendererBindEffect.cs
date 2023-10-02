using System;
using Bind;
using MyEvent;
using UnityEngine;


public class LineRendererBindEffect : MonoBehaviour, IBindEffect
{
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private Vector3 selfPoint;
    [SerializeField] private Vector3 otherPoint;

    private void OnEnable()
    {
        EventManager.Register<OnDetectOtherBind>(OnDetectBindItem);
        EventManager.Register<OnResetDetectOtherBind>(OnResetDetectBindItem);
    }


    private void OnDisable()
    {
        EventManager.Unregister<OnDetectOtherBind>(OnDetectBindItem);
        EventManager.Unregister<OnResetDetectOtherBind>(OnResetDetectBindItem);
    }


    private void Update()
    {
        lineRenderer.SetPosition(0, selfPoint);
        lineRenderer.SetPosition(1, otherPoint);
    }


    public void OnBind(Bindable self, Bindable other, Vector3 selfP, Vector3 otherP)
    {
        selfPoint = selfP;
        otherPoint = otherP;
    }
    

    public void OnUnBind()
    {
        selfPoint = Vector3.zero;
        otherPoint = Vector3.zero;
    }
    
    
    # region Event Callback

    private void OnDetectBindItem(OnDetectOtherBind e)
    {
        OnBind(e.Self, e.Other, e.SelfPoint, e.OtherPoint);
    }

    private void OnResetDetectBindItem(OnResetDetectOtherBind e)
    {
        OnUnBind();
    }
    
    #endregion
}
