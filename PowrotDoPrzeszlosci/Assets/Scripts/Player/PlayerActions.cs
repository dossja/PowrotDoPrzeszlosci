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
            transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? -1 : 1, 1, 1);
            player.Components.Animator.TryPlayAnimation("Body_Run");
            player.Components.Animator.TryPlayAnimation("Legs_Run");
        }
        else if(player.Components.Rigidbody.velocity == Vector2.zero)
        {
            player.Components.Animator.TryPlayAnimation("Body_Idle");
            player.Components.Animator.TryPlayAnimation("Legs_Idle");
        }
    }
}