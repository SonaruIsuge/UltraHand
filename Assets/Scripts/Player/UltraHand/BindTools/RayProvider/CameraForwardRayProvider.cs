
using UnityEngine;

public class CameraForwardRayProvider : IRayProvider
{
    private Camera targetCam;


    public CameraForwardRayProvider(Camera cam)
    {
        targetCam = cam;
    }
    
    public Ray CreateRay()
    {
        return new Ray(targetCam.transform.position, targetCam.transform.forward);
    }
}
