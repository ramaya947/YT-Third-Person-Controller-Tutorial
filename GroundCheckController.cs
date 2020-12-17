using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckController : MonoBehaviour
{
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        string colLayer = LayerMask.LayerToName(c.gameObject.layer);
        if (colLayer.CompareTo("Ground") == 0 && !isGrounded)
            isGrounded = true;
    }

    void OnTriggerExit(Collider c)
    {
        string colLayer = LayerMask.LayerToName(c.gameObject.layer);
        if (colLayer.CompareTo("Ground") == 0)
        {
            if (isGrounded)
            {
                isGrounded = false;
            }
        }
    }

    void OnTriggerStay(Collider c)
    {
        string colLayer = LayerMask.LayerToName(c.gameObject.layer);
        if (colLayer.CompareTo("Ground") == 0 && !isGrounded)
            isGrounded = true;
    }

    public bool getIsGrounded()
    {
        return isGrounded;
    }

    public void setIsGrounded(bool value)
    {
        isGrounded = value;
    }
}
