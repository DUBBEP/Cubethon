using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Renderer rend;
    private float flashTime = 0f;

    public PlayerMovement movement;
    public Rigidbody rb;
    public Material hitMat;
    public Material playerMat;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (flashTime >= 0f)
        {
            rend.material = hitMat;
            flashTime -= Time.deltaTime;
        } else if (flashTime <= 0f)
        {
            rend.material = playerMat;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<Collider>().tag == "Obstacle") 
        {
            rb.constraints &= ~RigidbodyConstraints.FreezeRotation;
            movement.unfrozen = true;
            flashTime = 0.3f;        
        }
        if (other.GetComponent<Collider>().tag == "UnfreezeTrigger")
        {
            rb.constraints &= ~RigidbodyConstraints.FreezeRotation;
            movement.unfrozen = true;         
        }    
        if (other.GetComponent<Collider>().tag == "FreezeTrigger")
        {
            movement.unfrozen = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Obstacle") {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            flashTime = 0.3f; 
        }
    }
}
