using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                                  // Speed Function announced
    public float jumpForce = 5.0f;                                  // Jump Height Function announced

    public bool isGrounded = true;                                  // GroundCheck Function announced

    public Rigidbody rb;                                            // Player Rigidbody announced
     
    public int coinCount = 0;                                       // CoinCount announced
    public List<GameObject> totalCoins = new List<GameObject>();      // Total Coin announced

    public GameObject door, endingText;

    private void Start()
    {
        door.SetActive(false);
        endingText.SetActive(false);
    }

    void Update()
    {
        // Player Input Check
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Player Speed Value Directly Movement
        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
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
        }
    }
}
