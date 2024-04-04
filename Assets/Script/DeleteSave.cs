using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{
   public void DeleteAllSave()
   {
        PlayerPrefs.DeleteAll();
   }
}
