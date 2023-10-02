
using Bind;
using UnityEngine;

public interface IBindEffect
{
    void OnBind(Bindable self, Bindable other, Vector3 selfPoint, Vector3 otherPoint);
    void OnUnBind();
}       
