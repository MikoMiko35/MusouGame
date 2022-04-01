using KanKikuchi.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	//lab.net/2017/05/unity%E3%81%A7%E3%82%AD%E3%83%A3%E3%83%A9%E3%82%AF%E3%82%BF%E3%83%BC%E3%82%92%E7%A7%BB%E5%8B%95%E3%81%95%E3%81%9B%E3%82%8B%E6%96%B9%E6%B3%95%E3%80%903d%E7%B7%A8%E3%80%91/#move_charactorcontroller
	public float speed = 3.0f;
	public float gravity = 9.81f;

	private Vector3 moveDirection = Vector3.zero;

	CharacterController controller;

	[SerializeField]GameObject PlayerModel;

	[SerializeField] ControllerManager cm;

	[SerializeField] HPGauge hpgauge;

	float hp = 10;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{

		if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) || (cm.PlayerMoveRightButton || cm.PlayerMoveLeftButton || cm.PlayerMoveForwardButton || cm.PlayerMoveBackwardButton))
		{
			PlayerModel.GetComponent<Animator>().SetBool("Move", true);
			if (controller.isGrounded)
			{
#if UNITY_EDITOR
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
#else
				moveDirection = new Vector3((cm.PlayerMoveRightButton ? 1 : 0) + (cm.PlayerMoveLeftButton ? -1 : 0), 0, (cm.PlayerMoveForwardButton ? 1 : 0) + (cm.PlayerMoveBackwardButton ? -1 : 0));
#endif   
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
			}
		}
		else
		{
			PlayerModel.GetComponent<Animator>().SetBool("Move", false);
			moveDirection = new Vector3(0,0,0);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	public void Damaged(Vector3 enemyPos)
	{
		SEManager.Instance.Play(SEPath.SYSTEM26);
		//Debug.Log("HP"+hp);
		hp--;
		moveDirection = new Vector3(this.transform.position.x - enemyPos.x, 0, this.transform.position.z - enemyPos.z);
		controller.Move(moveDirection.normalized * 0.1f);
		hpgauge.HPChange(hp/30);
		if (hp < 0)
		{
			SceneChanger.Instance.ChangeGameOver();
			Destroy(this.gameObject);
		}
	}
}