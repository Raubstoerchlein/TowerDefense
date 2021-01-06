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

    public static int GetMoney()
    {
        return Money;
    }

    public static void AddMoney(int amount)
    {
        Money += amount;
    }

    public static void SubtractMoney(int amount)
    {
        Money -= amount;
    }

    public static int GetLives()
    {
        return Lives;
    }

    public static void AddLives(int amount)
    {
        Lives += amount;
    }

    public static void SubtractLives(int amount)
    {
        Lives -= amount;
        if (Lives <= 0)
        {
            GameOver();
        }
    }

    public static void GameOver()
    {
        Debug.Log("Game Over"); //do some fance game over stuff!
        Time.timeScale = 0;
    }
}
