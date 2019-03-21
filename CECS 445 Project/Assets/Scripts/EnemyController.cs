using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    const int basicAmount = 10;
    private float earning = 1.0f;
    
    public int level;
    public float speed;

    private Vector2[] randomPos = new Vector2[5];
    private float t = 0;
    private float timeToCross = 20.0f;

    public CurrencyController currency;

    private Rigidbody2D enemy;

    // Use this for initialization
    void Start()
    {
        this.enemy = GetComponent<Rigidbody2D>();
        randomPos[0] = this.enemy.gameObject.transform.position;
        randomPos[4] = new Vector2(-this.enemy.gameObject.transform.position.x, -this.enemy.gameObject.transform.position.y);

        // STEP 1 : SET point along the path drawn from randomPos[0] to randomPos[4] EVENTLY separated
        for (int i = 1; i < 4; i++) { randomPos[i] = (randomPos[4] - randomPos[0]) * .25f * i + randomPos[0]; }

        // TODO : change the enemy behaviour with pathfinding toward player or spiral movement (avoid collision that way)
        for (int i = 1; i < 4; i++)
        {
            // STEP 2; SET circle (C1, C2, C3, C4) CENTERED RESPECTIVELY at P1, P2, P3 and P4 with radius R : min < R < max
            float tmpRadius = Random.Range(5, 10);

            // STEP 3: SET whether the landmark should be on LEFT or RIGHT of this circle (+/- 90 degrees)
            float side = Random.Range(-1, 1) < 0 ? -90 : 90;

            // STEP 4: SET a random angle within range to set a "randomized" position on this cicle (in the range)
            float tmpAngle = Random.Range(-15, 15);

            // STEP 5: GET the angle between the path and the VECTOR UP
            float anglePath = GetRotationFromPath(randomPos[4] - randomPos[0]);

            // STEP 6: sum all angle to get the point on the circle where the landmark should be placed
            float finalAngle = side + tmpAngle + anglePath;

            // need to test if value are all good
            randomPos[i] = new Vector2(tmpRadius * Mathf.Cos(finalAngle), tmpRadius * Mathf.Sin(finalAngle)) + randomPos[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        Vector2 newPos = BezierCurvePath();

        transform.position = newPos;
        RotateTowardPlayer();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    Vector2 BezierCurvePath()
    {
        Vector2[] Qs = new Vector2[4];
        Vector2[] Rs = new Vector2[3];
        Vector2[] Ss = new Vector2[2];

        float percent = t / timeToCross;

        for (int i = 0; i < 4; ++i) { Qs[i] = (randomPos[i + 1] - randomPos[i]) * percent + randomPos[i]; }
        for (int i = 0; i < 3; ++i) { Rs[i] = (Qs[i + 1] - Qs[i]) * percent + Qs[i]; }
        for (int i = 0; i < 2; ++i) { Ss[i] = (Rs[i + 1] - Rs[i]) * percent + Rs[i]; }

        Vector2 current = (Ss[1] - Ss[0]) * percent + Ss[0];

        return current;
    }

    public float GetEarning()
    {
        return this.earning;
    }

    public float GetBasicAmount()
    {
        return basicAmount;
    }

    private void RotateTowardPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            float rotation = GetRotationFromPosition(player.transform.position);
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
        // TODO
        // move toward direction (need to know position t+1 for vector)
    }

    private float GetRotationFromPosition(Vector2 playerPosition)
    {
        Vector2 enemyPosition = transform.position;
        float angle = Vector2.Angle(Vector2.up, enemyPosition - playerPosition);

        return (playerPosition.x < enemyPosition.x) ? -angle : angle;
    }

    private float GetRotationFromPath(Vector2 pathVector)
    {
        return Vector2.Angle(Vector2.up, pathVector);
    }
}
