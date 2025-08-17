using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContMoeda : MonoBehaviour
{
    int moeda = 0;
    public TextMeshProUGUI contMoeda;
    AudioSource audioSource;

    void Start()
    {
        
    }

    void Update()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 0.1f, 128);
        if (collision != null)
        {
            if (collision.CompareTag("moeda"))
            {
                moeda++;
                contMoeda.text = moeda.ToString();
                audioSource.Play();
                Destroy(collision.gameObject);
            }
        }
    }
}
