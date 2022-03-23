using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //https://qiita.com/keito_takaishi/items/60d6be6de69edc504f39
    [SerializeField] private Transform PlayerModel;
    public float yAngle
    {
        set;get;
    }
    const float yAngleMin = 0;
    const float yAngleMax = 360;
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion quaternion = this.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = PlayerModel.position;
        yAngle = ModCalc(yAngle);
        this.transform.rotation = Quaternion.Euler(0, yAngle, 0);
        PlayerModel.rotation  = Quaternion.Euler(0, yAngle, 0);
    }

    private float ModCalc(float yAngle)
    {
        while (yAngle < yAngleMin)
        {
            yAngle += yAngleMax;
        }
        yAngle = yAngle % yAngleMax;
        return yAngle;
    }

    public void SetYAngle()
    {

    }
}
