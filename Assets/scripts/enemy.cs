using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float Health=10;
    private bool isInvincible = false;
    [SerializeField]
    private float invincibilityDurationSeconds;
    private SpriteRenderer spriteRenderer;
    public Material flashMaterial;
    public Material defaultMaterial;
    private Rigidbody2D rb;
    public float KnockbackValue;
    public AudioSource GetHitSound;
    public GameObject ExplotionPrefab;
    public Agrro agrro;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        agrro = GetComponent<Agrro>();
    }

    ///Colision with a bullet
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible) return;

        if (collision.gameObject.tag == "Bullet")
        {
            if (!agrro.isAgrro){
                agrro.SetAgrro();
            }
            GetHitSound.Play();
            var BulletObj = collision.gameObject.GetComponent<bullet>();
            Health -= BulletObj.damage;
            DestroyObject(collision.gameObject);

            //knockback                                 v get player position
            Vector2 difference = (transform.position - GameObject.Find("Player").transform.position).normalized * BulletObj.knockbackForce;
            //transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            rb.AddForce(difference * KnockbackValue, ForceMode2D.Impulse);
            //Invinciblilty frames*
            if (!isInvincible)
            {
                StartCoroutine(BecomeTemporarilyInvincible());
            }
        }
        if (Health<=0)
        {
            Instantiate(ExplotionPrefab,transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;
        StartCoroutine(FlashWhite());
        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
    }
    private IEnumerator FlashWhite()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(FlashSprite());


    }
    IEnumerator FlashSprite()
    {
        spriteRenderer.material = defaultMaterial;
        yield return new WaitForSeconds(0.2f);
        if (isInvincible)
        {
            StartCoroutine(FlashWhite());
        }
    }

}
