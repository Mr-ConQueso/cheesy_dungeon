using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaTienda : MonoBehaviour
{


    public GameObject tiendaPanel;
    public Text mensajeTexto;
    public SistemaEconomia sistemaEconomia;
    private GameManager gameManager;
    private string mensajeOriginal;
    private bool isShopActive = false;

    private void Start()
    {
        tiendaPanel.SetActive(false);
        mensajeOriginal = mensajeTexto.text;

        gameManager = GetComponent<GameManager>();
    }

    /*private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            MostrarTienda();
        }
    }*/

    /*public void MostrarTienda()
    {
        tiendaPanel.SetActive(true);
        mensajeTexto.text = "Bienvenido a la tienda. �Qu� te gustar�a comprar?\n" +
                            "Elixir (7 gemas)\n" +
                            "Poci�n (59 oro)\n" +
                            "�ter (70 oro)\n" +
                            "Salir de la tienda.";
    }
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isShopActive = !isShopActive;
        }
        ToggleShop();
    }

    private void ToggleShop()
    {
        if (isShopActive) {
            tiendaPanel.SetActive(true);
            MostrarInformacionTienda();
        } else {
            tiendaPanel.SetActive(false);
            RestaurarMensajeOriginal();
        }
        
        
    }

    public void ComprarElixir()
    {
        if (sistemaEconomia.gemas >= 7)
        {
            sistemaEconomia.gemas -= 7;
            mensajeTexto.text = "Has comprado un Elixir! Gracias por tu compra.";
            Invoke("OcultarMensaje", 2f);

            gameManager.ApplyShopItem(new ItemData("Elixir", 20, 50, 0, 0, 0, -10));
        }
        else
        {
            mensajeTexto.text = "No tienes suficientes gemas para comprar el Elixir.";
            Invoke("OcultarMensaje", 2f);
        }
    }

    public void ComprarPocion()
    {
        int precioPocion = 59;

        if (sistemaEconomia.oro >= precioPocion) 
        {
            sistemaEconomia.oro -= precioPocion;
            mensajeTexto.text = "Has comprado una Poción! Gracias por tu compra.";
            Invoke("OcultarMensaje", 2f);

            gameManager.ApplyShopItem(new ItemData("Pocima", 10, 0, 0, 0, 0, -5));
        }
        else if (sistemaEconomia.gemas >= 1)
        {
            sistemaEconomia.gemas -= 1;
            int cambio = 41;
            sistemaEconomia.oro += cambio;
            mensajeTexto.text = $"Has comprado una Poción usando una gema! Te hemos devuelto {cambio} de oro. Gracias por tu compra.";
            Invoke("OcultarMensaje", 2);

            if (sistemaEconomia.oro >= 100)
            {
                int conversionGemas = sistemaEconomia.oro / 100;
                sistemaEconomia.gemas += conversionGemas;
                sistemaEconomia.oro %= 100;
            }

            gameManager.ApplyShopItem(new ItemData("Pocima", 10, 0, 0, 0, 0, -5));
        }
        else
        {
            mensajeTexto.text = "No tienes suficientes recursos para comprar la Poción.";
            Invoke("OcultarMensaje", 2f);
        }
    }

    public void ComprarEter()
    {
        int precioEter = 70;
        if (sistemaEconomia.oro >= precioEter)
        {
            sistemaEconomia.oro -= precioEter;
            mensajeTexto.text = "Has comprado una Eter! Gracias por tu compra.";
            Invoke("OcultarMensaje", 2f);

            gameManager.ApplyShopItem(new ItemData("Mana", 0, 15, 0, 0, 0, -5));
        }
        else if (sistemaEconomia.gemas >= 1)
        {
            sistemaEconomia.gemas -= 1;
            int cambio = 30;
            sistemaEconomia.oro += cambio;
            mensajeTexto.text = $"Has comprado un Eter usando una gema! Te hemos devuelto {cambio} de oro. Gracias por tu compra.";
            Invoke("OcultarMensaje", 2f);

            if (sistemaEconomia.oro >= 100)
            {
                int conversionGemas = sistemaEconomia.oro / 100;
                sistemaEconomia.gemas += conversionGemas;
                sistemaEconomia.oro %= 100;
            }

            gameManager.ApplyShopItem(new ItemData("Mana", 0, 15, 0, 0, 0, -5));
        }
        else
        {
            mensajeTexto.text = "No tienes suficientes recursos para comprar Eter.";
            Invoke("OcultarMensaje", 2f);
        }
    }

    public void SalirDeLaTienda()
    {
        isShopActive = false;
    }

    private void RestaurarMensajeOriginal()
    {
        mensajeTexto.text = mensajeOriginal;
    }
    private void OcultarMensaje()
    {
        mensajeTexto.text = "";
        Invoke("MostrarInformacionTienda", 0.1f);
    }
    private void MostrarInformacionTienda()
    {
        mensajeTexto.text = "Bienvenido a la tienda. Qué te gustaría comprar?\n" +
                            "Elixir (7 gemas)\n" +
                            "Poción (59 de oro)\n" +
                            "éter (70 de oro)\n" +
                            " \n" +
                            " \n" +
                            "Dinero en la cartera:\n" +
                            $"Tienes {sistemaEconomia.gemas} gemas\n" +
                            $"Tienes {sistemaEconomia.oro} de oro\n" +
                            $"Tienes {sistemaEconomia.plata} de plata.";
    }
}
