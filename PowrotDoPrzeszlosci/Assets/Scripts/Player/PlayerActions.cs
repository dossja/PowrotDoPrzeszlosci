using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions
{
    private Player player;

    public PlayerActions(Player player)
    {
        this.player = player;
    }

    public void Move(Transform transform)
    {
        player.Components.Rigidbody.velocity = new Vector2(player.Stats.Direction.x * player.Stats.Speed * Time.deltaTime, player.Components.Rigidbody.velocity.y);

        if(player.Stats.Direction.x != 0)
        {
            transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? 1 : -1, 1, 1);
            player.Components.Animator.TryPlayAnimation("Run");
        }
        else if(player.Components.Rigidbody.velocity == Vector2.zero)
        {
            player.Components.Animator.TryPlayAnimation("Idle");
        }
    }

    public void Jump()
    {
        if (player.Utilities.IsGrounded())
        {
            /*player.Components.Rigidbody.AddForce(new Vector2(0, player.Stats.JumpForce), ForceMode2D.Impulse);*/
            player.Components.Rigidbody.velocity = Vector2.up * player.Stats.JumpForce;
            player.Components.Animator.TryPlayAnimation("Jump");
        }
    }
}