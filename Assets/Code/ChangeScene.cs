using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public int[] sceneIDs; // Array of scene IDs
   public void MoveToRandomScene()
   {
      // Check if there are scenes in the array
      if (sceneIDs.Length > 0)
      {
         // Choose a random scene from the array
         int randomIndex = Random.Range(0, sceneIDs.Length);
         int randomSceneID = sceneIDs[randomIndex];

         // Load the randomly selected scene
         SceneManager.LoadScene(randomSceneID);
      }
      else
      {
         Debug.LogWarning("No scenes available in the sceneIDs array.");
      }
   }
}