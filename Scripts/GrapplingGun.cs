using UnityEngine;

public class GrapplingGun : MonoBehaviour {

    public int remainingHook;

    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;


    private void Start()
    {
        remainingHook = 5;
    }
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) && remainingHook > 0))
        {
            StartGrapple();

        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
        
    }



    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.4f;
            joint.minDistance = distanceFromPoint * 0.4f;

            //Adjust these values to fit your game.
            joint.spring = 30f;
            joint.damper = 30f;
            joint.massScale = 4.5f;
            ExecuteGrapple();
        }
    }
    [SerializeField] PlayerMovementAdvanced pm;
    float overshootYAxis;
    private void ExecuteGrapple()
    {
        remainingHook--;

        pm.freeze = false;

        Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        float highestPointOnArc = grapplePointRelativeYPos + overshootYAxis;

        if (grapplePointRelativeYPos < 0) highestPointOnArc = overshootYAxis;

        pm.JumpToPosition(grapplePoint, highestPointOnArc);
    }
    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    public void StopGrapple() {
        Destroy(joint);
    }



    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}