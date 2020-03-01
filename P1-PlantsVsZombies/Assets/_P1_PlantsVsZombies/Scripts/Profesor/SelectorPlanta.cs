using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorPlanta : MonoBehaviour
{
  public void PulsaGirasol()
  {
    GameManager.Instance.PlantaSeleccionada = 1;
  }

  public void PulsaLanzaguisantes()
  {
    GameManager.Instance.PlantaSeleccionada = 2;
  }
}
