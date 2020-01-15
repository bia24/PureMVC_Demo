using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    private void Awake()
    {
        //pureMVC启动
        MyFacade.Instance.Launch();

    }

}
