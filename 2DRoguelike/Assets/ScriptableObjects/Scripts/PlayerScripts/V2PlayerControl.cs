using UnityEngine;
using UnityEngine.Tilemaps;

public class V2PlayerControl : MonoBehaviour
{
    // Public variables
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public bool slippery = false;
    public Tilemap Ground;

    [Range(0.01f, 1f)] public float normalTraction = 1f;
    [Range(0.001f, 1f)] public float slipperyTraction = 0.05f;
    public float currentTraction;
    public float moveSpeed = 5f; // Added speed variable

    // Private variables
    private Rigidbody2D rb;
    // private PlayerStats stats; // Uncomment if you have a PlayerStats script
    private Vector2 movementInput;
    private Vector2 targetVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // stats = GetComponent<PlayerStats>(); // Uncomment if you have a PlayerStats script
    }

    void Update()
    {
        // Standard movement input
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput = movementInput.normalized;
    }

    void FixedUpdate()
    {
        // 1. Check the tile beneath the player
        Vector3Int cellposition = Ground.WorldToCell(rb.position);
        TileBase currenttile = Ground.GetTile(cellposition);

        // 2. Set traction based on tile name
        if (currenttile != null && currenttile.name == "ice Tile")
        {
            currentTraction = slipperyTraction;
            slippery = true;
        }
        else
        {
            currentTraction = normalTraction;
            slippery = false;
        }

        // 3. Calculate target velocity based on input
        targetVelocity = movementInput * moveSpeed;

        // 4. Apply physics and traction using Vector2.Lerp (gives the sliding ice effect)
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, currentTraction);

        // 5. Clamp player position within your bounds (optional, since you declared bounds variables)
        float clampedX = Mathf.Clamp(rb.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(rb.position.y, minBounds.y, maxBounds.y);
        rb.position = new Vector2(clampedX, clampedY);
    }
}