using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeZombies : MonoBehaviour
{
  public float TiempoGeneracionZombies;

  /// <summary>
  /// Almacena los puntos donde se puede generar un zombie. Se podría rellenar automáticamente
  /// </summary>
  public List<Transform> ListaGeneradores;

  /// <summary>
  /// Prefab de Zombie
  /// </summary>
  public GameObject PrefabZombie;

  public IEnumerator Start()
  {
    while (true)
    {
      yield return new WaitForSeconds(TiempoGeneracionZombies);
      InstanciarZombie(ListaGeneradores[Random.Range(0, ListaGeneradores.Count)]);
    }
  }

  private void InstanciarZombie(Transform t)
  {
    Instantiate(PrefabZombie, t);
  }
}
