using System.Collections;
using System.Collections.Generic;
using TMPro;// No se agrega automático
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private TextMeshProUGUI textoOleadas;// es necesario agregra TMPro
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearEnemigos());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnearEnemigos()
    {
        for (int nivel = 0; nivel < 5; nivel++) // Niveles
        {
            Debug.Log("Nivel: " + (nivel + 1));

            for (int oleada = 0; oleada < 3; oleada++) // Oleadas
            {
                Debug.Log("  Oleada: " + (oleada + 1));
                textoOleadas.text = "Nivel " + (nivel + 1) + "-" + " Oleada " + (oleada +1);
                yield return new WaitForSeconds(2f);//Tiempo que está escrito el nivel en pantalla
                textoOleadas.text = "";
                for (int enemigo = 0; enemigo < 10; enemigo++) // Enemigos
                {
                    Debug.Log("    Enemigo: " + (enemigo + 1));
                    Vector3 puntoAleatorio = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), 0);
                    Instantiate(enemigoPrefab, puntoAleatorio, Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                }

                yield return new WaitForSeconds(2f); // Espera después de cada oleada
            }

            yield return new WaitForSeconds(3f); // Espera después de cada nivel
        }
    }


}
