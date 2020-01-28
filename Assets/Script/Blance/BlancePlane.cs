using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Whacka.Game.LightOrHeavy3D
{
    public class BlancePlane : MonoBehaviour
    {
        //=====================================================================
        // property
        //=====================================================================

        [Range(0f, 0.5f)]
        public float MoveDistance = 0.1f;
        public float MoveDuration = 1f;

        public BlanceHitZone HitZone;

        private bool _Moving = false;
        private Vector3 _StartPos;
        private Vector3 _LightPos;
        private Vector3 _HeavyPos;

        //=====================================================================
        // field
        //=====================================================================

        public Blance Owner { get; set; }

        //=====================================================================
        // unity function
        //=====================================================================

        // Start is called before the first frame update
        void Start()
        {
            _StartPos = transform.localPosition;
            _LightPos = _StartPos + Vector3.up * MoveDistance;
            _HeavyPos = _StartPos + Vector3.down * MoveDistance;

            HitZone.Owner = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        //=====================================================================
        // public interface
        //=====================================================================

        public void MoveToLightPos()
        {
            _Moving = true;
            transform.DOLocalMove(_LightPos, MoveDuration).OnComplete(() => _Moving = false);
        }

        public void MoveToHeavyPos()
        {
            _Moving = true;
            transform.DOLocalMove(_HeavyPos, MoveDuration).OnComplete(() => _Moving = false);
        }

        public void MoveToDefault()
        {
            _Moving = true;
            transform.DOLocalMove(_StartPos, MoveDuration).OnComplete(() => _Moving = false);
        }

        public void AddWeight(Weight weight)
        {
            // todo: 写死的地方要重写
            Debug.Log($"AddWeight!weight.Number = {weight.Number}");
            weight.transform.parent = this.transform.parent;
            weight.transform.localPosition = this.transform.localPosition + Vector3.up * 0.2f;
        }

        public void RemoveWeight(Weight weight)
        {
            Debug.Log($"RemoveWeight!weight.Number = {weight.Number}");
        }

        //=====================================================================
        // checker
        //=====================================================================

        public bool CanMove()
        {
            if (!_Moving)
            {
                return false;
            }
            return true;
        }

        //=====================================================================
        // inner function
        //=====================================================================
    }
}
