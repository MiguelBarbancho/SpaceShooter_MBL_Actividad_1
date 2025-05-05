using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject SpawnPoint1;
    [SerializeField] private GameObject SpawnPoint2;
    private float temporizador = 0.5f;
    private float vidas = 100;
    [SerializeField] private TextMeshProUGUI textoVidas;// es necesario agregra TMPro


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DelimitarMovimiento();
        Disparar();
        
    }

    void Movimiento()
    {
        //Movimiento de la nave
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(inputH, inputV).normalized * velocidad * Time.deltaTime);
    }

    void DelimitarMovimiento()
    {
        //delimitar movimieto de la nave
        float xClamped = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamped = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xClamped, yClamped, 0);
    }

    void Disparar()
    {

        temporizador += 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && temporizador > ratioDisparo)
        {
            Debug.Log("Disparo");
            Instantiate(disparoPrefab, SpawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, SpawnPoint2.transform.position, Quaternion.identity);
            temporizador = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DisparoEnemigo") || elOtro.gameObject.CompareTag("Enemigo"))
        {
            vidas -= 20;
            Destroy(elOtro.gameObject);
            textoVidas.text = "Vidas: " + vidas;
            if (vidas <= 0)
            {
                Destroy(this.gameObject);
                
                FindObjectOfType<GameManager>().FinJuego();//Nuevo TEST

            }
        }
    }



}
