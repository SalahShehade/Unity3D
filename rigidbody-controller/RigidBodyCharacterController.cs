using UnityEngine;

namespace assignment37
{
    public class RigidBodyCharacterController : MonoBehaviour
    {

        public float moveSpeed = 5f;
        public float jumpForce = 7f;

        private Rigidbody rb;
        private bool isGrounded;


        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }


        void Update()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveX * moveSpeed, 0, moveZ * moveSpeed);
            Vector3 newVelocity = new Vector3(movement.x, rb.velocity.y, movement.z);
            rb.velocity = newVelocity;
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // i did this to prevent double jump
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        private void OnCollisionEnter(Collision collision) //i used this method to detect when the capsule touches the plane which i tagged as "Ground"
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }




    }
}
