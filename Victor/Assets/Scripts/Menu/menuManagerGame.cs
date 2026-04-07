using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuManagerGame : MonoBehaviour
{
    [HideInInspector] public int vidas = 1;
    public GameObject telaSair;
    public GameObject telaOpcoes;

    public TextMeshProUGUI textoVidas;

    void Start()
    {
        if (textoVidas == null)
        {
            textoVidas = GameObject.Find("vidas").GetComponent<TextMeshProUGUI>();
        }
    }
    void Update()
    {
        textoVidas.text = "Vidas: " + vidas;
    }

    public void jogar()
    {
        SceneManager.LoadScene("Game");
    }

    public void opcoes()
    {
        telaOpcoes.SetActive(true);
    }

    public void sair()
    {
        telaSair.SetActive(true);
    }

    public void voltar()
    {
        telaSair.SetActive(false);
        telaOpcoes.SetActive(false);
    }

    public void confirmar()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}