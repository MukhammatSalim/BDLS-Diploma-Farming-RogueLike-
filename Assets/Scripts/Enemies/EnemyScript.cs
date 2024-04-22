using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamagable
{
    [Header("Stats")]
    public float MaxHP;
    public float CurrentHP;
    public float MovementSpeed;
    public float DMG;

    public void TakeDMG(float dmg)
    {
        CurrentHP -= dmg;
        if (CurrentHP <= 0) EnemyDead();
    }

    public void EnemyDead(){
        Debug.Log("Enemy is dead");
    }
    private void Update() {
        gameObject.transform.position = Vector2.MoveTowards(transform.position,PlayerManager.instance.gameObject.transform.position, MovementSpeed * Time.deltaTime);
    }

}
