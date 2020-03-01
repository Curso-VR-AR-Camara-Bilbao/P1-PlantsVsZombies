using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilidades
{
  /// <summary>
  /// Indica si una capa se encuentra en la máscara
  /// </summary>
  /// <returns></returns>
  public static bool IsCapaEnMascara(int Capa, LayerMask MascaraDeCapa)
  {
    return MascaraDeCapa == (MascaraDeCapa | (1 << Capa));
  }

  public static void SalirDelJuego()
  {
    Application.Quit();
  }
}
