using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMonoBehaviorParent;

namespace Character.UI
{
    public class CrosshairScript : InputMonoBehavior
    {



        // horizontal constrain
        [SerializeField, Range(0,1)]
        private float CrosshairHorizontalPercentage = 0.25f;
        private float HorizontalOffset;
        private float MaxHorizontalDeltaConstrain;
        private float MinHorizontalDeltaConstrain;
        



        // vertical constrain
        [SerializeField, Range(0,1)]
        private float CrosshairVerticalPercentage = 0.25f;
        private float VerticalOffset;
        private float MaxVerticalDeltaConstrain;
        private float MinVerticalDeltaConstrain;
        




        private Vector2 CrosshairStartPosition;
        private Vector2 CurrentLookDeltas;



        void Start()
        {
            if (GameManager.Instance.CursorActive)
            {
                AppEvent.InvokeMouseCursorEnable(false);
            }

            CrosshairStartPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);

            // set horizontal offset
            HorizontalOffset = (Screen.width * CrosshairHorizontalPercentage) / 2f;
            MinHorizontalDeltaConstrain = -(Screen.width / 2f) + HorizontalOffset;
            MaxHorizontalDeltaConstrain = (Screen.width / 2f) - VerticalOffset;


            // set vertical offset
            VerticalOffset = (Screen.height * CrosshairVerticalPercentage) / 2f;
            MinVerticalDeltaConstrain = -(Screen.height / 2f) + VerticalOffset;
            MaxVerticalDeltaConstrain = (Screen.height / 2f) - VerticalOffset;


            
        }



        // private void OnLook(InputAction.CallbackContext obj)
        // {
        //     print(obj.ReadValue<Vector2>());
        // }


        // private new void OnEnable()
        // {
        //     base.OnEnable();
        //     GameInput.Player.Look.performed += OnLook;
        // }


        // private new void OnDisable()
        // {
        //     base.OnDisable();
        //     GameInput.Player.Look.performed -= OnLook;



        // }






    }
}
