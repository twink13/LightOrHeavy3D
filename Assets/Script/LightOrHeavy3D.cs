using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Whacka.Game.LightOrHeavy3D
{
    public class LightOrHeavy3D : MonoBehaviour
    {
        public Camera CurrentCamera;
        public LayerMask RayHitLayer;
        public Weight TestWeight;

        private void Awake()
        {
            DOTween.Init();
            //DOTween.defaultEaseType = Ease.Flash;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TraceTarget();
            }
        }

        private void TraceTarget()
        {
            Debug.Log("TraceTarget!");
            //Ray ray = CurrentCamera.ViewportPointToRay(Vector2.one * 0.5f);
            Ray ray = CurrentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, RayHitLayer))
            {
                // todo: 改写到其他地方
                // todo: 校验是否有变化
                if (TestWeight.Owner != null)
                {
                    TestWeight.Owner.RemoveWeight(TestWeight);
                }
                BlancePlane targetPlane = hit.collider.GetComponent<BlanceHitZone>().Owner;
                targetPlane.AddWeight(TestWeight);

                TestWeight.Owner = targetPlane;
            }
        }
    }
}
