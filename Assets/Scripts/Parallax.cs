using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion;
    [SerializeField] private float anchoImagen  ;

    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float espacio = velocidad * Time.time;//nos ahorramos esta linea inclullendola abajo
     // Resto: Cuando me queda de recorrido para alcanzar un nuevo ciclo
        float resto = (velocidad * Time.time) % anchoImagen;
        //Mientras resto no sea 0 la posición cambia, cuando es multiplo y por tanto resto es cero se vuelve a posicion inicial.
        //Mi posición se va refrescando desde la inicial SUMANDO tanto como resto me quede
        //en la dirección deseada.
        transform.position = posicionInicial + resto * direccion;
    }
}
