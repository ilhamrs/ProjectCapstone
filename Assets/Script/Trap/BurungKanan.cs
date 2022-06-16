using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurungKanan : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] Revisi revisi;
    public GameObject trapObject;
    public GameObject triggerTrap;
    private float lifetime;
    private float direction;
    private Animator anim;
    public BoxCollider2D coll;

    Vector2 originalPos;
    private bool hit;

    [Header("Trigger Reset")]
    [SerializeField] Transform reset;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        ActivateProjectile(1);
    }
    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = originalPos;
    }
    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }
    public void ActivateProjectile(float projectile_direction)
    {
        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.active();
        anim.SetBool("isMove", true);
        hit = false;
        direction = projectile_direction;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != projectile_direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            reset.GetComponent<Reset>().ActivateRoom(true);
            hit = true;
            coll.enabled = false;
            revisi.getHit();
            StartCoroutine(Reset(1));
            gameObject.SetActive(false);
        }

    }
    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.nonactive();
        Debug.Log("reset");
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
