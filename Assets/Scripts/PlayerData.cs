
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int score;

    public PlayerData()
    {
        score = GameManager.inst.score;
    }

}
