using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public GameObject BrickParticle;

    private void OnCollisionEnter(Collision collision)
    {
        GM.Score += 10;
        GM.Instance.GainScore();
        Instantiate(BrickParticle, transform.position, Quaternion.identity);
        GM.Instance.DestroyBrick();
        Destroy(gameObject);
    }
}
