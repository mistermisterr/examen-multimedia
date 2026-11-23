using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private bool enSuelo = false;
    private float movimientoHorizontal = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mover hacia la derecha con A
        if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = 1f;
        }
        // Mover hacia atras con Flecha Arriba
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movimientoHorizontal = -1f;
        }
        else
        {
            movimientoHorizontal = 0f;
        }

        // Saltar con V
        if (Input.GetKeyDown(KeyCode.V) && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            enSuelo = false;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            movimientoHorizontal * velocidad,
            rb.linearVelocity.y
        );
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Comprobar si el jugador esta tocando el suelo
        foreach (ContactPoint2D contacto in collision.contacts)
        {
            if (contacto.normal.y > 0.5f)
            {
                enSuelo = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enSuelo = false;
    }
}