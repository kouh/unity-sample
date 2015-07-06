using UnityEngine;
using System.Collections;

public class StageLoader : MonoBehaviour {

  private TextAsset textAsset;
  private GameObject block;
  private GameObject player;
  private GameObject enemy;
  private Vector3 spaceScale = new Vector3(0.5f,0.5f,0f);
  
  void Start () {
    textAsset = (TextAsset) Resources.Load("Map1");
    block     = (GameObject)Resources.Load("Block");
    player    = (GameObject)Resources.Load("Player");
    enemy     = (GameObject)Resources.Load("Enemy");
    
    CreateStage(new Vector3(0,0,0));
  }

  private void CreateStage(Vector3 originPos){

    GameObject stage = new GameObject("Stage");

    var pos = originPos;
    string stageTextData = textAsset.text;

    foreach(char c in stageTextData){

      GameObject obj = null;

      if(c == '#'){
        obj = Instantiate(block, pos, Quaternion.identity) as GameObject;
        obj.name = block.name;
        pos.x += obj.transform.lossyScale.x;
        obj.transform.parent = stage.transform;
      }else if(c == 'p'){
        obj = Instantiate(player, pos, Quaternion.identity) as GameObject;
        obj.name = player.name;
        pos.x += obj.transform.lossyScale.x;
        var camera = GameObject.Find("Camera");
        camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, camera.transform.position.z);
        camera.transform.parent = obj.transform;
      }else if(c == 'e'){
        obj = Instantiate(enemy, pos, Quaternion.identity) as GameObject;
        obj.name = enemy.name;
        pos.x += obj.transform.lossyScale.x;
      }else if(c == '\n'){
        pos.y -= spaceScale.y;
        pos.x = originPos.x;
      }else if(c == ' '){
        pos.x += spaceScale.x;
      }
    }
    
  }
}
