using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whacka.Game.LightOrHeavy3D
{
    public class Blance : MonoBehaviour
    {
        public BlancePlane Left;
        public BlancePlane Right;

        // Start is called before the first frame update
        void Start()
        {
            Left.Owner = this;
            Right.Owner = this;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Left up!"))
            {
                Left.MoveToLightPos();
                Right.MoveToHeavyPos();
            }

            if (GUILayout.Button("Right up!"))
            {
                Left.MoveToHeavyPos();
                Right.MoveToLightPos();
            }

            if (GUILayout.Button("Back to default!"))
            {
                Left.MoveToDefault();
                Right.MoveToDefault();
            }
        }
    }
}
