using System.Collections.Generic;
using System;

/// <summary>
/// Class for level data structure with list of LevelStates inside.
/// </summary>
[Serializable]
public class LevelDataStructure
{
    public List<LevelState> Levels;
}

/// <summary>
/// Level States with id and enabled bool.
/// </summary>
[Serializable]
public class LevelState
{
    public int id;
    public bool enabled;
}
