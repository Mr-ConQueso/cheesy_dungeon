using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarTexto : MonoBehaviour
{
    public SistemaExperiencia sistemaExperiencia;
    public Text texto;

    void Update()
    {
        // Actualiza el objeto de texto con la información del sistema de experiencia
        texto.text = $"Nivel: {sistemaExperiencia.nivel}\n" +
            $"Experiencia: {sistemaExperiencia.experienciaActual}/{sistemaExperiencia.experienciaSiguienteNivel}\n" +
            $"Vida: {sistemaExperiencia.vidaBase}\n" +
            $"Defensa: {sistemaExperiencia.defensaBase}\n" +
            $"Daño: {sistemaExperiencia.danioBase}";
    }
}
