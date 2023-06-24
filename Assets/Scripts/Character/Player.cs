using UnityEngine;

namespace Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float speedRotation;
        private CharacterController _characterController; 
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Turn()
        {
            transform.Rotate(0,Input.GetAxis("Horizontal") * speedRotation, 0);
        }

        private Vector3 DirectionMovement()
        {
            return (transform.TransformDirection(Vector3.forward));
        }

        private float SpeedMovement()
        {
            return (speed * Input.GetAxis("Vertical"));
        }

        private bool SetCharacterController()
        {
            return _characterController.SimpleMove(DirectionMovement() * SpeedMovement());
        }
        private void Update()
        {
            Turn();
            
            DirectionMovement();

            SpeedMovement();
            
            SetCharacterController();
        }
    }
}
