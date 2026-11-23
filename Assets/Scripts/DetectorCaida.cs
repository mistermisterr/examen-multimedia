using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorCaida : MonoBehaviour
{
    public GameObject mensajeCaida;

    private bool jugadorCaido = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCaido = true;

            if (mensajeCaida != null)
            {
                mensajeCaida.SetActive(true);
            }

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }

            MovimientoJugador movimiento =
                collision.GetComponent<MovimientoJugador>();

            if (movimiento != null)
            {
                movimiento.enabled = false;
            }
        }
    }

    void Update()
    {
        if (jugadorCaido && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}