using System.Collections;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealthPlayer;
    public float currentHealthPlayer { get; private set; }
    private Animator anim;
    private bool dead;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private GameObject gun;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        currentHealthPlayer = startingHealthPlayer;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamagePlayer(float _damage)
    {
        currentHealthPlayer = Mathf.Clamp(currentHealthPlayer - _damage, 0, startingHealthPlayer);
        if (currentHealthPlayer > 0)
        {
            StartCoroutine(Invulnerability());
            dead = false;
        }
        else
        {
            AudioController.instance.PlayerDieSound();
            if (gun != null) gun.SetActive(false);
            anim.SetTrigger("die");
            if (GetComponent<TankerMovement>() != null) GetComponent<TankerMovement>().enabled = false;
            dead = true;

            Manager.Ins.m_isGameover = true;
            GameGUIManager.Ins.ShowPauseButton(false);
            GameGUIManager.Ins.gameDialog.UpdateDialog("Your Score : ", "Best Killed : x" + Manager.Ins.m_enemyKilled, "Survival time : " + Manager.Ins.timeLife + "s");
            GameGUIManager.Ins.gameDialog.Show(true);
            GameGUIManager.Ins.CurDialog = GameGUIManager.Ins.gameDialog;
        }
    }
    public void AddHealth(float _item)
    {
        if (isDead()) return;
        currentHealthPlayer = Mathf.Clamp(currentHealthPlayer + _item, 0, startingHealthPlayer);
    }

    private bool isDead()
    {
        return dead;
    }

    private IEnumerator Invulnerability()
    {
        // Physics2D.IgnoreLayerCollision(6,7,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        // Physics2D.IgnoreLayerCollision(6,7,false);
    }
    private void DeactivatePlayer()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
    }
}
