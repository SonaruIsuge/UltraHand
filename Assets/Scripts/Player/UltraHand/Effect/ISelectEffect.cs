

using Bind;
using UnityEngine;

public interface ISelectEffect
{
    void OnSelect(Bindable bindItem, RaycastHit hitInfo);
    void OnDeselect(Bindable bindItem);
}
