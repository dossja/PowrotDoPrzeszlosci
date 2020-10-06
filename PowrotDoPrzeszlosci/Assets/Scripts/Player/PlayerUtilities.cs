using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player player;
    private List<Command> commands = new List<Command>();

    public PlayerUtilities(Player player)
    {
        this.player = player;
        commands.Add(new JumpCommand(player, KeyCode.Space));
    }

    public void HandleInput()
    {
        player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), player.Components.Rigidbody.velocity.y);

        foreach (Command command in commands)
        {
            if(Input.GetKeyDown(command.Key))
            {
                command.GetKeyDown();
            }

            if(Input.GetKeyUp(command.Key))
            {
                command.GetKeyUp();
            }

            if(Input.GetKey(command.Key))
            {
                command.GetKey();
            }
        }
    }
}