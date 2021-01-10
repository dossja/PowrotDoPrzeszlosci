using UnityEngine;

/// <summary>
/// Class for player utilities (Movement and it's compoments)
/// </summary>
[System.Serializable]
public class PlayerUtilities
{
    private Player player;

    private Joystick joystick;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerUtilities"/> class.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <param name="joystick">The joystick.</param>
    public PlayerUtilities(Player player, Joystick joystick)
    {
        this.player = player;
        this.joystick = joystick;
    }

    /// <summary>
    /// Handles the joystick input.
    /// </summary>
    public void HandleInput()
    {
        if (joystick.Horizontal > 0.2f || joystick.Horizontal < -0.2f)
            player.Stats.Direction = new Vector2(joystick.Horizontal, 0);
        else
            player.Stats.Direction = new Vector2(0, player.Components.Rigidbody.velocity.y);

        if (joystick.Vertical > 0.5f)
            player.Actions.Jump();
        else if (joystick.Vertical < -0.5f)
            player.Actions.Crouch();
    }

    /// <summary>
    /// Checks if the player feet collides with anything (if player is not in air), in order to let him jump.
    /// </summary>
    /// <returns>A bool.</returns>
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

    /// <summary>
    /// Checks if player feet are on the tile platform.
    /// </summary>
    /// <returns>A bool.</returns>
    public bool IsOnTile()
    {
        RaycastHit2D hit = Physics2D.BoxCast(player.Components.Collider.bounds.center, player.Components.Collider.bounds.size, 0, Vector2.down, 0.1f, player.Components.TileLayer);

        return hit.collider != null;
    }

    /// <summary>
    /// Handles the fall animation if player is in air
    /// </summary>
    public void HandleAir()
    {
        if(IsFalling())
        {
            player.Components.Animator.TryPlayAnimation("Fall");
        }
    }

    /// <summary>
    /// Returns if player is falling in air or not
    /// </summary>
    /// <returns>A bool.</returns>
    private bool IsFalling()
    {
        if(player.Components.Rigidbody.velocity.y < 0 && !IsGrounded())
        {
            return true;
        }
        return false;
    }
}