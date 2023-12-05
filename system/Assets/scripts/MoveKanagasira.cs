using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MoveKanagasira : MonoBehaviour
{
    private Animator animator; // アニメーター
    public float Speed = 0.5f;
    private Vector3[] destinationArray = new Vector3[3];

    public float animationSpeed = 1.0f; // アニメ再生速度

    public float rotateSpeed = 0.5f;

    public GameObject destination1;
    public GameObject destination2;
    private int cur = 1;

    private bool arrived = false;


    // Start is called before the first frame update
    void Start ()
    {
        animator = GetComponent<Animator> ();
        destinationArray[0] = transform.position;
        destinationArray[1] = destination1.transform.position; //new Vector3 (-130.8f, -71f, 70.3f);
        destinationArray[2] = destination2.transform.position; //new Vector3 (-172.2f, -64.33f, 92f);
    }

    // Update is called once per frame
    void Update ()
    {
        Rigidbody rb = this.GetComponent<Rigidbody> ();
        transform.Translate (0f, 0f, Speed * Time.deltaTime);
        animator.SetFloat ("Speed", animationSpeed);
        if (!arrived)
        {
            Quaternion targetRotation = Quaternion.LookRotation (destinationArray[cur] - transform.position);
            transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            if (Vector3.Distance (transform.position, destinationArray[cur]) < 3f)
            {
                arrived = true;

            }
        }
        else
        {
            if (cur != 2) cur++;
            else cur = 0;
            arrived = false;
        }
    }
}