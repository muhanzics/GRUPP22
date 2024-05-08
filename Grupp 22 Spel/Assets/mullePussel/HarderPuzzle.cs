using UnityEngine;
using UnityEngine.UI;

public class HarderPuzzle : MonoBehaviour
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
        GenerateCustomGrid();
    }
    void GenerateCustomGrid()
    {
        float cellWidth = 120f; // Adjust as needed
        float cellHeight = 120f; // Adjust as needed
        float spacing = 150f; // Adjust spacing as needed

        // Calculate the starting position based on the grid size
        Vector2 startPosition = new Vector2(
            -(columns - 1) * (cellWidth + spacing) / 2,
            -(rows - 1) * (cellHeight + spacing) / 2
        );

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject tile = Instantiate(tilePrefab, tilesParent);
                tile.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    startPosition.x + x * (cellWidth + spacing),
                    startPosition.y + y * (cellHeight + spacing)
                );

                // Set the default sprite for all tiles
                Image tileImage = tile.GetComponent<Image>();
                tileImage.sprite = spriteX;

                // Add the click event listener to toggle the tile's sprite
                Button tileButton = tile.GetComponent<Button>();
                int capturedX = x, capturedY = y; // Capture indices for the closure
                tileButton.onClick.AddListener(() => ToggleTile(capturedX, capturedY));

                grid[x, y] = tile;
            }
        }
        SetHardestInitialState();
    }

    void ToggleTile(int x, int y)
    {
        // Toggle the clicked tile
        if (grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
        }

        // Toggle adjacent tiles horizontally and vertically only
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
    void SetHardestInitialState()
    {
        // Set all tiles to X by default
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                grid[x, y].GetComponent<Image>().sprite = spriteX;
            }
        }

        // Manually set the hardest initial state
        grid[0, 0].GetComponent<Image>().sprite = spriteX;
        grid[0, 1].GetComponent<Image>().sprite = spriteO;
        grid[0, 2].GetComponent<Image>().sprite = spriteX;

        grid[1, 0].GetComponent<Image>().sprite = spriteO;
        grid[1, 1].GetComponent<Image>().sprite = spriteO; // Middle tile as O
        grid[1, 2].GetComponent<Image>().sprite = spriteO;

        grid[2, 0].GetComponent<Image>().sprite = spriteX;
        grid[2, 1].GetComponent<Image>().sprite = spriteO;
        grid[2, 2].GetComponent<Image>().sprite = spriteX;
    }
}
