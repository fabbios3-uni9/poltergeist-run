using UnityEngine;

public class PoltergeistController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do poltergeist

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Entrada do jogador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Movimento do poltergeist
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * moveSpeed;

        // Verifica se o poltergeist saiu da tela e o reposiciona no lado oposto
        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, viewportPosition.y, viewportPosition.z));
        }
        else if (viewportPosition.x > 1)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, viewportPosition.y, viewportPosition.z));
        }

        if (viewportPosition.y < 0)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, 1, viewportPosition.z));
        }
        else if (viewportPosition.y > 1)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewportPosition.x, 0, viewportPosition.z));
        }
    }
}
