using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guisante : MonoBehaviour
{
  /// <summary>
  /// Velocidad de avance del guisante
  /// </summary>
  public float Velocidad;

  /// <summary>
  /// Daño inflingido por el guisante
  /// </summary>
  public float Dano;

    void Update()
    {
    transform.position += Time.deltaTime * Velocidad * Vector3.right;
    }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.GetComponent<Zombie>() != null)
    {
      collision.gameObject.GetComponent<Zombie>().RecibirDano(Dano);
      Destroy(gameObject);
    }
  }
}
