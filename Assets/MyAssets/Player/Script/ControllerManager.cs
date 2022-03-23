using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager: MonoBehaviour
{
    [SerializeField]private CameraMove CameraMove;

    [SerializeField] private PlayerMove PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            CameraMove.yAngle -= 4;
        }
        if (Input.GetKey(KeyCode.E))
        {
            CameraMove.yAngle += 4;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            //PlayerMove.MoveStraight();
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            //PlayerMove.MoveStraight();
        }
    }
}
