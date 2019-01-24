using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRockets : MonoBehaviour
{
    public Transform target;
    public float travelSpeed;
    public float rotationSpeed;
    private Rigidbody2D rigBody;
    public GameObject explotionAnim;


    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Initialize(float movementSpeed, Faction.Side bulletSide)
    {
        this.travelSpeed = movementSpeed ;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 diff = target.position - transform.position;
        diff.z = 0;
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, angle, rotationSpeed * Time.deltaTime));

        rigBody.velocity = transform.right * travelSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject newExplotion = Instantiate(explotionAnim, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        
    }
}
