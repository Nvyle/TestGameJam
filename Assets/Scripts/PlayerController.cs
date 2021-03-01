using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CameraShake cameraShake;
    Rigidbody2D rb;
    Animator animator;

    //Player Controller
    public float MovementSpeed;
    public float JumpForce;

    //Player Attack
    public GameObject snow;
    public GameObject snowinst;
    

    //Player HP
    public PlayerStatusUI playerStatusUI;
    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }
    public float healthRange { get { return (float)currentHealth / (float)maxHealth; } }



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = 100;
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
    }

    private void Update() {
        
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(!Mathf.Approximately(0, movement))
            transform.rotation = movement <  0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(Input.GetButtonDown("Jump") && Mathf.Abs (rb.velocity.y) < 0.001f){
            
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.E)){
            ShootSnowBall();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
            //Debug.Log(healthRange);

        }
    }

    void ShootSnowBall()
    {
        Instantiate(snow, snowinst.transform.position, transform.rotation);
    }

        void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        playerStatusUI.SetHealth(healthRange);

        animator.Play("PlayerDamage", 0, 0);
    }

}
