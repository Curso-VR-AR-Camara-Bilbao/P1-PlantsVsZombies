using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
  public LayerMask CapasADestruir;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(Utilidades.IsCapaEnMascara(collision.gameObject.layer, CapasADestruir))
    {
      Destroy(collision.gameObject);
    }
  }
}
