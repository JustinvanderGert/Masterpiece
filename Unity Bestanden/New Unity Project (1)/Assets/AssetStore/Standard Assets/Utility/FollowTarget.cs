using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public UnityEngine.Vector3 offset = new UnityEngine.Vector3(0f, 7.5f, 0f);


        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
