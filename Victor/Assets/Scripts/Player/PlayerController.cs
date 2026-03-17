using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject buttons;
    private float speed = 20f;
    private float xRange = 20f;
    public GameObject projectilePrefab;
    private float Moveside;


    // Start is called before the first frame update
    private void Awake() {
        
    }
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            buttons.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * Moveside);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
    }

    public void MoveEvent(InputAction.CallbackContext context)
    {
        Moveside = context.ReadValue<Vector2>().x;
    }

    public void FireEvent(InputAction.CallbackContext context)
    {
        if (context.performed) {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
