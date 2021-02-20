using Character.UI;
using InputMonoBehaviorParent;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Character
{
    public class WeaponHolder : InputMonoBehavior
    {
        [Header("weapon to spawn"), SerializeField]
        private GameObject WeapontoSpawn;



        [SerializeField]
        private Transform WeaponSocketLocation;
        


        private Transform GripIKLocation;
        private bool WasFiring = false;
        private bool FiringPressed = false;


        // animation hash
        private static readonly int AimHorizontalHash = Animator.StringToHash("AimHorizontal");
        private static readonly int AimVerticalHash = Animator.StringToHash("AimVertical");
        private static readonly int FiringHash = Animator.StringToHash("IsFiring");
        private static readonly int ReloadingHash = Animator.StringToHash("IsReloading");
        private static readonly int WeaponTypeHash = Animator.StringToHash("WeaponType");




        // player component references
        public PlayerController Controller => PController;
        private PlayerController PController;
        private CrosshairScript PCrosshair;
        private Animator PAnimator;
        private Camera viewCam;



        private new void Awake()
        {  
            base.Awake();


            // set references
            PController = GetComponent<PlayerController>();
            PAnimator = GetComponent<Animator>();
            if (PController)
            {
                PCrosshair = PController.chs;
            }


            // set camera ref
            viewCam = Camera.main;
        
        }

        void Start()
        {
            // spawn weapon
            GameObject spawnedweapon = Instantiate(
                WeapontoSpawn, 
                WeaponSocketLocation.position, 
                WeaponSocketLocation.rotation
            );


            // assert if weapon is spawned
            if (!spawnedweapon)
            {
                return;
            }
            else if (spawnedweapon)
            {
                // set spawned weapon's parent to player's weapon socket
                spawnedweapon.transform.parent = WeaponSocketLocation;
                print("Weaponspawned");
            }



        }





        private void OnLook(InputAction.CallbackContext obj)
        {



            // get mouse position
            Vector3 independentMousePosition = viewCam.ScreenToViewportPoint(PCrosshair.CurrentAimPosition);
            
            
            // PAnimator.SetFloat(AimHorizontalHash, independentMousePosition.x);
            // PAnimator.SetFloat(AimVerticalHash, independentMousePosition.y);



        }



        private new void OnEnable()
        {
            base.OnEnable();
            GameInput.Player.Look.performed += OnLook;
            // GameInput.Player.Fire.performed += OnFire;
        }

        private new void OnDisable()
        {
            base.OnDisable();
            GameInput.Player.Look.performed -= OnLook;
            // GameInput.Player.Fire.performed -= OnFire;
        
        }



    }    
}
