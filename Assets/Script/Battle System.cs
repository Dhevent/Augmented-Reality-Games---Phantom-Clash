using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BattleSystem : MonoBehaviour
{
    [Header("Player Stats")]
    public int playerMaxHP = 100;
    public int playerCurrentHP;
    public int playerDamage = 20;

    [Header("Monsters")]
    public monsterskontrol[] monsters;
    private monsterskontrol currentMonster;

    [Header("UI Health Bars")]
    public healthbar playerHealthBar;
    public healthbar monsterHealthBar;

    [Header("Monster Action Icons")]
    public GameObject monsterAttackLogo;
    public GameObject monsterDefenceLogo;
    public GameObject monsterRunLogo;

    [Header("Hit Effects")]
    public GameObject hitEffectPrefab;
    public Transform monsterHitPoint;
    public GameObject playerHitPanel;

    [Header("UI Panels")]
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Action Buttons")]
    public Button attackButton;
    public Button defenceButton;
    public Button runButton;

    [Header("Audio Clips")]
    public AudioSource audioSource;
    public AudioClip loseClip;
    public AudioClip winClip;

    public enum Action { Attack, Defence, Run }
    private bool isBusy = false;

    void Start()
    {
        Time.timeScale = 1f;
        playerCurrentHP = playerMaxHP;
        playerHealthBar.SetMaxHealth(playerMaxHP);

        if (monsters.Length > 0)
        {
            currentMonster = monsters[0];
            monsterHealthBar.SetMaxHealth(currentMonster.hp);
            Debug.Log("Current Monster: " + currentMonster.monsterName);
        }

        monsterAttackLogo.SetActive(false);
        monsterDefenceLogo.SetActive(false);
        monsterRunLogo.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        playerHitPanel.SetActive(false);
    }

    public void SelectMonster(int index)
    {
        if (index >= 0 && index < monsters.Length)
        {
            currentMonster = monsters[index];
            monsterHealthBar.SetMaxHealth(currentMonster.hp);
            Debug.Log("Switched to Monster: " + currentMonster.monsterName);
        }
    }

    public void PlayerAction(string actionName)
    {
        if (isBusy || currentMonster == null) return;

        if (!System.Enum.TryParse(actionName, true, out Action playerAction))
        {
            Debug.LogError("Invalid action: " + actionName);
            return;
        }

        Action monsterAction = (Action)Random.Range(0, 3);

        Debug.Log($"Player: {playerAction} vs {currentMonster.monsterName}: {monsterAction}");

        currentMonster.PlayAction(monsterAction.ToString());
        ShowMonsterAction(monsterAction);

        if (playerAction == monsterAction)
        {
            playerCurrentHP -= currentMonster.damage;
            currentMonster.hp -= playerDamage;

            StartCoroutine(ShowPlayerHitPanel(0.3f));
            SpawnHitEffect(monsterHitPoint);
        }
        else if (WinsOver(playerAction, monsterAction))
        {
            currentMonster.hp -= playerDamage;
            SpawnHitEffect(monsterHitPoint);
        }
        else
        {
            playerCurrentHP -= currentMonster.damage;
            StartCoroutine(ShowPlayerHitPanel(0.3f));
        }

        playerHealthBar.SetHealth(playerCurrentHP);
        monsterHealthBar.SetHealth(currentMonster.hp);

        if (currentMonster.hp <= 0)
        {
            currentMonster.Die();
            StartCoroutine(ShowWinPanelAfterDelay(2f));
        }

        if (playerCurrentHP <= 0)
        {
            Debug.Log("Player defeated!");
            ShowGameOver();
        }

        StartCoroutine(ActionCooldown(2f));
    }

    bool WinsOver(Action a, Action b)
    {
        return (a == Action.Attack && b == Action.Run) ||
               (a == Action.Run && b == Action.Defence) ||
               (a == Action.Defence && b == Action.Attack);
    }

    void ShowMonsterAction(Action monsterAction)
    {
        monsterAttackLogo.SetActive(false);
        monsterDefenceLogo.SetActive(false);
        monsterRunLogo.SetActive(false);

        if (monsterAction == Action.Attack)
            StartCoroutine(ShowLogo(monsterAttackLogo));
        else if (monsterAction == Action.Defence)
            StartCoroutine(ShowLogo(monsterDefenceLogo));
        else if (monsterAction == Action.Run)
            StartCoroutine(ShowLogo(monsterRunLogo));
    }

    IEnumerator ShowLogo(GameObject logo)
    {
        if (logo == null) yield break;
        logo.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        logo.SetActive(false);
    }

    void SpawnHitEffect(Transform spawnPoint)
    {
        if (hitEffectPrefab != null && spawnPoint != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    IEnumerator ShowPlayerHitPanel(float duration)
    {
        playerHitPanel.SetActive(true);
        yield return new WaitForSeconds(duration);
        playerHitPanel.SetActive(false);
    }

    void ShowGameOver()
    {
        if (audioSource != null && loseClip != null)
            audioSource.PlayOneShot(loseClip);

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    IEnumerator ShowWinPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (audioSource != null && winClip != null)
            audioSource.PlayOneShot(winClip);

        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    IEnumerator ActionCooldown(float duration)
    {
        isBusy = true;
        attackButton.interactable = false;
        defenceButton.interactable = false;
        runButton.interactable = false;

        yield return new WaitForSeconds(duration);

        attackButton.interactable = true;
        defenceButton.interactable = true;
        runButton.interactable = true;
        isBusy = false;
    }
}
