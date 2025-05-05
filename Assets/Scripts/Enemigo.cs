using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);

    }

    IEnumerator SpawnearEnemigos()
    {

        //Bucle infinito, si se pueden usar dentro de de una Coroutine
        //Para que no pare de disparar.
        while (true)
        {
            Instantiate(disparoPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    //Solucionado que se destruia el player aunque tenía vida
    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoPlayer"))
        {
            Destroy(elOtro.gameObject);
            Destroy(this.gameObject);
            //Mando al GameManager que ha matado un enemigo para que lo sume al Score
            FindAnyObjectByType<GameManager>().SumarPuntos(1);

        }
        else if (elOtro.gameObject.CompareTag("Player"))
        {
            // Solo se destruye el enemigo, el jugador gestiona su vida
            Destroy(this.gameObject);
        }
    }
}
