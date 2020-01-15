using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class CharacterDataProxy : Proxy {

    public new const string NAME = "CharacterDataProxy";

    public CharacterDataProxy():base(NAME,new CharacterData())
    {
    }

    public void ChangeData(string context)
    {
        CharacterData data = Data as CharacterData;
        data.CharacterInfo = context;
        Data = data;
        //发送通知 
        SendNotification(MyFacade.CHANGE_VIEW_CHARACATER_INFO, Data);
    }

}
