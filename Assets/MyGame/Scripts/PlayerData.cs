using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int level;
    private int health;
    private float[] position;
    public PlayerData()
    {
        level = 0;
        health = 0;
        position = new float[3] { 0.0f, 0.0f, 0.0f };
    }

    public int Level { get => level; set => level = value; }
    public int Health { get => health; set => health = value; }
    public float[] Position { get => position; set => position = value; }
}
