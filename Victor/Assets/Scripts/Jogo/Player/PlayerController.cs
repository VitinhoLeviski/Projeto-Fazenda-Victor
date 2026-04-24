using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    menuManagerGame menu;

    public GameObject projectilePrefab;
    public GameObject buttons;

    //Inputsystem
    public InputActionAsset controlador;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction ghostAction;
    private InputAction pauseAction;


    [HideInInspector] public int vidas = 3;
    bool intervalo = false;
    private float speed = 20f;
    private float xRange = 18f;

    // Start is called before the first frame update


    public void OnEnable()
    {
        controlador.FindActionMap("Player").Enable();
    }
    public void OnDisable()
    {
        controlador.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        menu = FindFirstObjectByType<menuManagerGame>();

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
        stop();
        float Moveside = moveAction.ReadValue<Vector2>().x;

        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * Moveside);

        // mantêm o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    void move()
    {
        float Moveside = moveAction.ReadValue<Vector2>().x;
    }
    IEnumerator ghostTime()
    {
        GetComponentInChildren<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(2f);

        GetComponentInChildren<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        intervalo = false;

    }
    void ghost()
    {
        if (ghostAction.WasPressedThisFrame() && intervalo == false)
        {
            StartCoroutine(ghostTime());
            intervalo = true;
        }
    }
    void fire()
    {
        if (fireAction.WasPressedThisFrame())
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, 0, 1);

            Instantiate(projectilePrefab, spawnPosition, projectilePrefab.transform.rotation);
        }
    }
    void stop()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            Time.timeScale = 0f;
            OnDisable();
            
            menu.opcoes();
        }
    }
}
