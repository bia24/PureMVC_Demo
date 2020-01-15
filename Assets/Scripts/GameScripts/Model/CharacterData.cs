using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData{

    public string CharacterInfo { get; set; }
    public Texture2D CharacterImage { get; set; }

    public CharacterData()
    {
        TextAsset textFile= Resources.Load<TextAsset>("CharacterInfo");
        CharacterInfo = (textFile == null) ? "Null" : textFile.text;

        Texture2D imageFile = Resources.Load("CharacterImage") as Texture2D;
        if (imageFile == null) { throw new System.NullReferenceException("图片未加载成功"); }
        CharacterImage = imageFile;

    }
}
