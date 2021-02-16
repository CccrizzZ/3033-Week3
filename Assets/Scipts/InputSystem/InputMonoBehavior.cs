using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace InputMonoBehaviorParent
{
    public class InputMonoBehavior : MonoBehaviour
    {

        protected PlayerInputAction GameInput;


        protected void Awake()
        {
            GameInput = new PlayerInputAction();
        }


        protected void OnEnable()
        {
            GameInput.Enable();
        }


        protected void OnDisable()
        {
            GameInput.Disable();
        }


    }
    
}
