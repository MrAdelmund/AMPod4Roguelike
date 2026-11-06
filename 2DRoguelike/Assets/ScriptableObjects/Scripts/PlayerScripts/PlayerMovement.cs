using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 5f;
    private float speedMultiplier = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Coroutine slowCoroutine;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * (baseSpeed * speedMultiplier);
    }
    public void ApplySlowdown(float penalty, float duration)
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
        slowCoroutine = StartCoroutine(SlowTimer(penalty, duration));
    }
    private IEnumerator SlowTimer(float penalty, float duration)
    {
        speedMultiplier = penalty;
        yield return new WaitForSeconds(duration);
        speedMultiplier = 1f;
        slowCoroutine = null;
    }
}
