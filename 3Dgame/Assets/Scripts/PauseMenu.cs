using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Oyunu duraklatmak ve men�y� a�mak/kapatmak i�in kullan�lan s�n�f�
public class PauseMenu : MonoBehaviour
{
    private bool gamePouse = false;// Oyunun duraklat�l�p duraklat�lmad���n� tutan de�i�ken

    public GameObject pauseMenu;// Duraklatma men�s�n�n objesi

    // Her frame g�ncellenir
    private void Update()
    {
        // Esc tu�u bas�ld���nda
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePouse = !gamePouse;
        }

        // Oyun duraklat�lm��sa
        if (gamePouse)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        // Oyun duraklat�lmam��sa
        if (!gamePouse)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    // Oyunu devam ettirmek i�in kullan�lan fonksiyon
    public void ResumeGame()
    {
        gamePouse = false;
    }

    // Oyunu kapatmak i�in kullan�lan fonksiyon
    public void Quit()
    {
        Application.Quit();
    }

    // Ana men�ye d�nmek i�in kullan�lan fonksiyon
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
