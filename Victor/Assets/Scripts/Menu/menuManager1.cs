using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager1 : MonoBehaviour
{
    public GameObject telaSair;
    public GameObject telaOpcoes;
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
