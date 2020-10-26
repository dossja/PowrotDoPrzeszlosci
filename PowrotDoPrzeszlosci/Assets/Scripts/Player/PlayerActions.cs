using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActions
{
    private Player player;

    private ParticleSystem particle;

    private bool goingRight;

    private PlayerPlatformDown playerPlatform;

    public PlayerActions(Player player, ParticleSystem particle, PlayerPlatformDown playerPlatform)
    {
        this.player = player;
        this.particle = particle;
        this.playerPlatform = playerPlatform;
        goingRight = true;
    }

    public void Move(Transform transform)
    {
        player.Components.Rigidbody.velocity = new Vector2(player.Stats.Direction.x * player.Stats.Speed * Time.deltaTime, player.Components.Rigidbody.velocity.y);

        if(player.Stats.Direction.x != 0)
        {
            if (player.Stats.Direction.x < 0 && goingRight == true)
            {
                CreateParticle();
                goingRight = false;
            }
            else if (player.Stats.Direction.x > 0 && goingRight == false)
            {
                CreateParticle();
                goingRight = true;
            }
            transform.localScale = new Vector3(player.Stats.Direction.x < 0 ? 1 : -1, 1, 1);
            particle.transform.localScale = new Vector3(player.Stats.Direction.x > 0 ? 1 : -1, 1, 1);

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
            CreateParticle();
            player.Components.Rigidbody.velocity = Vector2.up * player.Stats.JumpForce;
            player.Components.Animator.TryPlayAnimation("Jump");
        }
    }

    public void Crouch()
    {
        if(player.Utilities.IsOnTile())
            playerPlatform.GoingDown();
    }

    private void CreateParticle()
    {
        particle.Play();
    }
}