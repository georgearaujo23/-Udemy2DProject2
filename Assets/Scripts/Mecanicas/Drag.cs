using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    private Collider2D drag;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool clicked = false;
    private Touch touch;

    [SerializeField] private LineRenderer lineFront;
    [SerializeField] private LineRenderer lineBack;

    [SerializeField] private GameObject limite;

    //Rastro
    private TrailRenderer rastro;

    private SpringJoint2D spring;
    private Vector2 prevVel;
    private Rigidbody2D passarorb;

    [SerializeField] private GameObject bomb;

    //Limite elastico
    private Transform catapult;
    private Ray rayToMT;

    // Use this for initialization
    void Start () {
        drag = GetComponent<Collider2D>();
        setupLine();
        spring = GetComponent<SpringJoint2D>();
        rastro = GetComponentInChildren<TrailRenderer>();
        passarorb = GetComponent<Rigidbody2D>();
        catapult = spring.connectedBody.transform;
        rayToMT = new Ray(catapult.position, Vector3.zero);
    }
	
	// Update is called once per frame
	void Update () {
        LineUpdate();
        springEfect();
        prevVel = passarorb.velocity;

        #if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(wp, Vector2.zero, Mathf.Infinity,  layer.value);

            if(hit.collider != null)
            {
                clicked = true;
            }

            if (clicked)
            {
                if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    Vector3 tpos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    Vector3 distancia = tpos - catapult.position;

                    if (distancia.magnitude > 3f)
                    {
                        rayToMT.direction = distancia;
                        tpos = rayToMT.GetPoint(3.1f);

                    }
                    transform.position = tpos;
                    
                }
            }
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                passarorb.isKinematic = false;
                clicked = false;
                mortePassaro();
            }

        }

        #endif

        #if UNITY_EDITOR
        if (clicked)
        {
            Dragging();
        }
        else
        {
            //mortePassaro();
        }
        #endif

    }

    private void Dragging()
    {
        Vector3 mouseUP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseUP.z = 0f;

        Vector3 distancia = mouseUP - catapult.position;

        if (distancia.magnitude > 3f)
        {
            rayToMT.direction = distancia;
            mouseUP = rayToMT.GetPoint(3.1f);

        }

        transform.position = mouseUP;
    }

    private void OnMouseDown()
    {
        clicked = true;
        rastro.enabled = false;
    }

    private void OnMouseUp()
    {
        passarorb.isKinematic = false;
        clicked = false;
        rastro.enabled = true;
        mortePassaro();
    }

    void setupLine()
    {
        lineFront.SetPosition(0, lineFront.transform.position);
        lineBack.SetPosition(0, lineBack.transform.position);
    }

    void LineUpdate()
    {
        lineFront.SetPosition(1, limite.transform.position);
        lineBack.SetPosition(1, limite.transform.position);
        /*lineFront.SetPosition(1, transform.position);
        lineBack.SetPosition(1, transform.position);*/
    }

    void springEfect()
    {
        if (spring != null) {
            if (!passarorb.isKinematic)
            {
                if (prevVel.sqrMagnitude > passarorb.velocity.sqrMagnitude)
                {
                    lineBack.enabled = false;
                    lineFront.enabled = false;
                    Destroy(spring);
                    passarorb.velocity = prevVel;
                }
            }
        }
    }

    void mortePassaro()
    {
        if(passarorb.velocity.magnitude < 0.5f)
        {
            StartCoroutine(tempoMote());
        }
    }

    IEnumerator tempoMote()
    {
        yield return new WaitForSeconds(3);
        Instantiate(bomb, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        Destroy(gameObject);
    }

}
