using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HandleStub))]
[CanEditMultipleObjects]
public class CreationHandleEditor : Editor
{

    private KeyCode CurrentTile = KeyCode.None;
    private GameObject TileToLay;

    public void OnSceneGUI()
    {
        HandleStub stub = target as HandleStub;
        if (stub.SpriteRenderer == null)
        {
            // set it
            stub.SpriteRenderer = stub.GetComponent<SpriteRenderer>();
        }
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            if (e.keyCode == KeyCode.Alpha1)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile1.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile1;
                }                
            } else if (e.keyCode == KeyCode.Alpha3)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile2.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile2;
                }
            }
            else if (e.keyCode == KeyCode.Alpha4)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile3.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile3;
                }
            }
            else if (e.keyCode == KeyCode.Alpha5)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile4.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile4;
                }
            }
            else if (e.keyCode == KeyCode.Alpha6)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile5.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile5;
                }
            }
            else if (e.keyCode == KeyCode.Alpha7)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile6.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile6;
                }
            }
            else if (e.keyCode == KeyCode.Alpha8)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile7.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile7;
                }
            }
            else if (e.keyCode == KeyCode.Alpha9)
            {
                // check if it is the same as last
                if (e.keyCode != CurrentTile)
                {
                    // not same, set preview and return
                    // get sprite
                    stub.SpriteRenderer.sprite = stub.Tile8.GetComponentInChildren<SpriteRenderer>().sprite;
                    CurrentTile = e.keyCode;
                    e.Use();
                    TileToLay = stub.Tile8;
                }
            }
        } else if (e.type == EventType.MouseDown)
        {
            if (e.button == 1 && TileToLay != null)
            {
                // current tile
                // get current pos to nearest int
                Vector3 pos = new Vector3(Mathf.RoundToInt(stub.transform.position.x + 0.5f) - 0.5f, Mathf.RoundToInt(stub.transform.position.y + 0.5f) - 0.5f, 0);
                var name = "X" + pos.x + "Y" + pos.y;
                // check if tile already exists there
                if (stub.Parent.transform.Find(name))
                {
                    // do nothing
                    e.Use();
                    return;
                }
                GameObject o = Instantiate(TileToLay, pos, TileToLay.transform.rotation) as GameObject;
                o.name = name;
                o.transform.SetParent(stub.Parent.transform);
                Undo.RegisterCreatedObjectUndo(o, "Created " + o.name);
                Undo.IncrementCurrentGroup();
                e.Use();
            }
        }
    }
}
