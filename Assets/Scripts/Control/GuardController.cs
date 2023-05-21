using UnityEngine;

public class GuardController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float stoppingDistance = .1f;
    [SerializeField] float waypointDwellTime = 3f;
    [SerializeField] float wayPointTolerence = 1f;
    [SerializeField] WayPoint patrolPath;


    private float timeSinceArrived = Mathf.Infinity;
    private int currentWayPointIndex = 0;
    private Animator anim;
    private CharacterController controller;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PatrolBehaviour();
        UpdateTimer();
    }

    private void Move(Vector3 moveToPosition)
    {
        Vector3 moveDirection = (moveToPosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, moveToPosition) > stoppingDistance)
        {
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        if (moveDirection != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        }
    }

    private void UpdateTimer()
    {
        timeSinceArrived += Time.deltaTime;
    }

    private Vector3 GetGuardPosition()
    {
        return transform.position;
    }

    private void PatrolBehaviour()
    {
        Vector3 nextPosition = GetGuardPosition();

        if (patrolPath != null)
        {
            if (AtWayPoint())
            {
                anim.SetBool("IsWalking", false);
                timeSinceArrived = 0;
                CycleWayPoint();
            }
            nextPosition = GetCurrentWayPoint();
        }
        if (timeSinceArrived > waypointDwellTime)
        {
            Move(nextPosition);
        }
    }

    private Vector3 GetCurrentWayPoint()
    {
        return patrolPath.GetWayPoint(currentWayPointIndex);
    }
    private void CycleWayPoint()
    {
        currentWayPointIndex = patrolPath.GetNextIndex(currentWayPointIndex);
    }

    private bool AtWayPoint()
    {
        float distanceToWayPoint = Vector3.Distance(transform.position, GetCurrentWayPoint());
        return distanceToWayPoint < wayPointTolerence;
    }

}
