using UnityEngine;
using UnityEngine.Tilemaps;

public class V2PlayerControl : MonoBehaviour
{
    // Public variables
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public bool slippery = false;

    public Tilemap Ground;

    // Assign your actual Tile Assets (.asset) from your Project window here
    public TileBase normalTile;
    public TileBase iceTile;

    [Range(0.01f, 1f)] public float normalTraction = 1f;
    [Range(0.001f, 1f)] public float slipperyTraction = 0.05f;
    public float currentTraction;
    public float moveSpeed = 5f;

    // Private variables
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Vector2 targetVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        // Example trigger: Press T to swap tiles back and forth
        if (Input.GetKeyDown(KeyCode.T))
        {
            slippery = !slippery;

            if (slippery)
            {
                SwapTilemapTiles(normalTile, iceTile);
            }
            else
            {
                SwapTilemapTiles(iceTile, normalTile);
            }
        }
    }

    /// <summary>
    /// Loops through the entire used area of the Ground tilemap and replaces one tile type with another.
    /// </summary>
    void SwapTilemapTiles(TileBase fromTile, TileBase toTile)
    {
        // Get the active bounding box of the tilemap
        BoundsInt bounds = Ground.cellBounds;

        // Grab all tiles in the bounds at once for performance
        TileBase[] allTiles = Ground.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                int index = x + y * bounds.size.x;
                TileBase tile = allTiles[index];

                if (tile == fromTile)
                {
                    // Calculate actual grid position
                    Vector3Int localPlace = new Vector3Int(
                        x + bounds.position.x,
                        y + bounds.position.y,
                        bounds.position.z
                    );

                    // Replace the tile
                    Ground.SetTile(localPlace, toTile);
                }
            }
        }
    }
}