using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class TextPanelMediator : Mediator{

    public new const string NAME = "TextPanelMediator";

    private TextPanelView view;

    private CharacterDataProxy proxy;


    public TextPanelMediator(object viewComponent):base(NAME,viewComponent)
    {
        //view 引用获得
        view = (ViewComponent as GameObject).GetComponent<TextPanelView>();
        //proxy引用获得，用于初始化view中的内容
        proxy = MyFacade.Instance.RetrieveProxy("CharacterDataProxy") as CharacterDataProxy;
        //UI控件事件绑定
        view.button.onClick.AddListener(OnCancelButtonClick);

        //view 中UI内容初始化函数
        InitViewContext(proxy);

        Debug.Log("TextPanelMediator constructed");
    }

    //返回感兴趣的notifaction，会依据此创建一个关于本mediator的观察者对象
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>
        {
            MyFacade.CHANGE_VIEW_CHARACATER_INFO
        };
    }

    //作为观察者需要处理的方法
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case MyFacade.CHANGE_VIEW_CHARACATER_INFO:
                view.text.text= notification.Body as string;
                break;
        }
    }

    //舒适化面板内容    暂时没用
    private void InitViewContext(CharacterDataProxy proxy)
    {
        CharacterData data = proxy.Data as CharacterData;
        view.image.texture= data.CharacterImage;
        view.text.text = data.CharacterInfo;
    }

    public void UpdateViewContext(INotification notification)
    {
        view.text.text = notification.Body as string;
    }

    public bool IsViewActive()
    {
        return view.gameObject.activeInHierarchy;
    }

    public void SetViewActive(bool value)
    {
        view.gameObject.SetActive(value);
    }

    //取消按钮被点击
    private void OnCancelButtonClick()
    {
        view.gameObject.SetActive(false);
    }

    public override void OnRegister()
    {
        Debug.Log(NAME+" has been regist");
    }

    public override void OnRemove()
    {
        Debug.Log(NAME + " has been remove");
    }
}
