using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Sprite imageSoundOff;
    public Sprite imageActiveSound;
    public Button button;
    public bool isActive;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject victoryScreen;
    public GameObject looseScreen;


    public AudioListener audio;


    // Start is called before the first frame update
    void Start()
    {
        isActive = false;

        button = GetComponent<Button>();

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSound()
    {
        isActive = !isActive;

        if (isActive)
        {
            button.image.sprite = imageSoundOff;
            audio.enabled = false;
            print("muted");
        }
        else
        {
            button.image.sprite = imageActiveSound;
            audio.enabled = true;
            print("sound");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Cerrando juego");
    }

    public void Opciones()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        victoryScreen.SetActive(false);
        looseScreen.SetActive(false);
    }

    public void Volver()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

}
