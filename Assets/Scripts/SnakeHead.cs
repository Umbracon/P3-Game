using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    FixedJoint joint;
    Rigidbody targetRb;

    bool bitten;

    void Awake()
    {
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        bitten = false;
    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.tag == "Attachable" && !bitten)
        {
            Debug.Log("ujebalem");

            FixedJoint[] joints = gameObject.GetComponentsInChildren<FixedJoint>();
            joint = joints[1];
            joint.connectedBody = collision.transform.GetComponent<Rigidbody>();

            targetRb = collision.gameObject.GetComponent<Rigidbody>();
            targetRb.isKinematic = false;

            bitten = true;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && bitten) 
        {
            joint.connectedBody = null;

            bitten = false;
        }
    }
}