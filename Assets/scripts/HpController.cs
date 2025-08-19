using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpController : MonoBehaviour
{
    [Header("Health Settings")]
    public int hpAtual = 6;
    public int hpMax = 6;

    public HpUiControl hpUI;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    int danoInimigo = 2;
    int danoTrap = 1;
    public AudioClip somDano;


    void Start()
    {
        hpUI.SetMaxHearts(hpMax);

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(hpAtual <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("inimigo"))
        {
            TakeDamage(danoInimigo);
            Destroy(collision.gameObject);
            if (somDano != null)
                audioSource.PlayOneShot(somDano);
        }
        else if (collision.collider.CompareTag("trap"))
        {
            TakeDamage(danoTrap);
            Destroy(collision.gameObject);
            if (somDano != null)
                audioSource.PlayOneShot(somDano);
        }
    }

    public void TakeDamage(int dano)
    {
        hpAtual -= dano;
        Debug.Log($"[{gameObject.name}] Dano: {dano}, HP restante: {hpAtual}");

        hpUI.UpdatedHearts(hpAtual);

        StartCoroutine(FlashRed());
        StartCoroutine(BlinkSprite());
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator BlinkSprite()
    {
        float duration = 0.6f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.2f;
        }
    }
    private void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}