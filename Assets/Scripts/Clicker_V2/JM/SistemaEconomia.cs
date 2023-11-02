using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SistemaEconomia : MonoBehaviour
{

    public int oro;
    public int plata;
    public int gemas;

    public int cantidadOroObtenida;
    public int cantidadPlataObtenida;
    public int cantidadGemasObtenidas;

    private void Start()
    {
        // Inicializa las variables
        oro = 0;
        plata = 0;
        gemas = 0;

        cantidadOroObtenida = 0;
        cantidadPlataObtenida = 0;
        cantidadGemasObtenidas = 0;
    }

    private void OnMouseDown()
    {

        int randomNum = Random.Range(1, 101);
        cantidadOroObtenida = 0;
        cantidadPlataObtenida = 0;
        cantidadGemasObtenidas = 0;

        if (randomNum <= 40)
        {
            cantidadOroObtenida = Random.Range(1, 16);
            oro += cantidadOroObtenida;
        }
        else if (randomNum <= 90)
        {
            cantidadPlataObtenida = Random.Range(1, 50);
            plata += cantidadPlataObtenida;
        }
        else
        {
            cantidadGemasObtenidas = Random.Range(1, 2);
            gemas += cantidadGemasObtenidas;
        }

        // Muestra los resultados en la consola
        Debug.Log($"Oro obtenido: {cantidadOroObtenida}, oro actual: {oro}");
        Debug.Log($"Plata obtenida: {cantidadPlataObtenida}, plata actual: {plata}");
        Debug.Log($"Gemas obtenidas: {cantidadGemasObtenidas}, gemas actuales: {gemas}");


    }



}
