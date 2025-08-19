using UnityEngine;
using UnityEngine.UI;

public class HpUiControl : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void SetMaxHearts(int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < maxHealth;
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdatedHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].sprite = emptyHeart; // ← usa sprite vazio em vez de deixar preto
                hearts[i].enabled = false;
            }
        }
    }
}