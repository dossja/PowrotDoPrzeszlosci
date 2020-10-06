using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    private Player player;

    public JumpCommand(Player player, KeyCode key): base(key)
    {
        this.player = player;
    }

    public override void GetKeyDown()
    {
        player.Actions.Jump();
    }
}
