
using Bind;
using UnityEngine;

public interface IPickItemEffect
{
    void OnPickUp(Bindable bindItem, Vector3 hitLocalPoint);
    void OnDropDown(Bindable bindItem);
}
