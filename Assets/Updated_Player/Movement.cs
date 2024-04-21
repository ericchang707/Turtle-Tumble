// Author: Adib Hasan
// Contributor(s): Colby Heist 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public WinLoseManager winLoseManager;
    public float speed;
    public float rotationSpeed;
    public int HP = 100;
    public Slider healthBar;
    public Image background; 
    private Animator animator;
    private CharacterController characterController;
    private Rigidbody rb;
    private float ySpeed;
    private float lastY;
    private bool pressed;
    private bool jumped;
    private float horizontalInput; // Declaring here as a member variable
    private float verticalInput; // Declaring here as a member variable
    
    private float xMultiplier = 1.0f;
    private float yMultiplier = 1.0f;
    private bool powerUpMode = false;
    public bool killMode = false;
    private float powerUpTime = 0.0f;
    public GameObject reviveScreen;
    private bool reviveMode = false;
    private float reviveTime = 0.0f;
    public Transform orientation;
    
    public GameObject InventoryManager;

    public int groundContactCount = 0;

    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        pressed=false;
        reviveScreen.SetActive(false);
        lastY = transform.position.y;
        healthBar.value = HP;
        //         if (HP>0) {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        healthBar.value = HP;
        // Debug.Log("Health: "+ HP);
        // if (HP>0) {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // }
        updateSlider();
        if (powerUpTime >= 20.0f) {
            powerUpMode = false;
            powerUpTime = 0.0f;
            killMode = false;
            xMultiplier = 1.0f;
            yMultiplier = 1.0f;
        }
        if (reviveTime >= 3.0f) {
            reviveMode = false;
            reviveScreen.SetActive(false);
            reviveTime = 0.0f;
        }
        if (powerUpMode) {
            powerUpTime += Time.deltaTime;
        }
        if (reviveMode) {
            reviveTime += Time.deltaTime;
        }
    
        Vector3 movementDirection = verticalInput * orientation.forward + horizontalInput * orientation.right;

        if(HP<=0) {
            if (InventoryManager.GetComponent<InventoryManager>().extraLives <= 0) {
                movementDirection = Vector3.zero;
        }
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (!powerUpMode) {
                int powerUp = InventoryManager.GetComponent<InventoryManager>().usePowerUp();
                switch (powerUp) {
                    case 1:
                        killMode = true;
                        powerUpMode = true;
                        break;
                    case 2:
                        yMultiplier = 2.5f;
                        powerUpMode = true;
                        break;
                    case 3:
                        xMultiplier = 2.2f;
                        powerUpMode = true;
                        break;
                    default:
                        break;
                }

            }
            
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            jumped = false;
            animator.SetBool("IsJumping", jumped);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            jumped = true;
            ySpeed = 3f * yMultiplier;
            animator.SetBool("IsJumping", jumped);
        }


        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed * xMultiplier;

        movementDirection.Normalize();


        ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeDamage(int damageAmount) {
        HP -= damageAmount;
        if(HP<=0) {
            if (InventoryManager.GetComponent<InventoryManager>().extraLives > 0) {
                InventoryManager.GetComponent<InventoryManager>().useExtraLife();
                reviveMode = true;
                reviveScreen.SetActive(true);
                HP = 100;
            } else {
                //Play Death Animation
                animator.SetTrigger("die");
                animator.SetBool("IsMoving", false);
                winLoseManager.DisplayLoseText();
                // movementDirection=Vector3.zero;
            }
        } else {
            // Play Get Hit Animation
            animator.SetTrigger("damage");
            animator.SetBool("IsMoving", true);


        }
    }
        private void updateSlider()
    {

        if (healthBar.value <= 50)
        {

            background.color = Color.red;
        }
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ground"))
        {
            ++groundContactCount;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            --groundContactCount;
        }
    }
}
