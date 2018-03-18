using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovementScript : MonoBehaviour {

    [SerializeField]
    private GameObject needleBody;

    private bool canShootNeedle;
    private bool touchedCircle;

    private float speedY = 10f;

    private Rigidbody2D myBody;

	// Use this for initialization
	void Awake () {
        Initalize();
       
    }
	
	// Update is called once per frame
	void Update () {
        
		if (canShootNeedle)
        {
            myBody.velocity = new Vector2(0, speedY);
        }
	}

    void Initalize()
    {
        needleBody.SetActive(false);
        myBody = GetComponent<Rigidbody2D>();
    }

    public void FireNeedle()
    {
        needleBody.SetActive(true);
        myBody.isKinematic = false;
        canShootNeedle = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (touchedCircle)
        {
            return;
            
        }
        
        if (other.tag == "Circle")
        {
            canShootNeedle = false;
            touchedCircle = true;
            myBody.velocity = Vector2.zero;
            myBody.isKinematic = true;
            gameObject.transform.SetParent(other.transform);
            
            

        }
    }
}
