using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int playerSpeed = 10;
    [SerializeField] int jumpMaxNumber = 2;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] GameObject weaponHolder;

    InputProvider inputProvider;
    Rigidbody2D rb;

    Vector2 dir;
    int jumpNumber = 0;
    bool isJumping = false;
    int lastDirX = 0;

    private void Awake()
    {
        inputProvider = GetComponent<InputProvider>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (inputProvider != null)
        {
            dir = inputProvider.Move();
            if (inputProvider.Jump()) isJumping = true;
            if (inputProvider.ToggleWeapon()) ToggleWeapon();
        }
    }

    private void FixedUpdate()
    {
        Move();
        RotatePlayer();
        Jump();
    }

    void Move()
    {
        rb.velocity = new(dir.x * playerSpeed, rb.velocity.y);
    }

    void RotatePlayer()
    {
        if (lastDirX != dir.x)
        {
            if (dir.x == 0) return;
            int rotY = dir.x > 0 ? 0 : 180;
            transform.localRotation = Quaternion.Euler(0f, rotY, 0f);
            lastDirX = (int)dir.x;
        }
    }


    void Jump()
    {
        if (isJumping && jumpNumber < jumpMaxNumber)
        {
            rb.velocity += Vector2.up * jumpForce;
            jumpNumber++;
            isJumping = false;

        }

        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jumpNumber = 0;
            isJumping = false;
        }
    }

    void ToggleWeapon()
    {
        weaponHolder.SetActive(!weaponHolder.activeInHierarchy);
    }
}
