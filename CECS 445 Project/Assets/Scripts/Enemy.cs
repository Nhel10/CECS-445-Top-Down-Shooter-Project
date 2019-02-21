using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    smallEnemy, middleEnemy, bigEnemy
}
public class Enemy : MonoBehaviour {
    public int hp = 1;//health
    public int speed = 2;//move spped
    public int score = 100;//score when hit down
    public EnemyType type;
    public bool isDeath = false;

    public Sprite[] explosionSprites;//animation when die
    private float timer = 0;//timer
    public int explosionAnimationFrame = 10;

    private SpriteRenderer render;

    public float hitTimer = 0.2f;//hit time
    private float resetHitTime;

    public Sprite[] hitSprites;

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    // Use this for initialization
    void Start() {
        render = this.GetComponent<SpriteRenderer>();
        resetHitTime = hitTimer;
        if(type == EnemyType.bigEnemy) {
            //if it is a big plane
            hp = 10;
            print("big anemey!!");
            audioSource = this.GetComponent<AudioSource>();
            audioSource.clip = audioClips[1];
            audioSource.loop = true;
            audioSource.Play();
        }
        hitTimer = 0;
    }

    // Update is called once per frame
    void Update() {
        int frameIndex;
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (this.transform.position.y < -5.5f) {
            //audioSourse.PlayOneShot(boomAudio,1f);//
            Destroy(this.gameObject);
        }
        if (isDeath) {
            timer += Time.deltaTime;
            frameIndex = (int)(timer / (1f / explosionAnimationFrame));
            if (frameIndex >= explosionSprites.Length) {//if longer than the length of animation
                Destroy(this.gameObject);
            }
            else {
                //play animation
                render.sprite = explosionSprites[frameIndex];
            }
        }
        else {
            if (type != EnemyType.smallEnemy)
                if (hitTimer >= 0) {
                    hitTimer -= Time.deltaTime;
                    frameIndex = (int)((resetHitTime - hitTimer) / (1f / explosionAnimationFrame));
                    frameIndex %= 2;
                    render.sprite = hitSprites[frameIndex];
                }
        }

    }

    public void BeHit() {
        //small plane
        hp -= 1;
        if (hp <= 0) {
            ToDie();

        }
        else {
            hitTimer = resetHitTime;//reset
        }
    }

    public void ToDie() {
        if (!isDeath) {
            audioSource = this.GetComponent<AudioSource>();
            //set audit
            audioSource.clip = audioClips[0];
            audioSource.Play();
            isDeath = true;
            GameManager._instance.score += score;
        }
    }
}
