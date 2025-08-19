using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpController : MonoBehaviour
{
    [Header("Health Settings")]
    public int hpMax = 6;
    private int hpAtual;
    private bool isInvulnerable = false;
    [SerializeField] private float iFramesDuration = 0.3f;

    public HpUiControl hpUI;
    private SpriteRenderer spriteRenderer;

    int danoInimigo = 2;
    int danoTrap = 1;

    void Start()
    {
        hpAtual = hpMax;
        hpUI.SetMaxHearts(hpMax);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("inimigo"))
        {
            TakeDamage(danoInimigo);
            Destroy(collision.gameObject);
            Debug.Log("perdeu vida");
        }
        else if (collision.collider.CompareTag("trap"))
        {
            TakeDamage(danoTrap);
            Destroy(collision.gameObject);
            Debug.Log("perdeu vida");
        }
    }

    public void TakeDamage(int dano)
    {
        if (isInvulnerable) return;
        hpAtual -= dano;
        hpUI.UpdatedHearts(hpAtual);

        StartCoroutine(FlashRed());
        if (hpAtual <= 0)
        {
            Die();
        }
        StartCoroutine(ActivateIFrames());
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator ActivateIFrames()
    {
        isInvulnerable = true;

        float elapsed = 0f;
        while (elapsed < iFramesDuration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.2f;
        }

        isInvulnerable = false;
    }


    private void Die()
    {
        //SceneManager.LoadScene("GameOver");
    }
}