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

        /********************************************************************************\
         * for Bezier : set 3 random point within screenview (start + end being         *
         * spawn point and opposite on circle) || may need to define less randomised    *
         * point  e.g. choose three point from the vector start-end (each evenly        *
         * separated) from theese point choose a circle that is from e.g. 5 and         *
         * 10 of radius and choose a point on theses circles either around 90 or -90    *
         * degreen +- 10 degree in order to create a sort of sinusoidal curve           *
        \********************************************************************************/
        for (int i = 1; i < 4; ++i)
        {
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0));
            randomPos[i].x = screenPos.x;
            randomPos[i].y = screenPos.y;
        }
        // Debug Line
        //Debug.DrawLine(randomPos[0], randomPos[4], Color.white, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //choosing bézier curve as enemy behaviour
        // may use another behaviour (e.g. spiral)
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
        // May need to choose another behaviour for faster code
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
        // move toward direction (need to know position t+1 for vector)
    }

    private float GetRotationFromPosition(Vector2 playerPosition)
    {
        Vector2 enemyPosition = transform.position;
        float angle = Vector2.Angle(Vector2.up, enemyPosition - playerPosition);

        return (playerPosition.x < enemyPosition.x) ? -angle : angle;
    }
}
