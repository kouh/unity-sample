using UnityEngine;
using System.Collections;

public class StageLoader : MonoBehaviour {

  public TextAsset textAsset;

  //配置するオブジェクト
  // public GameObject block;
  public GameObject player;

  public Vector3 createPos;

  public Vector3 spaceScale = new Vector3(1.0f,1.0f,0f);
  private GameObject block;
  void Start () {
    // プレハブを取得
    block = (GameObject)Resources.Load ("Block");
    // createPos = Vector3.zero;
    for (int y = 0; y < 5; y++) {
      for (int x = 0; x < 5; x++) {
        Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
      }
    }
  }


  void CreateStage(Vector3 pos){

    GameObject stage = new GameObject("Stage");

    Vector3 originPos = pos;
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
        obj.transform.parent = stage.transform;
      }else if(c == '\n'){
        pos.y -= spaceScale.y;
        pos.x = originPos.x;
      }else if(c == ' '){
        pos.x += spaceScale.x;
      }
    }
  }
}
