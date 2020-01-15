using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelView : MonoBehaviour {

    private StartPanelMediator mediator;
    public Button Button1;
    public Button Button2;
    

    private void Awake()
    {
        //panel内UI控件引用获取
        Button1 = transform.Find("Button1").GetComponent<Button>();
        Button2 = transform.Find("Button2").GetComponent<Button>();
    }

    private void OnEnable()
    {
        //创建对应的mediator，并注册到facade中
        if (mediator == null)
            mediator = new StartPanelMediator(gameObject);
        MyFacade.Instance.RegisterMediator(mediator);
    }

    private void OnDisable()
    {
        //将mediator从注册表中删除
        if(mediator!=null)
            MyFacade.Instance.RemoveMediator(mediator.MediatorName);
    }


    public void ChangeButtonText(Button btn,string text)
    {
        Text t = btn.GetComponentInChildren<Text>();
        t.text = text;
        t.color = Color.red;
    }

    

}
