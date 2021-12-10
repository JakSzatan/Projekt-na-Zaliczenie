using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisions : MonoBehaviour
{
    public bool isInvincible = false;
    [SerializeField]
    private float invincibilityDurationSeconds;
    [SerializeField]
    private float KnockbackValue;
    private SpriteRenderer spriteRenderer;
    public Material flashMaterial;
    public Material defaultMaterial;
    private Rigidbody2D rb;
    public AudioSource GetHitSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!isInvincible)
            {
                //knockback
                Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
                rb.AddForce(difference* KnockbackValue, ForceMode2D.Impulse);
                StartCoroutine(BecomeTemporarilyInvincible());
                PlayerStats.Instance.TakeDamage(1);
                GetHitSound.Play();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (!isInvincible)
            {
                GetHitSound.Play();
                Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
                rb.AddForce(difference * KnockbackValue, ForceMode2D.Impulse);
                StartCoroutine(BecomeTemporarilyInvincible());
                PlayerStats.Instance.TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().damage);
                DestroyObject(collision.gameObject);
            }
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
