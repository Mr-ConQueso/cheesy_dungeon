using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumarExperiencia : MonoBehaviour
{
  
    public int experienciaGanada = 350;
    public SistemaExperiencia sistemaExperiencia;

    private void OnMouseDown()
    {
        sistemaExperiencia.AumentarExperiencia(experienciaGanada);
       

    }

   
}
