using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunu duraklatmak ve menüyü açmak/kapatmak için kullanýlan sýnýfý
public class PauseMenu : MonoBehaviour
{
    private bool gamePouse = false;// Oyunun duraklatýlýp duraklatýlmadýðýný tutan deðiþken

    public GameObject pauseMenu;// Duraklatma menüsünün objesi

    // Her frame güncellenir
    private void Update()
    {
        // Esc tuþu basýldýðýnda
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePouse = !gamePouse;
        }

        // Oyun duraklatýlmýþsa
        if (gamePouse)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        // Oyun duraklatýlmamýþsa
        if (!gamePouse)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    // Oyunu devam ettirmek için kullanýlan fonksiyon
    public void ResumeGame()
    {
        gamePouse = false;
    }

    // Oyunu kapatmak için kullanýlan fonksiyon
    public void Quit()
    {
        Application.Quit();
    }

    // Ana menüye dönmek için kullanýlan fonksiyon
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
