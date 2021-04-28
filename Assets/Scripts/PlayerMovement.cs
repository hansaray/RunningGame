using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 6.5f;
    public float speedIncreasePerPoint = 0.1f;
    float horizontalInput;
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;
    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Animator animatorController;

    void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(transform.position.y < -5) // if it falls down
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        animatorController.SetBool("Hit", true);
        GameManager.inst.GameOver();
        //Invoke("Restart", 2);
    }

    void Restart()
    {
        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (isGrounded)
        {
            //if we are, then jump
            animatorController.SetBool("Jump", true);
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
