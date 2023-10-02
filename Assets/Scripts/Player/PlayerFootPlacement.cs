using System;
using UnityEngine;

namespace Player
{
    public class PlayerFootPlacement : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private float distanceToGround;
        [SerializeField] private LayerMask layerMask;


        private void OnAnimatorIK(int layerIndex)
        {
            SetFootIK(AvatarIKGoal.LeftFoot);
            SetFootIK(AvatarIKGoal.RightFoot);
        }


        private void SetFootIK(AvatarIKGoal foot)
        {
            anim.SetIKPositionWeight(foot, 1);
            anim.SetIKRotationWeight(foot, 1);

            RaycastHit hit;
            Ray ray = new Ray(anim.GetIKPosition(foot) + Vector3.up, Vector3.down);
            if(!Physics.Raycast(ray, out hit, distanceToGround + 1, layerMask)) return;
            
            Vector3 footPosition = hit.point;
            footPosition.y += distanceToGround;
            anim.SetIKPosition(foot, footPosition);
            anim.SetIKRotation(foot, Quaternion.LookRotation(transform.forward, hit.normal));
        }
    }
}