using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    Vector2 Movement { get; }
    Vector2 MousePosition { get; }
    Vector2 MouseMove { get; }
    bool Run { get; }
    bool Jump { get; }
    bool UltraHand { get; }
    bool ChooseItem { get; }
    bool CancelChoose { get; }
    bool Unbind { get; }
    float AdjustDistance { get; }
    Vector2 AdjustRotation { get; }

    void Enable(bool enable);
    void RegisterInput();
    void UnregisterInput();
}
