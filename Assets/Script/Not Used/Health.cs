using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iframe")]
    [SerializeField] private float iframesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death & Hurt Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    [Header("Conditional Event")]
    public UnityEvent ConditionalEvents;
    public bool DestroyTrigger;

    PlayerMove pm;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void InvokeTrigger()
    {
        ConditionalEvents.Invoke();
    }

    public void TakeDamage(float _damage)
    {
        //menentukan max-min
        //min 0 max health awal
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //SoundManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invurnerability());
        }
        else
        {
            if (!dead)
            {
                //deactivate all attach components
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                anim.SetBool("grounded", true);
                anim.SetTrigger("die");
                dead = true;
                //SoundManager.instance.PlaySound(deathSound);
                StartCoroutine(DelayDie());
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                //anim.SetTrigger("die");
                //deactivate all attach components
                //foreach (Behaviour component in components)
                //{
                //    component.enabled = false;
                //}
                //dead = true;
            }
        }
    }

    private IEnumerator Invurnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesDuration / (numberOfFlashes) * 2);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iframesDuration / (numberOfFlashes) * 2);
        }
        Physics2D.IgnoreLayerCollision(10, 9, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    IEnumerator DelayDie()
    {
        //delay buat animasi
        yield return new WaitForSeconds(1f);
        ConditionalEvents.Invoke();

    }
}
