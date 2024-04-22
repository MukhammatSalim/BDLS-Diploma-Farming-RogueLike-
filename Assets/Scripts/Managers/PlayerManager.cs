using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamagable
{
    [Header("Connections")]
    public PlayerData playerData;
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    public void TakeDMG(float dmg)
    {
        playerData.CurrentHP -= dmg;
        if (playerData.CurrentHP <= 0)
        {
            Debug.Log("Player is dead");
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {

    }
}
