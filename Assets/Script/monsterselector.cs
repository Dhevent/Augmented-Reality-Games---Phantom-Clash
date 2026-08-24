using UnityEngine;

public class monsterelector : MonoBehaviour
{
    public int monsterIndex;
    private BattleSystem battleSystem;

    void Start()
    {
        battleSystem = Object.FindFirstObjectByType<BattleSystem>();
    }

    public void OnMonsterDetected()
    {
        if (battleSystem != null)
        {
            battleSystem.SelectMonster(monsterIndex);
            Debug.Log("Monster changed via QR: " + monsterIndex);
        }
        else
        {
            Debug.LogWarning("BattleSystem not found!");
        }
    }
}
