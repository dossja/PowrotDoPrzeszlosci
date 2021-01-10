using UnityEngine;

/// <summary>
/// Class for player actions that enables particleSystem and different classes.
/// </summary>
public class PlayerActions
{
    private Player player;

    private ParticleSystem particle;

    private bool goingRight;

    private PlayerPlatformDown playerPlatform;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerActions"/> class.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <param name="particle">The particle.</param>
    /// <param name="playerPlatform">The player platform.</param>
    public PlayerActions(Player player, ParticleSystem particle, PlayerPlatformDown playerPlatform)
    {
        this.player = player;
        this.particle = particle;
        this.playerPlatform = playerPlatform;
        goingRight = true;
    }

    /// <summary>
    /// Initialies the particles for move and chooses animations.
    /// </summary>
    /// <param name="transform">The transform.</param>
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

    /// <summary>
    /// Jumps player and plays the animation.
    /// </summary>
    public void Jump()
    {
        if (player.Utilities.IsGrounded())
        {
            CreateParticle();
            player.Components.Rigidbody.velocity = Vector2.up * player.Stats.JumpForce;
            player.Components.Animator.TryPlayAnimation("Jump");
        }
    }

    /// <summary>
    /// Crouches player and plays the animation.
    /// </summary>
    public void Crouch()
    {
        if(player.Utilities.IsOnTile())
        {
            playerPlatform.GoingDown();
            player.Components.Animator.TryPlayAnimation("Crouch");
        }
    }

    /// <summary>
    /// Creates the particle.
    /// </summary>
    private void CreateParticle()
    {
        particle.Play();
    }
}