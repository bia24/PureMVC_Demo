using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class StartGameCommand : SimpleCommand
{

    public override void Execute(INotification notification)
    {
        GameObject.Find("StartPanel").AddComponent<StartPanelView>();
    }

    
}
