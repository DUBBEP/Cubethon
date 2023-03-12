using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 groundDistance = new Vector3(1, 1, 1);
    private bool isGrounded;

    public LayerMask groundMask;
    public Rigidbody rb;
    public bool unfrozen = false;
    public float forwardForce = 2000f;
    public float horizontalForce = 500f;
    public float horizontalSpeedCap = 40f;


    void Update()
    {
        isGrounded = Physics.CheckBox(transform.position, groundDistance, transform.rotation, groundMask);

        if (rb.position.y < -1) {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.x > 7.5f || rb.position.x < -7.5f)
        {
            rb.constraints &= ~RigidbodyConstraints.FreezeRotation;   
        } else if (!unfrozen && isGrounded)
        {
            ResetRotation();
        }

        void ResetRotation()
        {
            rb.rotation = Quaternion.Euler(0, 0, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotation;                 
        }

    }

    void FixedUpdate() 
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);        

        if ( Input.GetKey("d") ) {
            if (rb.velocity.x <= horizontalSpeedCap)
            {
                rb.AddForce(horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

        if ( Input.GetKey("a") ) {
            if (rb.velocity.x >= -horizontalSpeedCap)
            {
                rb.AddForce(-horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
    }
}
