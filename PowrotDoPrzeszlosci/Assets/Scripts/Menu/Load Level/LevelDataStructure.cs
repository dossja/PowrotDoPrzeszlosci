using System.Collections.Generic;
using System;

[Serializable]
public class LevelDataStructure
{
    public List<LevelState> Levels;
}

[Serializable]
public class LevelState
{
    public int id;
    public bool enabled;
}
