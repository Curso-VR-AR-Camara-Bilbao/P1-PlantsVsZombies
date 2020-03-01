using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour
{
  /// <summary>
  /// Valor en soles de cada sol capturado
  /// </summary>
  public int ValorSol;

  private void Start()
  {
    if (GetComponent<AudioSource>() != null)
    {
      GetComponent<AudioSource>().Play();
    }
  }

  /// <summary>
  /// Se aumenta el numero de soles en el valor indicado y se destruye el objeto
  /// </summary>
  public void UtilizarSol()
  {
    GameManager.Instance.ActualizarSoles(ValorSol);
    Destroy(gameObject);
  }
}
