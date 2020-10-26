using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerUtilities
{
    private Player player;

    private Joystick joystick;

    public PlayerUtilities(Player player, Joystick joystick)
    {
        this.player = player;
        this.joystick = joystick;
    }

    public void HandleInput()
    {
        //player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), player.Components.Rigidbody.velocity.y);
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
            player.Stats.Direction = new Vector2(joystick.Horizontal, 0);
        else
            player.Stats.Direction = new Vector2(0, player.Components.Rigidbody.velocity.y);

        if (joystick.Vertical > 0.5f)
            player.Actions.Jump();
        else if (joystick.Vertical < -0.5f)
            player.Actions.Crouch();
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(player.Components.Collider.bounds.center, player.Components.Collider.bounds.size, 0, Vector2.down, 0.1f, player.Components.GroundLayer);
        if(hit.collider == null)
        {
            hit = Physics2D.BoxCast(player.Components.Collider.bounds.center, player.Components.Collider.bounds.size, 0, Vector2.down, 0.1f, player.Components.EnemyLayer);
            if (hit.collider == null)
            {
                hit = Physics2D.BoxCast(player.Components.Collider.bounds.center, player.Components.Collider.bounds.size, 0, Vector2.down, 0.1f, player.Components.TileLayer);
            }
        }
        return hit.collider != null;
    }

    public bool IsOnTile()
    {
        RaycastHit2D hit = Physics2D.BoxCast(player.Components.Collider.bounds.center, player.Components.Collider.bounds.size, 0, Vector2.down, 0.1f, player.Components.TileLayer);

        return hit.collider != null;
    }

    public void HandleAir()
    {
        if(IsFalling())
        {
            player.Components.Animator.TryPlayAnimation("Fall");
        }
    }

    private bool IsFalling()
    {
        if(player.Components.Rigidbody.velocity.y < 0 && !IsGrounded())
        {
            return true;
        }
        return false;
    }
}