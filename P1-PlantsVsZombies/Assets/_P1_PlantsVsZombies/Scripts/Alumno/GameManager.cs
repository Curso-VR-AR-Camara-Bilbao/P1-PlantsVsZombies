using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  //Vamos a definir un singleton. Esto no hace falta aprenderlo de memoria sino saber que está aquí y poderlo copiar
  public static GameManager Instance = null;

  /// <summary>
  /// Numero de soles que tiene el jugador
  /// </summary>
  public int NumSoles;

  /// <summary>
  /// Referencia al texto que indica el número de soles
  /// </summary>
  public Text txtSoles;

  /// <summary>
  /// Indica qué planta ha sido seleccionada en la UI
  /// </summary>
  public int PlantaSeleccionada;

  /// <summary>
  /// Prefab del girasol
  /// </summary>
  public GameObject PrefabGirasol;

  /// <summary>
  /// Prefab del Lanzaguisantes
  /// </summary>
  public GameObject PrefabLanzaguisantes;


  //Esta función se ejecuta al comienzo del todo
  private void Awake()
  {
    /////// SINGLETON /////////
    /// Copiar esto
    // Comprueba si existe una instancia de GameManager
    if(Instance == null)
    {
      Instance = this; //Si no existe la asignamos a esta
    } else if (Instance != this) //Si ya hay una destruye esta
    {
      Destroy(gameObject);
    }
    ////////////////////////////
  }

  //Esta función se ejecuta al comienzo del juego (cuando todo está cargado)
  void Start()
  {
    Debug.Log("Comienza el juego");
    ActualizarSoles(0);
  }

  //Esta función se ejecuta cada fotograma
  void Update()
  {
    if (Input.GetMouseButtonDown(0)) //Se comprueba si se ha pulsado el botón izquierdo del ratón
    {
      Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition); //Se crea un rayo desde el punto donde se ha pulsado
      RaycastHit2D Impacto = Physics2D.Raycast(Rayo.origin, Rayo.direction); //Se comprueba si ha chocado con collider de la capa Cuadrícula
      if (Impacto.collider != null)
      {
        if(Impacto.collider.gameObject.layer == LayerMask.NameToLayer("Cuadricula"))
        {
          Transform t = Impacto.collider.transform;
          if (t.childCount == 0) //Si la casilla está vacía
          {
            CrearPlanta(t);
          } 
        }
        else if (Impacto.collider.gameObject.layer == LayerMask.NameToLayer("Sol"))
        {
          //Se accede al componente Sol del Sol y se ejecuta la función UtilizarSol
          Impacto.collider.gameObject.GetComponent<Sol>().UtilizarSol();
        }

      }
    }
  }

  /// <summary>
  /// Actualiza la variable NumSoles y lo muestra en el cuadro de texto
  /// </summary>
  /// <param name="Incremento"></param>
  public void ActualizarSoles(int Incremento)
  {
    NumSoles += Incremento; //Incrementamos el valor de la variable
    txtSoles.text = NumSoles.ToString(); //Hacemos que en el cuadro de texto se muestre el valor de la variable
  }

  /// <summary>
  /// Crea una planta, girasol o lanzaguisantes, dependiendo de la opción seleccionada en la posición que indica el transform pasado como argumento
  /// </summary>
  /// <param name="t"></param>
  public void CrearPlanta(Transform t)
  {
    // Se inicializa el GameObject que almacenará a la planta
    GameObject GOPlanta = null;
    switch (PlantaSeleccionada)
    {
      case 1: //Caso del girasol
        if (NumSoles >= 50) //Se comprueba que se tienen suficientes soles
        {
          GOPlanta = Instantiate(PrefabGirasol, t); //Si se tienen, se crea una planta en la casilla
          GOPlanta.transform.position = t.position; //Se hace que la posición de la planta coincida con el centro de la casilla. Recordar comentar el problema del offset de un collider
          ActualizarSoles(-50); //Después se actualizan los soles

          if (GetComponent<AudioSource>() != null)
          {
            GetComponent<AudioSource>().Play();
          }
        }
        break;

      case 2: //Caso del lanzaguisantes
        if (NumSoles >= 100)
        {
          GOPlanta = Instantiate(PrefabLanzaguisantes, t);
          GOPlanta.transform.position = t.position;
          ActualizarSoles(-100);

          if (GetComponent<AudioSource>() != null)
          {
            GetComponent<AudioSource>().Play();
          }
        }
        break;
    }
  }
}
