using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class menuManagerGame : MonoBehaviour
{
    LifendPoints player;
    PlayerController controller;

    public GameObject gOver;
    public GameObject telaSair;
    public GameObject telaOpcoes;

    public Text lifes;
    public Text points;

    [HideInInspector] public bool gameOver = false;
    void Start()
    {
        player = FindFirstObjectByType<LifendPoints>();
        controller = FindFirstObjectByType<PlayerController>();

    }
    void Update()
    {
        lifes.text = "Vidas: " + player.life;
        points.text = "Points: " + player.points;
    }

    public void jogar()
    {
        SceneManager.LoadScene("Game");
        //gOver.SetActive(false);
        Time.timeScale = 1f;

    }

    public void opcoes()
    {
        telaOpcoes.SetActive(true);
    }

    public void sair()
    {
        telaSair.SetActive(true);
        telaOpcoes.SetActive(false);
    }

    public void voltar()
    {
        telaSair.SetActive(false);
        telaOpcoes.SetActive(false);
        controller.OnEnable();
        Time.timeScale = 1;
    }

    public void confirmar()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
    public void GameOver() {
        controller.OnDisable();
        Time.timeScale = 0;
        gOver.SetActive(true);
    }
}