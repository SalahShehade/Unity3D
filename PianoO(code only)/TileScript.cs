
using System.Collections;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public float speed;

    public float resetPosition = 3f;
    public float pressedPosition = 1f;
    private Vector3 startPos;
    private Vector3 endPos;

    private bool flagPos = true;

    private bool isWaiting = false;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, 3f);

        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPos = new Vector3(transform.position.x, pressedPosition, transform.position.z);

        transform.position = startPos;
        StartCoroutine(WaitAndResume());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            MoveTile();
        }
    }



    void MoveTile()
    {
        Debug.Log(transform.position);
        Debug.Log(startPos);
        Debug.Log(endPos);
        Debug.Log(flagPos);
        if (flagPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (transform.position == endPos)
            {
                flagPos = false;
            }
        }

        else if (!flagPos)
        {


            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (transform.position == startPos)
            {
                StartCoroutine(WaitAndResume());
                flagPos = true;
            }
        }
    }

    IEnumerator WaitAndResume()
    {
        isWaiting = true;


        yield return new WaitForSeconds(Random.Range(1f, 3f));

        isWaiting = false;
    }



}
