using UnityEngine;

public class TankerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Animator anim;
    public bool isPlay;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Manager.Ins.m_isPlay) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);
        if (transform.position.y > 6)
        {
            transform.position += Vector3.down * Time.deltaTime;
            return;
        }
        if (transform.position.y < -6)
        {
            transform.position += Vector3.up * Time.deltaTime;
            return;
        }
        if (transform.position.x < -12)
        {
            transform.position += Vector3.right * Time.deltaTime;
            return;
        }
        if (transform.position.x > 12)
        {
            transform.position += Vector3.left * Time.deltaTime;
            return;
        }

        transform.position += direction * speed * Time.deltaTime;

        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }

        if (horizontal == 0 && vertical == 0)
            return;


        float targetRotation = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        float step = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -targetRotation), step);

    }
}
