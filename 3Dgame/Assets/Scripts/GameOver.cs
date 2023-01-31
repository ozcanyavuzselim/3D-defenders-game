using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Animator anim;
    public PlayerHealth playerHealth;
    public GameObject restart, mainmenu, quit;
    public Timer timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (playerHealth.mevcutcan <= 0)
        {
            
            anim.SetTrigger("GameOver");

            restart.SetActive(true);
            mainmenu.SetActive(true);
            quit.SetActive(true);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quýt()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
