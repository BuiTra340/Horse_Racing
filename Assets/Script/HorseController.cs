using UnityEngine;

public class HorseController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float moveSpeedModifier;
    private bool changeSpeed;
    private float speedRandom;
    private float durationConvert = 0;
    private float distanceMoved = 100;

    private Animator animator;
    private Rigidbody rigidbody;
    private const string moving = "Moving";
    private bool changeSpeedOneTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        moveSpeedModifier = moveSpeed;
        StartingChangeSpeed();
    }

    private void Update()
    {
        if (transform.position.z / distanceMoved >= 1)
        {
            distanceMoved += 100;
            StartingChangeSpeed();
        }

        if (changeSpeed)
        {
            durationConvert += Time.deltaTime;
            moveSpeed = Mathf.Lerp(moveSpeedModifier, speedRandom, durationConvert / 1f);
            if (durationConvert >= 1f)
            {
                durationConvert = 0;
                changeSpeed = false;
            }
        }
    }

    private void StartingChangeSpeed()
    {
        changeSpeed = true;
        if (!changeSpeedOneTime)
        {
            changeSpeedOneTime = true;
            speedRandom = Random.Range(moveSpeedModifier - 1, moveSpeedModifier + 2);
        }else
        {
            if(speedRandom > moveSpeedModifier - 1 && speedRandom >= moveSpeedModifier)
            {
                speedRandom = Random.Range(moveSpeedModifier - 1, moveSpeedModifier);
            }
            else
            {
                speedRandom = Random.Range(moveSpeedModifier + 1, moveSpeedModifier);
            }
        }
    }

    void FixedUpdate()
    {
        if (GameManager.instance.IsGameRunning())
        {
            animator.SetBool(moving, true);
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, moveSpeed);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}
