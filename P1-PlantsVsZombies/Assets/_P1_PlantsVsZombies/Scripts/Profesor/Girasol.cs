using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girasol : MonoBehaviour
{
  /// <summary>
  /// Tiempo tras el cual genera un sol
  /// </summary>
  public int TiempoGeneracionSol;

  /// <summary>
  /// Tiempo tras el cual un sol que se ha generado se destruye
  /// </summary>
  public int TiempoVidaSol;

  /// <summary>
  /// Prefab que almacena el sol
  /// </summary>
  public GameObject PrefabSol;

  public IEnumerator Start()
  {
    while (true)
    {
      // Se espera un tiempo cada vez que se genera el sol
      yield return new WaitForSeconds(TiempoGeneracionSol);
      // Se instancia un nuevo sol alrededor del girasol, añadiendo distancias aleatorias para situarlo
      GameObject GOSol = Instantiate(PrefabSol, transform.position + Vector3.up * Random.Range(0,1) + Vector3.left*Random.Range(-1,1) + Vector3.forward * -0.1f, PrefabSol.transform.rotation);
      // Se envía la orden de que este sol se destruya pasado un tiempo
      Destroy(GOSol, TiempoVidaSol);
    }
  }


}
