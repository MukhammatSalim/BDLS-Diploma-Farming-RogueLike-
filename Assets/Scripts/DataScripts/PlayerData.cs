using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData", order = 2, fileName = "NewPlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Profile")]
    public string Name;
    [Header("GameData:")]
    [Header("Movement")]
    public float MovementSpeed;
    [Header("Shooting")]
    public float BulletSpeed;
    public float BulletLifeTime;
    public float FireRate;
    public float Spread;
}
