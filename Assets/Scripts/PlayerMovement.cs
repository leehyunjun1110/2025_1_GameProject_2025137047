using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("�⺻ �̵� ����")]
    public float moveSpeed = 5.0f;                                      // Speed Function announced
    public float jumpForce = 7.0f;                                      // Jump Height Function announced
    public float turnSpeed = 10f;

    [Header("���� ���� ����")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    [Header("���� ���� ����")]
    public float coyoteTime = 0.15f;
    public float coyoteTimeCounter;
    public bool realGrounded = true;

    [Header("�۶��̴� ����")]
    public GameObject gliderObject;
    public float gliderFallSpeed = 1.0f;
    public float gliderMoveSpeed = 7.0f;
    public float gliderMaxTime = 5.0f;
    public float gliderTimeLeft;
    public bool isGliding = false;

    public bool isGrounded = true;                                      // GroundCheck Function announced

    public Rigidbody rb;                                                // Player Rigidbody announced
     
    public int coinCount = 0;                                           // CoinCount announced
    public List<GameObject> totalCoins = new List<GameObject>();        // Total Coin announced

    public GameObject door, endingText;

    private void Start()
    {
        if (gliderObject != null)
            gliderObject.SetActive(false);
        if (door == null)
            Debug.Log("Door�� �����ϴ�.");
        else
            door.SetActive(false);
        if (endingText == null)
            Debug.Log("EndingText�� �����ϴ�.");
        else
            endingText.SetActive(false);

        gliderTimeLeft = gliderMaxTime;

        coyoteTimeCounter = 0;
    }

    void Update()
    {
        //GroundedCheckActive
        UpdateGroundedState();

        // Player Input Check
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.G) && !isGrounded && gliderTimeLeft > 0)
        {
            if (!isGliding)
            {
                EnableGlider();
            }

            gliderTimeLeft -= Time.deltaTime;

            if (gliderTimeLeft <= 0)
            {
                DisableGlider();
            }
        }
        else if (isGliding)
        {
            DisableGlider();
        }

        if(isGliding)
        {
            ApplyGliderMovement(moveHorizontal, moveVertical);
        }
        else
        {
            // Player Speed Value Directly Movement
            rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        if(isGrounded)
        {
            if (isGliding)
            {
                DisableGlider();
            }

            gliderTimeLeft = gliderMaxTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            coyoteTimeCounter = 0;
        }
    }

    void UpdateGroundedState()
    {
        if (realGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            isGrounded = true;
        }
        else
        {
            if (coyoteTimeCounter > 0)
            {
                coyoteTimeCounter -= Time.deltaTime;
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            realGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
       if (collision.gameObject.tag == "Ground")
       {
            realGrounded = true;
       }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            realGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            Debug.Log($"���� ���� : {coinCount}/{totalCoins.Count}");
            if (coinCount == totalCoins.Count)
            {
                door.SetActive(true);
            }
        }
        if(other.CompareTag("Door"))
        {
            endingText.SetActive(true);
            Invoke("RestartGame", 3.0f);
        }
        if (other.gameObject.tag == "DeadZone")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void EnableGlider()
    {
        isGliding = true;

        if(gliderObject != null)
        {
            gliderObject.SetActive(true);
        }

        rb.velocity = new Vector3(rb.velocity.x, gliderFallSpeed, rb.velocity.z);
    }
    void DisableGlider()
    {
        isGliding = false;

        if (gliderObject != null)
        {
            gliderObject.SetActive(false);
        }

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }
    void ApplyGliderMovement(float horizontal, float vertical)
    {
        Vector3 gliderVelocity = new Vector3(horizontal * gliderMoveSpeed, -gliderFallSpeed, vertical * gliderMoveSpeed);
    }
}
