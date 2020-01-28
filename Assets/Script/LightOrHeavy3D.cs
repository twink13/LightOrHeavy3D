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
                hit.collider.GetComponent<BlanceHitZone>().Owner.AddWeight();
            }
        }
    }
}
