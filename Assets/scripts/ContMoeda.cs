using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContMoeda : MonoBehaviour
{
    public int contMoeda = 0;
    public TextMeshProUGUI contMoedaTxt;
    AudioSource audioSource;
    public AudioClip somMoeda;

    void Start()
    {
        contMoedaTxt.text = contMoeda.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(contMoeda >= 15)
        {
            SceneManager.LoadScene("FimJogo");
        }
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("moeda"))
        {
            contMoeda++;
            contMoedaTxt.text = contMoeda.ToString();
            Destroy(collision.gameObject);
            audioSource.Play();
            if (somMoeda != null)
                audioSource.PlayOneShot(somMoeda);
        }
    }
}
