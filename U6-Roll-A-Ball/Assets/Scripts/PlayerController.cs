using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [SerializeField] private float speed = 0;

    void Start()
    {
        //get & store the Rigidbody component attatched to player
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(force: movement * speed);

    }
    void OnMove(InputValue movementValue)
    {
        // convert input value into a Vector2 for movement
        Vector2 movementVector = movementValue.Get<Vector2>();

        // store the x & y components of the movement 
        movementX = movementVector.x;
        movementY = movementVector.y;


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
       
    }
}
