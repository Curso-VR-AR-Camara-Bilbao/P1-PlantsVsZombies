using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
  /// <summary>
  /// Velocidad de movimiento del Zombie
  /// </summary>
  public float Velocidad;

  /// <summary>
  /// Vida de un zombie
  /// </summary>
  public float Vida;
 
  // Update is called once per frame
  void Update()
  {
    Avanzar();
  }

  public void Avanzar()
  {
    transform.position += Time.deltaTime * Velocidad * Vector3.left;
  }

  /// <summary>
  /// Reduce el nivel de vida
  /// </summary>
  /// <param name="Dano"></param>
  public void RecibirDano(float Dano)
  {
    Vida -= Dano;
    if (Vida <= 0)
    {
      Morir();
    }
  }

  public void Morir()
  {
    Destroy(gameObject);
  }

  /// <summary>
  /// Esta función se ejecuta cuando el collider del objeto colisiona con otro (en modo Trigger)
  /// </summary>
  /// <param name="collision"></param>
  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Se comprueba que el objecto con el que se ha chocado es del tipo especificado
    if((collision.gameObject.GetComponent<Lanzaguisantes>()!=null) || (collision.gameObject.GetComponent<Girasol>()!=null))
    {
      Debug.Log("Colision detectada con "+ collision.gameObject.name);
      Destroy(collision.gameObject);
    }
  }

  private bool ContainsComponent<T>(GameObject GO)
  {
    return (GO.GetComponent<T>() != null);
  }
}
