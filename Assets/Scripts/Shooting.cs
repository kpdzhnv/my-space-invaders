using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform anchor;
    public Transform aim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt(aim);

        if (Input.GetButtonDown("Fire1"))
            Fire();
    }

    public void Fire()
    {

        GameObject ball = Instantiate(BallPrefab, anchor.position, Quaternion.identity, this.transform.parent.transform);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        Vector3 dir =  this.transform.up;
        rb.velocity = dir * 5;
    }

    private Vector3 lastAimPos = Vector3.zero;
    public void LookAt(Transform aim)
    {
        // current aim
        Vector3 curDir =  anchor.position + this.transform.up;
        // desired aim
        Vector3 aimDir = aim.position;
        float angle = Vector3.SignedAngle(aimDir - anchor.position, curDir - anchor.position, Vector3.back);
        
        if (Mathf.Abs(angle) > 5)
        {
            angle = Mathf.Lerp(0, angle, 0.1f);
            transform.RotateAround(anchor.position, Vector3.forward, angle);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 dir = anchor.position + this.transform.up;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(anchor.position, aim.position);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(anchor.position, anchor.position + this.transform.up) ;
        Gizmos.DrawSphere(dir, 0.1f);
    }
}
