using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float destroyPlatformTime = 1f;

    public GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 starPos = transform.position;

        starPos.y += 1f;

        int randDiamond = Random.Range(0, 5);

        if(randDiamond < 1)
        {
            Instantiate(star, starPos, star.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.2f);
        }
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, destroyPlatformTime);
    }
}
