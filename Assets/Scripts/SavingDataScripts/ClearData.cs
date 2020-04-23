using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ClearData : MonoBehaviour
{
    public void ClearSave()
    {
        string path = Application.persistentDataPath + "/player.hope";
        FileStream stream = new FileStream(path, FileMode.Create);
    }
}
