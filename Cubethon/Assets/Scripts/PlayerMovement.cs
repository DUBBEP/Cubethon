using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float horizontalForce = 500f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Add forward Force
    }

    void FixedUpdate() {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);        

        if ( Input.GetKey("d") ) {
            rb.AddForce(horizontalForce * Time.deltaTime, 0, 0);
        }

        if ( Input.GetKey("a") ) {
            rb.AddForce(-horizontalForce * Time.deltaTime, 0, 0);
        }
    }
}
