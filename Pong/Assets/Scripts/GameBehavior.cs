using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    
    public Player[] Players = new Player[2];

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("New instance initialized...");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance found and deleted...");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetGame();
    }

    void ResetGame ()
    {
        foreach (Player p in Players)
        {
            p.Score = 0;
        }
    }

    public void ScorePoint(int playerNumber)
    {
        Players[playerNumber].Score++;
    }

}
