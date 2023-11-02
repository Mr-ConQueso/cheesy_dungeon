using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SistemaExperiencia : MonoBehaviour
{
    public int nivel = 1;
    public int experienciaActual = 0;
    public int experienciaSiguienteNivel = 100; // Experiencia necesaria para el próximo nivel
    public int vidaBase = 100;
    public int defensaBase = 10;
    public int danioBase = 5;
    public int VidaMaxima = 9999;
    public int DefensaMaxima = 9999;
    public int DanioMaximo = 9999;
    


    private void Start()
    {
        
    }

    public void AumentarExperiencia(int experienciaGanada)
    {
        experienciaActual += experienciaGanada;
        while (experienciaActual >= experienciaSiguienteNivel && nivel < 99)
        {
            SubirNivel();
        }
        
    }

    public void SubirNivel()
    {
        nivel++;
        experienciaSiguienteNivel = CalcularExperienciaSiguienteNivel();
        vidaBase = Mathf.FloorToInt(Mathf.Min(vidaBase * 1.2f, VidaMaxima));
        defensaBase = Mathf.FloorToInt(Mathf.Min(defensaBase * 1.15f, DefensaMaxima));
        danioBase = Mathf.FloorToInt(Mathf.Min(danioBase * 1.2f, DanioMaximo));
    }

    public int CalcularExperienciaSiguienteNivel()
    {
        // Fórmula para calcular la experiencia necesaria para el próximo nivel
        return Mathf.FloorToInt(Mathf.Pow(nivel + 1, 3) * 100);
    }

    


}
