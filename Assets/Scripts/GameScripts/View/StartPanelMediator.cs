using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class StartPanelMediator : Mediator {

    private new const string NAME = "StartPanelMediator";

    private StartPanelView view;

    public StartPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        //view 引用绑定
        view = (ViewComponent as GameObject).GetComponent<StartPanelView>();
        
        //view上的事件绑定
        view.Button1.onClick.AddListener(onButton1Click);
        view.Button2.onClick.AddListener(onButton2Click);

        Debug.Log("StartPanelMediator  constructed");
    }
	

    //bussiness logic
    private void onButton1Click()
    {
        //按钮文字被改变
        view.ChangeButtonText(view.Button1,"我被按了");

        //给command发送通知
        string context = "这是按钮1被点击后显示的文字";
        SendNotification(MyFacade.CHANGE_CHARACTER_DATA, context);
        
    }
    private void onButton2Click()
    {
        //按钮文字被改变
        view.ChangeButtonText(view.Button2, "我被按了");

        //给command发送通知
        string context = "这是按钮2被点击后显示的文字";
        SendNotification(MyFacade.CHANGE_CHARACTER_DATA, context);
    }


    public override void OnRegister()
    {
        Debug.Log(NAME+" has been regist");
    }

    public override void OnRemove()
    {
        Debug.Log(NAME+" has been remove");
    }

}
