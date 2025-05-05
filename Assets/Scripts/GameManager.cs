using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pantallaInicio;
    [SerializeField] private GameObject pantallaGameOver;

    private float score = 0;
    [SerializeField] private TextMeshProUGUI textoScore;// es necesario agregra TMPro

    public bool juegoIniciado = false;

    void Start()
    {
        Time.timeScale = 0f;
        pantallaInicio.SetActive(true);
        pantallaGameOver.SetActive(false);
    }

    public void IniciarJuego()
    {
        Time.timeScale = 1f;
        pantallaInicio.SetActive(false);
        juegoIniciado = true;
    }

    public void FinJuego()
    {
        Time.timeScale = 0f;
        pantallaGameOver.SetActive(true);
    }

    public void VolverAJugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SumarPuntos(int cantidad)
    {
        score += cantidad;
        textoScore.text = "Puntos: " + score;

    }
}