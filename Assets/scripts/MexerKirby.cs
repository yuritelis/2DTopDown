using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MexerKirby : MonoBehaviour
{
    [SerializeField]
    float velKirby = 0.001f;

    SpriteRenderer spriteRenderer; // muda o sprite do jogador

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // liga o spriteRenderer ao objeto player
        if (spriteRenderer == null)
        {
            Debug.LogError("É um sprite?");
        }
    }

    void Update()
    {
        Vector3 direcao = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, velKirby, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-velKirby, 0, 0);

            spriteRenderer.flipX = true; // muda a direção em que o sprite ta olhando
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -velKirby, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velKirby, 0, 0);

            spriteRenderer.flipX = false; // o sprite volta para o sentido original
        }

        transform.position += direcao;
        /*
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 0.1f);
        if (collision != null)
        {
            transform.position -= direcao;
            Debug.Log("Colidiu com: " + collision.gameObject.name);
        }*/
    }
}
