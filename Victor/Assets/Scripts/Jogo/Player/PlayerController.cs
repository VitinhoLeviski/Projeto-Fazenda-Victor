using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Inputsystem
    public InputActionAsset controlador;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction ghostAction;
    private InputAction pauseAction;



    public GameObject projectilePrefab;
    public GameObject buttons;

    private float speed = 20f;
    private float xRange = 20f;

    // Start is called before the first frame update


    private void OnEnable()
    {
        controlador.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        controlador.FindActionMap("Player").Disable();
    }



    private void Awake()
    {
        moveAction = controlador.FindAction("Move");
        fireAction = controlador.FindAction("Jump");
        ghostAction = controlador.FindAction("Ghost");
        pauseAction = controlador.FindAction("pause");
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
        move();
        fire();
        ghost();
        float Moveside = moveAction.ReadValue<Vector2>().x;

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

    void move()
    {
        float Moveside = moveAction.ReadValue<Vector2>().x;
    }
    void ghost()
    {
        if (ghostAction.WasPressedThisFrame())
        {
            StartCoroutine(ghostTime());

        }
    }

    void fire()
    {
        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }

    void stop()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            Time.timeScale = 0f;
            OnDisable();
        }
    }

    IEnumerator ghostTime()
    {
        GetComponentInChildren<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(2f);

        GetComponentInChildren<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
