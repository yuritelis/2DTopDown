using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MexerZapZap : MonoBehaviour
{
    float vZap = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.y <= 0)
        {
            transform.position += new Vector3(0, vZap * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level01");
        }
    }
}
