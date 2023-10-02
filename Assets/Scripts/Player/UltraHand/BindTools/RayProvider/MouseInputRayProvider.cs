

using UnityEngine;

public class MouseInputRayProvider : IRayProvider
{
    private IInput relateInput;
    private Camera playerCam;
    
    public MouseInputRayProvider(IInput input, Camera camera)
    {
        relateInput = input;
        playerCam = camera;
    }
    
    public Ray CreateRay()
    {
        return playerCam.ScreenPointToRay(relateInput.MousePosition);
    }
}
