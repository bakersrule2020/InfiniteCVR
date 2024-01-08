using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ZuluClientCVR
{
    internal class CoroutineHelper : MonoBehaviour
    {
        public void startroutine(string coroutine)
        {
            StartCoroutine(coroutine);
        }
        public void StopRoutine(string coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
