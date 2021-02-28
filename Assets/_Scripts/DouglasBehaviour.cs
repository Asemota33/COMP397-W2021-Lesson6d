using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum DouglasState
{
    IDLE,
    RUN,
    JUMP
}
public class DouglasBehaviour : MonoBehaviour
{
    [Header("Line Of Sight")]
    public LayerMask collisionLayer;
    public Vector3 LOSoffset = new Vector3(0.0f, 2.0f, -5.0f);
    public bool HasLOS;

    private NavMeshAgent agent;
    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var size = new Vector3(4.0f, 2.0f, 10.0f);
        HasLOS = Physics.BoxCast(transform.position + LOSoffset, size, transform.forward, out hit, transform.rotation, 0.0f, collisionLayer);
        //HasLOS = Physics.BoxCast(transform.position + LOSoffset, size * 0.5f, transform.forward, out hit, transform.rotation);

        //Debug.Log(hit.transform.gameObject.name);
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetInteger("AntState", (int)DouglasState.IDLE);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetInteger("AntState", (int)DouglasState.RUN);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetInteger("AntState", (int)DouglasState.JUMP);
        }

       
    }

    void OnDrawGizmos()
    {
        var size = new Vector3(4.0f, 2.0f, 10.0f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + LOSoffset + transform.forward , size * 0.5f);
    }
}
