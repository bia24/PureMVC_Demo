using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanelView : MonoBehaviour {

    private TextPanelMediator mediator;
    public RawImage image;
    public Text text;
    public Button button;

    private void Awake()
    {
        //ui控件赋值
        image = transform.Find("Image").GetComponent<RawImage>();
        text=transform.Find("Text").GetComponent<Text>();
        button = transform.Find("Button").GetComponent<Button>();

        //创建对应的mediator，并注册
        mediator = new TextPanelMediator(gameObject);
        MyFacade.Instance.RegisterMediator(mediator);

    }

    private void OnEnable()
    {
        //注册到facade中
       if(!MyFacade.Instance.HasMediator(mediator.MediatorName))
            MyFacade.Instance.RegisterMediator(mediator);
    }

    private void OnDisable()
    {
        //从注册表中删除
        if (MyFacade.Instance.HasMediator(mediator.MediatorName))
            MyFacade.Instance.RemoveMediator(mediator.MediatorName);
    }

   public TextPanelMediator Mediator
    {
        get { return mediator; }
    }

}
