using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The player class that allows to handles Player actions.
/// </summary>

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float jumpForce = 8.0f;
    [SerializeField]
    private bool grounded = false;

    private bool resetJump = false;

    // Start is called before the first frame update
    /// <summary>
    /// Assigns the rigidBody2D during game setup.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /// <summary>
    /// Updates the Player movement.
    /// </summary>
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);

            grounded = false;
            resetJump = true;
            StartCoroutine(ResetJumpCorutine());
        }

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        if (raycastHit.collider != null)
        {
            if(resetJump == false)
                grounded = true;
        }


        _rigidbody.velocity = new Vector2(move, _rigidbody.velocity.y);
    }

    /// <summary>
    /// Resets the jump corutine.
    /// </summary>
    /// <returns>An IEnumerator.</returns>
    IEnumerator ResetJumpCorutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
