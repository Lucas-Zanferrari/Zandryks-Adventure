using UnityEngine;
using System.Collections.Generic;

namespace Generics.Dynamics
{
    /// <summary>
    /// the out-of-the-box default IK component
    /// </summary>

    public class BasicIK : MonoBehaviour
    {

        public Transform target;
       // private Vector3 IKHandle;

        private Quaternion IKRotation;

        [Range(0f, 1f)]
        public float weight = 1f;
        [Range(0f, 1f)]
        public float weightRotation = 0f;

        public int iterations;
        public List<Transform> bones = new List<Transform>();




        public Quaternion GetIKRotation()
        {
            IKRotation = target.rotation;
            Quaternion _local = Quaternion.Lerp(Endbone().rotation, IKRotation, weightRotation);
            return _local;
        }

        public Transform Endbone()
        {
            return bones[bones.Count - 1].transform ? bones[bones.Count - 1].transform : null;
        }

        void LateUpdate()
        {
            IKSolver();
        }

        public void IKSolver()
        {
            if (!target) return;

            if (bones.Count <= 0) return;

            //Ammount of  Iterations
            for (int k = 0; k < iterations; k++)
            {
                for (int i = bones.Count - 1; i >= 0; i--)
                {
                    Vector3 v1 = target.position - bones[i].transform.position;
                    Vector3 v2 = bones[bones.Count - 1].transform.position - bones[i].transform.position;

                    Quaternion initialRotation = bones[i].transform.rotation;

                    Quaternion _targetRotation = Quaternion.FromToRotation(v2, v1);

                    bones[i].transform.rotation = ApplyQuaternion(_targetRotation, initialRotation);
                }
            }

            bones[bones.Count - 1].transform.rotation = GetIKRotation();
        }




        public Quaternion ApplyQuaternion(Quaternion _qA, Quaternion _qB)
        {
            Quaternion qr = Quaternion.identity;
            Vector3 va = new Vector3(_qA.x, _qA.y, _qA.z);
            Vector3 vb = new Vector3(_qB.x, _qB.y, _qB.z);
            qr.w = _qA.w * _qB.w - Vector3.Dot(va, vb);
            Vector3 vr = Vector3.Cross(va, vb) + _qA.w * vb + _qB.w * va;
            qr.x = vr.x;
            qr.y = vr.y;
            qr.z = vr.z;
            return qr;
        }
    }
}
