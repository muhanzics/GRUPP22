using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomizePuzzle : MonoBehaviour
{
    public int rows = 3;
    public int columns = 3;
    public GameObject tilePrefab;
    public Transform tilesParent;
    public Sprite spriteX;
    public Sprite spriteO;
    public CanvasGroup winPanel;
    public float fadeDuration = 1.0f;

    private GameObject[,] grid;

    void Start()
    {
        grid = new GameObject[columns, rows];
        GenerateCustomGrid();
        RandomizeInitialState(minimumXSwitches: 5);
    } //start

    void GenerateCustomGrid() {
    float cellWidth = 120f;
    float cellHeight = 120f;
    float spacing = 150f;

    float totalWidth = columns * (cellWidth + spacing) - spacing;
    float totalHeight = rows * (cellHeight + spacing) - spacing;

    Vector2 startPosition = new Vector2(-totalWidth / 2, -totalHeight / 2);

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
        }// inner for
    }// outer for

    winPanel.alpha = 0;
    winPanel.interactable = false;
    winPanel.blocksRaycasts = false;
} // generatecustomgrid

    void ToggleTile(int x, int y)
    {
        if (grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
            
            AudioSource audioSource = grid[x, y].GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }//inner if
        }// outer if

        ToggleAdjacent(x - 1, y);
        ToggleAdjacent(x + 1, y);
        ToggleAdjacent(x, y - 1);
        ToggleAdjacent(x, y + 1);

        CheckWinCondition();
    }// toggletile

    void ToggleAdjacent(int x, int y)
    {
        if (x >= 0 && x < columns && y >= 0 && y < rows && grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
        }// if
    } // toggleadjacent

    void RandomizeInitialState(int minimumXSwitches)
    {
        int xCount = 0, oCount = 0;
        EnsureXCount(minimumXSwitches, ref xCount, ref oCount);

        int totalTiles = rows * columns;
        int targetXCount = Mathf.Max(minimumXSwitches, (int)(totalTiles * 0.6f));

        EnsureXCount(targetXCount, ref xCount, ref oCount);

        int finalSwitches = Random.Range(minimumXSwitches, totalTiles / 2);
        for (int i = 0; i < finalSwitches; i++)
        {
            int randomX = Random.Range(0, columns);
            int randomY = Random.Range(0, rows);
            ToggleSingleTile(randomX, randomY);
        } // for
    } //randomizeinitialstate

    void EnsureXCount(int targetXCount, ref int xCount, ref int oCount)
    {
        CountTiles(ref xCount, ref oCount);

        while (xCount < targetXCount)
        {
            int randomX = Random.Range(0, columns);
            int randomY = Random.Range(0, rows);
            Image tileImage = grid[randomX, randomY].GetComponent<Image>();
            if (tileImage.sprite != spriteX)
            {
                tileImage.sprite = spriteX;
                xCount++;
                oCount--;
            } //if
        } //while
    } //ensureXcount

    void ToggleSingleTile(int x, int y)
    {
        if (grid[x, y] != null)
        {
            Image tileImage = grid[x, y].GetComponent<Image>();
            tileImage.sprite = tileImage.sprite == spriteX ? spriteO : spriteX;
        }// if
    }//togglesingletile

    void CountTiles(ref int xCount, ref int oCount)
    {
        xCount = 0;
        oCount = 0;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Image tileImage = grid[x, y].GetComponent<Image>();
                if (tileImage.sprite == spriteX)
                {
                    xCount++;
                }//if
                else
                {
                    oCount++;
                }//else
            }//inner for
        }//outer for
    }// counttiles

    void CheckWinCondition()
    {
        bool allO = true;
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Image tileImage = grid[x, y].GetComponent<Image>();
                if (tileImage.sprite != spriteO)
                {
                    allO = false;
                    break;
                }// inner if
            }//inner for
            if (!allO) break; // outer if
        }//for

        if (allO)
        {
            StartCoroutine(ShowWinPanel());
        }// if
    }// checkwincondition

    IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(1.0f);
        float elapsed = 0f;

        winPanel.gameObject.SetActive(true); 
        winPanel.interactable = true;
        winPanel.blocksRaycasts = true;

        while (elapsed < fadeDuration)
        {
            winPanel.alpha = Mathf.Lerp(0, 1, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }//while

        winPanel.alpha = 1;
    }//showwinpanel
}//end
