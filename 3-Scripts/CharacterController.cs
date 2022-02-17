using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] [Range(0, 10f)] private float MoveSpeed = 3f;
    [SerializeField] [Range(0, 10f)] private float JumpPower = 5f;

    private CameraController camControllerReference;
    private Rigidbody playerRb;
    private Transform playerTrans;
    private float Vertical;
    private float Horizontal;

    private bool isjumped = false;
    void Start()
    {
        camControllerReference = GetComponent<CameraController>();
        playerRb = GetComponent<Rigidbody>();
        playerTrans = GetComponent<Transform>();
    }

   
    void Update()
    {
        Vertical = Input.GetAxis("Vertical") * MoveSpeed;
        Horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
        MoveIt();
    }
    
    private void MoveIt()
    {
        Vector3 movement = camControllerReference.camera.transform.right * Horizontal + playerTrans.forward * Vertical;
        playerTrans.position += movement * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !isjumped)
        {
            isjumped = true;
            playerRb.AddForce(Vector3.up * playerRb.mass * JumpPower, ForceMode.Impulse);
            StartCoroutine(JumpCooldown());
        }

    }
    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(2f);
        isjumped = false;
    }
}
