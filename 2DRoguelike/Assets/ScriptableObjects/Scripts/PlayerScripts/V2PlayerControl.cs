using UnityEngine;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(Rigidbody2D))]
public class V2PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStats stats;

    [Header("Movement Bounds")]
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public bool slippery = false;
    public Tilemap Ground;
    [Range(0.01f, 1f)] public float normalTraction = 1f;
    [Range(0.001f, 1f)] public float slipperyTraction = 0.05f;
    public float currentTraction;
    private Vector2 movementInput;
    private Vector2 targetVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        // standard movment
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput = movementInput.normalized;
    }

    void FixedUpdate()

    {
        Vector3Int cellposition = Ground.WorldToCell(rb.position);
        TileBase currenttile = Ground.GetTile(cellposition);
        //checks for slippery tiles
        if (currenttile != null && currenttile.name == "ice Tile")
        {
            currentTraction = slipperyTraction;
        }
        else
        {
            currentTraction = normalTraction;
        }
        Vector2 targetPosition = rb.position + movementInput * stats.moveSpeed * Time.fixedDeltaTime;
        rb.velocity = Vector2.MoveTowards(rb.velocity, targetVelocity, currentTraction * Time.fixedDeltaTime);
        // the camera boundries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);
        //ice physics
        //rb.position = new Vector2(clampedX, clampedY);
    }
}