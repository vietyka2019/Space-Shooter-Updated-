using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Scoring score; 

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float health = 5f;

    [SerializeField] List<Transform> squareSpawnPositions = new List<Transform>(); // Danh sách các vị trí để sinh các instance cho square
    [SerializeField] List<Transform> squareRhombusPositions = new List<Transform>(); // Danh sách các vị trí để sinh các instance cho rhombus
    [SerializeField] List<Transform> squareTrianglePositions = new List<Transform>(); // Danh sách các vị trí để sinh các instance cho triangle
    [SerializeField] List<Transform> squareRectanglePositions = new List<Transform>(); // Danh sách các vị trí để sinh các instance cho rectangle
    
    GameObject[] enemies;
    Collider2D collider;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = false;
        StartCoroutine(SpanwAndMoveEnemies());
    }


    IEnumerator SpanwAndMoveEnemies()
    {
        enemies = new GameObject[squareSpawnPositions.Count];

        int rows = 4;
        int cols = 4;
        int moveYOneUnitDown = 0;  // minus y-coordinate by one after each row

        // Di chuyển các enemy từ ngoài màn hình vào vị trí ban đầu của hàng đầu tiên trong hình vuông
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector3 spawnPositionOutside = new Vector3(squareSpawnPositions[i].position.x, squareSpawnPositions[i].position.y + 10f, squareSpawnPositions[i].position.z);
            enemies[i] = Instantiate(enemyPrefab, spawnPositionOutside, Quaternion.identity);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(MoveEnemiesToSquare(enemies, rows, cols, moveYOneUnitDown));

        yield return new WaitForSeconds(5f);

        yield return StartCoroutine(MoveEnemiesToRhombus(enemies, squareRhombusPositions));

        yield return new WaitForSeconds(5f);

        yield return StartCoroutine(MoveEnemiesToTriangle(enemies, squareTrianglePositions));

        yield return new WaitForSeconds(5f);

        yield return StartCoroutine(MoveEnemiesToRectangle(enemies, squareRectanglePositions));

        yield return new WaitForSeconds(5f);
    }

    IEnumerator MoveEnemiesToSquare(GameObject[] enemies, int rows, int cols, int moveYOneUnitDown)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int index = row * cols + col;
                Vector3 targetPosition = new Vector3(squareSpawnPositions[col].position.x, squareSpawnPositions[col].position.y - moveYOneUnitDown, squareSpawnPositions[col].position.z);

                if (enemies[index] != null)
                {
                    while (Vector3.Distance(enemies[index].transform.position, targetPosition) > 0.1f)
                    {
                        enemies[index].transform.position = Vector3.MoveTowards(enemies[index].transform.position, targetPosition, moveSpeed * Time.deltaTime);
                        yield return null;
                    }
                }
            }

            moveYOneUnitDown++;
        }

        collider.isTrigger = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator MoveEnemiesToRhombus(GameObject[] enemies, List<Transform> squareRhombusPositions)
    {
        collider.isTrigger = false; 
        for (int i = 0; i < squareRhombusPositions.Count; i++)
        {
            Vector3 targetPosition = new Vector3(squareRhombusPositions[i].position.x, squareRhombusPositions[i].position.y, squareRhombusPositions[i].position.z);

            if (enemies[i] != null)
            {
                while (Vector3.Distance(enemies[i].transform.position, targetPosition) > 0.1f)
                {
                    // Debug.Log("Enemy: " + enemies.GetValue(i) + " " + "RhombusPosition: " + squareRhombusPositions[i]);
                    enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }
        }

        collider.isTrigger = true; 
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator MoveEnemiesToTriangle(GameObject[] enemies, List<Transform> squareTrianglePositions)
    {
        collider.isTrigger = false;
        for (int i = 0; i < squareTrianglePositions.Count; i++)
        {
            Vector3 targetPosition = new Vector3(squareTrianglePositions[i].position.x, squareTrianglePositions[i].position.y, squareTrianglePositions[i].position.z);

            if (enemies[i] != null)
            {
                while (Vector3.Distance(enemies[i].transform.position, targetPosition) > 0.1f)
                {
                    enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }
        }

        collider.isTrigger = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator MoveEnemiesToRectangle(GameObject[] enemies, List<Transform> squareRectanglePositions)
    {
        collider.isTrigger = false;
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector3 targetPosition = new Vector3(squareRectanglePositions[i].position.x, squareRectanglePositions[i].position.y, squareRectanglePositions[i].position.z);
            if (enemies[i] != null)
            {
                while (Vector3.Distance(enemies[i].transform.position, targetPosition) > 0.1f)
                {
                    enemies[i].transform.position = Vector3.MoveTowards(enemies[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }
        }

        collider.isTrigger = true;
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = new Enemy();

        if (collider.isTrigger)
        {
            bool enemyDestroyed = false; 

            for (int i = 0; i < enemies.Length; i++)
            {
                int randomEnemy = Random.Range(i, enemies.Length);
                // Debug.Log("randomEnemy: " + randomEnemy);

                if (enemies[randomEnemy] != null)
                {
                    if (collision.CompareTag("Bullet") && !enemyDestroyed)
                    {
                        // Debug.Log("enemies[i] " + enemies[randomEnemy]);
                        BulletBasic bullet = collision.GetComponent<BulletBasic>();
                        BulletBasic getBullet = enemies[randomEnemy].GetComponent<BulletBasic>();

                        enemy.TakeDmg(1);

                        if (enemy.health == 0)
                        {
                            enemyDestroyed = true; 
                            // enemy.health = 0; 
                            Destroy(bullet.gameObject);
                            // Debug.Log(bullet.gameObject + "has been destroyed");
                            Destroy(getBullet.gameObject);
                            // Debug.Log(getBullet.gameObject + "has been destroyed");
                            score.AddScore(1); 
                        }
                    }
                }
            }
        }
    }
}