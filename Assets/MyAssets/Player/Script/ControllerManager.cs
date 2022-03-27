using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager: MonoBehaviour
{
    [SerializeField]private CameraMove CameraMove;

    [SerializeField] private PlayerMove PlayerMove;
    [SerializeField] PlayerAttack playerAttack;

    public bool CameraTurnRightButton = false;
    public bool CameraTurnLeftButton = false;
    public bool PlayerMoveRightButton = false;
    public bool PlayerMoveLeftButton = false;
    public bool PlayerMoveForwardButton = false;
    public bool PlayerMoveBackwardButton = false;
    public bool PlayerAttackButton = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || CameraTurnLeftButton)
        {
            CameraMove.yAngle -= 4;
        }
        if (Input.GetKey(KeyCode.E) || CameraTurnRightButton)
        {
            CameraMove.yAngle += 4;
        }
    }

    public void CameraTurnRightButtonDown()
    {
        CameraTurnRightButton = true;
    }
    public void CameraTurnRightButtonUp()
    {
        CameraTurnRightButton = false;
    }
    public void CameraTurnLeftButtonDown()
    {
        CameraTurnLeftButton = true;
    }
    public void CameraTurnLeftButtonUp()
    {
        CameraTurnLeftButton = false;
    }


    public void PlayerMoveRightButtonDown()
    {
        PlayerMoveRightButton = true;
    }
    public void PlayerMoveRightButtonUp()
    {
        PlayerMoveRightButton = false ;
    }
    public void PlayerMoveLeftButtonDown()
    {
        PlayerMoveLeftButton = true;
    }
    public void PlayerMoveLeftButtonUp()
    {
        PlayerMoveLeftButton = false;
    }
    public void PlayerMoveForwardButtonDown()
    {
        PlayerMoveForwardButton = true;
    }
    public void PlayerMoveForwardButtonUp()
    {
        PlayerMoveForwardButton = false;
    }
    public void PlayerMoveBackwardButtonDown()
    {
        PlayerMoveBackwardButton = true;
    }
    public void PlayerMoveBackwardButtonUp()
    {
        PlayerMoveBackwardButton = false;
    }
    public void PlayerAttackButtonDown()
    {
        playerAttack.StartCoroutine("Attack");
    }

}
