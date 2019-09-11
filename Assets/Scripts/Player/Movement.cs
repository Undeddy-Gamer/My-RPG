using UnityEngine;

namespace RPG.Player
{ 
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    
    public class Movement : MonoBehaviour
    {

        [Header("Speed Variables")]
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;

        private float _gravity = 20;
        //Struct (mutiple type array)

        private Vector3 _moveDir;
        //Ref
        private CharacterController _charC;

        private void Start()
        {
            _charC = GetComponent<CharacterController>();
        }


        private void Update()
        {
            Move();
        }


        private void Move()
        {

            if (!PlayerHandler.isDead)  // If play is not dead allow directional movement
            { 
                if(_charC.isGrounded)
                {
                    //set speed

                    if (Input.GetButton("Sprint"))
                    {
                        moveSpeed = runSpeed;
                    }
                    else if (Input.GetButton("Crouch"))
                    {
                        moveSpeed = crouchSpeed;
                    }
                    else
                    {
                        moveSpeed = walkSpeed;
                    }
                
                    //calculate moement direction based off inputs
                    _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);

                    if(Input.GetButton("Jump"))
                    {
                        _moveDir.y = jumpSpeed;
                    }
                }
            }

            if(PlayerHandler.isDead)
            {
                _moveDir = Vector3.zero;
            }
            //Regardless if we are grounded
            //apply gravity
            _moveDir.y -= _gravity * Time.deltaTime;
            //apply movement
            _charC.Move(_moveDir * Time.deltaTime);
        }


    }
}
