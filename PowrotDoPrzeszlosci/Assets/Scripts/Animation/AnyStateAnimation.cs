using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The RIG for player body parts. 
/// In this case only body, but can be changed into legs and body etc.
/// </summary>

public enum RIG { BODY };

/// <summary>
/// Class for animating body parts.
/// </summary>
public class AnyStateAnimation
{
    public RIG AnimationRig { get; private set; }

    public string Name { get; set; }

    public bool Active { get; set; }

    public AnyStateAnimation(RIG rig, string name)
    {
        this.AnimationRig = rig;
        this.Name = name;
    }
}
