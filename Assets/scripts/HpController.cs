using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpController : MonoBehaviour
{
    [Header("Health Settings")]
    public int hpAtual = 6;
    public int danoRecebe = 0;
    private bool isInvulnerable = false;
    [SerializeField] private float iFramesDuration = 0.3f;

    public HpUiControl hpUI;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    int danoInimigo = 2;
    int danoTrap = 1;

    void Start()
    {
        hpUI.SetMaxHearts(hpAtual);

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("inimigo"))
        {
            TakeDamage(danoInimigo);
            danoRecebe += danoInimigo;
            Destroy(collision.gameObject);
            Debug.Log("perdeu vida");
            audioSource.Play();
        }
        else if (collision.collider.CompareTag("trap"))
        {
            TakeDamage(danoTrap);
            danoRecebe += danoTrap;
            Destroy(collision.gameObject);
            Debug.Log("perdeu vida");
            audioSource.Play();
        }
    }

    public void TakeDamage(int dano)
    {
        if (isInvulnerable) return;
        hpAtual -= dano;
        hpUI.UpdatedHearts(hpAtual);

        StartCoroutine(FlashRed());
        if (hpAtual <= 0 && danoRecebe >= 6)
        {
            //Die();
            SceneManager.LoadScene("GameOver");
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
        SceneManager.LoadScene("GameOver");
    }
}