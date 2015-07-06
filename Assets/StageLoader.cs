using UnityEngine;
using System.Collections;

public class StageLoader : MonoBehaviour {

  private TextAsset textAsset;

  //配置するオブジェクト
  // public GameObject block;
  private GameObject player;

  public Vector3 createPos;

  private Vector3 spaceScale = new Vector3(0.5f,0.5f,0f);
  private GameObject block;
  void Start () {
    //マップデータ取得
    textAsset = (TextAsset)Resources.Load ("Map1");
    // プレハブを取得
    block = (GameObject)Resources.Load ("Block");
    player = (GameObject)Resources.Load ("Player");
    CreateStage(new Vector3(0,0,0));
    // createPos = Vector3.zero;
    // for (int y = 0; y < 5; y++) {
    //   for (int x = 0; x < 5; x++) {
    //     GameObject obj = Instantiate(block, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
    //     obj.name = block.name;
    //     obj.transform.parent = this.transform;
    //   }
    // }
  }


  private void CreateStage(Vector3 pos){

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
        // obj.transform.parent = stage.transform;

        var camera = GameObject.Find("Camera");
        camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, camera.transform.position.z);
        camera.transform.parent = obj.transform;
      }else if(c == '\n'){
        pos.y -= spaceScale.y;
        pos.x = originPos.x;
      }else if(c == ' '){
        pos.x += spaceScale.x;
      }
    }
    
  }
}
