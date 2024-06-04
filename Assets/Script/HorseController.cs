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
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        moveSpeedModifier = moveSpeed;
        StartingChangeSpeed();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            //distanceMoved += 100;
            StartingChangeSpeed();
            timer = 0;
        }

        if (changeSpeed)
        {
            durationConvert += Time.deltaTime;
            moveSpeed = Mathf.Lerp(moveSpeedModifier, speedRandom, durationConvert / 3f);
            if (durationConvert >= 3f)
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
                speedRandom = Random.Range(moveSpeedModifier - 2f, moveSpeedModifier);
            }
            else
            {
                speedRandom = Random.Range(moveSpeedModifier + 2f, moveSpeedModifier);
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
