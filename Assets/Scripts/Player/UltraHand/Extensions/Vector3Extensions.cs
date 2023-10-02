
using UnityEngine;

public static class Vector3Extensions
{
    /// <summary>
    /// Inverts a scale vector by dividing 1 by each component
    /// </summary>
    public static Vector3 Invert(this Vector3 vec)
    {
        return new Vector3(1 / vec.x, 1 / vec.y, 1 / vec.z);
    }


    /// <summary>
    /// Transform a vector to another vector according to specific coordinate
    /// </summary>
    /// <param name="vec"></param>
    /// <param name="referTransform"></param>
    /// <returns></returns>
    public static Vector3 TransformCoordinate(this Vector3 vec, Transform referTransform)
    {
        Vector3 result;
        result.x = Vector3.Dot(vec, referTransform.right);
        result.y = Vector3.Dot(vec, referTransform.up);
        result.z = Vector3.Dot(vec, referTransform.forward);
        return result;
        
        // v = (v.i )i + (v.j)j + (v.k)k
    }
}
