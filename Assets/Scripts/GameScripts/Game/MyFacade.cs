using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class MyFacade:Facade{

    #region 定义Notifaction常量
    public const string START_UP_GAME = "start_up_game";
    public const string CHANGE_VIEW_CHARACATER_INFO = "change_view_character_info";
    public const string CHANGE_CHARACTER_DATA = "change_character_data";
    #endregion

    //单例类获取
    private static MyFacade instance;
    private static object singletonLock = new object();
    public new static MyFacade Instance
    {
        get
        {
            if (instance == null)
            {
                lock (singletonLock)
                {
                    if(instance == null)
                        instance = new MyFacade();
                }
            }
            return instance;
        }
    }


    //父类按照model、controller、view的顺序初始化

    //重写model初始化函数
    protected override void InitializeModel()
    {
        base.InitializeModel();

        //proxy注册
        RegisterProxy(new CharacterDataProxy());
    }

    //重写controller初始化函数
    protected override void InitializeController()
    {
        base.InitializeController();

        //Notifaction和命令绑定
        RegisterCommand(START_UP_GAME,typeof(StartGameCommand));
        RegisterCommand(CHANGE_CHARACTER_DATA, typeof(ChangeDataCommand));
    }

    //重写view初始化函数
    protected override void InitializeView()
    {
        base.InitializeView();
    }
    
    //Game启动方法
    public void Launch()
    {
        SendNotification(START_UP_GAME);
    }
    

}
