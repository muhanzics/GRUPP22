using UnityEngine;
using UnityEngine.UI;

public class RandomizePuzzle : MonoBehaviour
{
    public int rows = 3; 
    public int columns = 3; 
    public GameObject tilePrefab; 
    public Transform tilesParent; 
    public Sprite spriteX;
    public Sprite spriteO;

    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[columns, rows];
        GenerateCustomGrid();
        RandomizeInitialState(10); 
    }

    void GenerateCustomGrid()
    {
        float cellWidth = 120f; 
        float cellHeight = 120f; 
        float spacing = 150f; 

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

                Image tileImage = tile.GetComponent<Image>();
                tileImage.sprite = spriteX; 

                Button tileButton = tile.GetComponent<Button>();
                int capturedX = x, capturedY = y; 
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

        ToggleAdjacent(x - 1, y); 
        ToggleAdjacent(x + 1, y); 
        ToggleAdjacent(x, y - 1); 
        ToggleAdjacent(x, y + 1); 
    }

    void ToggleAdjacent(int x, int y)
    {
        if (x >= 0 && x < columns && y >= 0 && y < rows && grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
        }
    }
    void RandomizeInitialState(int shuffleCount)
    {
        for (int i = 0; i < shuffleCount; i++)
        {
            int randomX = Random.Range(0, columns);
            int randomY = Random.Range(0, rows);
            ToggleTile(randomX, randomY);
        }
        grid[columns / 2, rows / 2].GetComponent<Image>().sprite = spriteO;
    }
}