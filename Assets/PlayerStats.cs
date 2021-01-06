using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
    
    int GetMoney()
    {
        return Money;
    }

    void AddMoney(int amount)
    {
        Money += amount;
    }

    void SubtractMoney(int amount)
    {
        Money -= amount;
    }

    int GetLives()
    {
        return Lives;
    }

    void AddLives(int amount)
    {
        Lives += amount;
        if(Lives <= 0)
        {
            GameOver();
        }
    }

    void SubtractLives(int amount)
    {
        Lives -= amount;
    }

    void GameOver()
    {
        Debug.Log("Game Over"); //do some fance game over stuff!
    }
}
