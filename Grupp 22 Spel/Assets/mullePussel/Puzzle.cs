using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public int rows = 3; // Number of rows
    public int columns = 3; // Number of columns
    public GameObject tilePrefab; // Your UI prefab
    public Transform tilesParent; // Assign this to your UI Panel (TilesPanel)
    public Sprite spriteX;
    public Sprite spriteO;

    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[columns, rows];
        ClearTilesPanel(); // Clear any existing tiles
        GenerateCustomGrid();
    }

    // Clear all child GameObjects in the tilesParent panel
    void ClearTilesPanel()
    {
        foreach (Transform child in tilesParent)
        {
            Destroy(child.gameObject);
        }
    }

    void GenerateCustomGrid()
    {
        float cellWidth = 100f; // Adjust as needed
        float cellHeight = 100f; // Adjust as needed
        float spacing = 150f; // Adjust spacing as needed
        Vector2 startPosition = new Vector2(
            -(columns - 1) * (cellWidth + spacing) / 2,
            -(rows - 1) * (cellHeight + spacing) / 2
        );

        // Calculate the center tile coordinates
        int centerX = columns / 2;
        int centerY = rows / 2;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                // Skip the center tile (middle of the grid)
                if (x == centerX && y == centerY) continue;

                // Instantiate the tile prefab and set it as a child of the tilesParent
                GameObject tile = Instantiate(tilePrefab, tilesParent);
                tile.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    startPosition.x + x * (cellWidth + spacing),
                    startPosition.y + y * (cellHeight + spacing)
                );

                // Set the default sprite for the tile
                Image tileImage = tile.GetComponent<Image>();
                tileImage.sprite = spriteX;

                // Add the click event listener to toggle the tile's sprite
                Button tileButton = tile.GetComponent<Button>();
                int capturedX = x, capturedY = y; // Capture indices for the closure
                tileButton.onClick.AddListener(() => ToggleTile(capturedX, capturedY));

                grid[x, y] = tile;
            }
        }
    }

    void ToggleTile(int x, int y)
    {
        if (grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
        }
        ToggleAdjacent(x - 1, y); // Left
        ToggleAdjacent(x + 1, y); // Right
        ToggleAdjacent(x, y - 1); // Below
        ToggleAdjacent(x, y + 1); // Above
    }
    void ToggleAdjacent(int x, int y)
    {
        if (x >= 0 && x < columns && y >= 0 && y < rows && grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
        }
    }
}