using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class ChangeDataCommand : SimpleCommand{

    private GameObject textPanel;
    private TextPanelMediator mediator;

    public override void Execute(INotification notification)
    {

        mediator = MyFacade.Instance.RetrieveMediator("TextPanelMediator") as TextPanelMediator;

        if (mediator == null)
        {
            if (!HasViewExits(ref textPanel))
            {
                //还未创建TextPanelView
                textPanel.AddComponent<TextPanelView>();
            }
            //获得该view对应的mediator
            mediator = textPanel.GetComponent<TextPanelView>().Mediator;
        }

        if (!mediator.IsViewActive())
            mediator.SetViewActive(true);

        //将内容更新至view组件
        mediator.UpdateViewContext(notification);
    }

    private bool HasViewExits(ref GameObject textPanel)
    {
        
        textPanel = GameObject.Find("Canvas").transform.Find("TextPanel").gameObject;
        
        if (textPanel.GetComponent<TextPanelView>() != null)
            return true;
        else
            return false;
    }

}
