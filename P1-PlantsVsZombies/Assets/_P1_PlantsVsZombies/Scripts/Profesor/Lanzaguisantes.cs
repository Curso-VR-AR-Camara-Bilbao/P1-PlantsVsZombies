using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzaguisantes : MonoBehaviour
{
  /// <summary>
  /// Prefab de un guisante
  /// </summary>
  public GameObject PrefabGuisante;

  /// <summary>
  /// Posición de la que salen los guisantes
  /// </summary>
  public Transform SalidaGuisantes;

  /// <summary>
  /// Capa o capas donde atacar
  /// </summary>
  public LayerMask CapaZombies;

  /// <summary>
  /// Tiempo tras el cual dispara el lanzaguisantes
  /// </summary>
  public float CadenciaDisparo;

  public void LanzarGuisante()
  {
    Instantiate(PrefabGuisante, SalidaGuisantes);
    if (GetComponent<AudioSource>() != null)
    {
      GetComponent<AudioSource>().Play();
    }
  }

  private IEnumerator Start()
  {
    while (true)
    {
      yield return new WaitForSeconds(CadenciaDisparo);

      RaycastHit2D Impacto = Physics2D.Raycast(SalidaGuisantes.position, Vector3.right, 20f, CapaZombies);
      Debug.DrawLine(SalidaGuisantes.position, SalidaGuisantes.position + Vector3.right * 20f);
      if (Impacto.collider != null)
      {
        LanzarGuisante();
      }
    }
  }
}
