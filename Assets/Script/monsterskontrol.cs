using UnityEngine;

public class monsterskontrol : MonoBehaviour
{
    [Header("Monster Stats")]
    [SerializeField] public string monsterName = "Dragon Boss";
    [SerializeField] public int hp = 100;
    [SerializeField] public int damage = 15;

    [Header("Animation References")]
    [SerializeField] public Animator animator;        
    [SerializeField] public Animation legacyAnimation; 

    public void PlayAction(string action)
    {
        if (animator != null)
        {
            animator.SetTrigger(action);
            Debug.Log(monsterName + " Animator plays: " + action);
        }
        else if (legacyAnimation != null && legacyAnimation.GetClip(action) != null)
        {
            legacyAnimation.Play(action);
            Debug.Log(monsterName + " Legacy plays: " + action);
        }
        else
        {
            Debug.LogWarning(monsterName + " has no animation for: " + action);
        }
    }

    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        else if (legacyAnimation != null && legacyAnimation.GetClip("Die") != null)
        {
            legacyAnimation.Play("Die");
        }
        Debug.Log(monsterName + " defeated!");
    }
}
