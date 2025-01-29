using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float ZRotate = 45f;
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public bool rocketIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(0, speed, 0);
        if(Input.GetKeyDown(KeyCode.Space) && rocketIsAlive)
        {
            speed = -1 * speed;
            ZRotate = -1 * ZRotate;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, ZRotate);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        rocketIsAlive = false;
    }
}
