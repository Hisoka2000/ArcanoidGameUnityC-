using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksTwoHit : MonoBehaviour {

    public GameObject BrickParticle;
    public int Lives = 2;
    public Material First;
    public Material Second;
    public Renderer rend;
    private Rigidbody RtB;
    private GameObject CloneBall;
    public GameObject Ball;
    public float BallInitalVelocity = 600f;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = First;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int Chance = 3;
        int Guess = Random.Range(1,5);

        if (Lives == 1)
        {
            if(Chance == Guess)
            {               
                   CloneBall = Instantiate(Ball, collision.transform.position, Quaternion.identity) as GameObject;
                   CloneBall.tag = "BonusBall";
                   CloneBall.GetComponent<Rigidbody>().AddForce(new Vector3(BallInitalVelocity, BallInitalVelocity, 0));
                   
            }
            GM.Score += 15;
            GM.Instance.GainScore();
            Instantiate(BrickParticle, transform.position, Quaternion.identity);
            GM.Instance.DestroyBrick();
            Destroy(gameObject);
        } else
        {
            rend.material = Second;
            Lives--;
        }
    }
}
