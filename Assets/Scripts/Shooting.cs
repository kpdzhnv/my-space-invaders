using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform anchor;
    public Transform aim;
    public int ballSpeed;
    public float cd; private float time;

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
        // cd check
        if (Time.time - time < cd)
            return;

        GameObject ball = Instantiate(BallPrefab, anchor.position, Quaternion.identity, this.transform.parent.transform);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        Animate();

        // to make game more realistic & difficult
        // Vector3 dir =  this.transform.up;

        // to shoot exactly at the aim
        Vector3 dir =  (aim.position - anchor.position).normalized;
        rb.velocity = dir * ballSpeed;

        time = Time.time;
    }

    public void Animate()
    {
        Vector3 scale = this.transform.localScale;
        scale.y = Mathf.Lerp(scale.y,  0.15f, 0.01f);
        this.transform.localScale = scale;
    }

    public void LookAt(Transform aim)
    {
        // current aim
        Vector3 curDir =  anchor.position + this.transform.up;
        // desired aim
        Vector3 aimDir = aim.position;

        float angle = Vector3.SignedAngle(curDir - anchor.position, aimDir - anchor.position, Vector3.forward);
        if (Mathf.Abs(angle) > 1)
        {
            angle = Mathf.Lerp(0, angle, 0.02f);
            transform.RotateAround(anchor.position, Vector3.forward, angle);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    // current aim
    //    Vector3 curDir = anchor.position + this.transform.up;
    //    // desired aim
    //    Vector3 aimDir = aim.position;

    //    Gizmos.color = Color.cyan;
    //    Gizmos.DrawLine(anchor.position, aimDir);

    //    Gizmos.color = Color.magenta;
    //    Gizmos.DrawLine(anchor.position, curDir) ;
    //    Gizmos.DrawSphere(curDir, 0.1f);

    //}
}
