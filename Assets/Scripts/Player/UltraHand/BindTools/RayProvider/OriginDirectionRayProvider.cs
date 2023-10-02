using UnityEngine;

class OriginDirectionRayProvider : IRayProvider
{
    private Vector3 originPos;
    private Vector3 direction;
    
    public OriginDirectionRayProvider(Vector3 origin, Vector3 dir)
    {
        originPos = origin;
        direction = dir;
    }
    
    public Ray CreateRay()
    {
        return new Ray(originPos, direction);
    }
}