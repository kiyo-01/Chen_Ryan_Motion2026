using UnityEngine;

public class PirateShip : MonoBehaviour
{
    public ScoreboardController scoreboard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        scoreboard.Score++;
    }
}
