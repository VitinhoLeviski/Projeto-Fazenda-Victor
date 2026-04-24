using UnityEngine;

public class LifendPoints : MonoBehaviour
{
    menuManagerGame menu;
    [HideInInspector] public int points = 0;
    [HideInInspector] public int life = 3;
    private int actualScore = 0;
    [HideInInspector] public bool gameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu = FindFirstObjectByType<menuManagerGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plusPoints() {
        points++;
        actualScore++;
        if(actualScore/15 > 0) {
            actualScore = actualScore - 15;
            life++;
        }
    }

    public void takeDamage() {
        life--;
        if (life <= 0) {
            menu.GameOver();
        }
    }
}
