using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 20f;
    public float rotationSpeed = 100f;
    public float boostMultiplier = 3f;

    public GameObject Flag;
    public float flagRotationSpeed = 300f;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        float moveInput = Input.GetAxis("Vertical");

        float rotationInput = Input.GetAxis("Horizontal");

        float currentSpeed = moveSpeed;

        bool isBoosting = Input.GetKey(KeyCode.LeftShift);

        if (isBoosting)
        {
            currentSpeed *= boostMultiplier;
        }
        Debug.Log($"Current Speed: {currentSpeed}");



        Vector3 movement = transform.right * moveInput * currentSpeed * Time.deltaTime;


        transform.position += movement;


        float rotationAngle = rotationInput * rotationSpeed * Time.deltaTime;


        Quaternion rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        transform.rotation *= rotation;

        if (Flag != null && isBoosting)
        {
            Flag.transform.Rotate(Vector3.up * flagRotationSpeed * Time.deltaTime);
        }

    }
}
