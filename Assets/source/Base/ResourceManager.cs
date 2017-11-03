using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : PSingleton<ResourceManager>
{
    public const string PROP_PATH_NAME = "Prefab/";
    public const string SPRITE_PATH_NAME = "Sprite/";
   
    // cache:
    protected Dictionary<string, GameObject> abObject = new Dictionary<string, GameObject>(); 

    public AsyncOperation LoadSceneAsync(string name, bool isFromAB)
    {
       
        AsyncOperation isDone = Application.LoadLevelAsync(name );
        return isDone;
    }

     public T GetAsset<T>(string name) where T : UnityEngine.Object
    {
        T ret = Resources.Load(name) as T;
        return ret;
    }

    public IEnumerator GetAssetAsyn<T>(string name, Action<T> callback) where T: UnityEngine.Object
    {
       
        var request = Resources.LoadAsync(name, typeof(T));
        while(!request.isDone)
        {
            yield return null;
        }
        if(callback != null)
        {
            callback(request.asset as T);
        }
        yield return null;
    }

    public GameObject GetPrefab(string name)
    {
        name = PROP_PATH_NAME + name;
        return GetAsset<GameObject>(name);
    }

    public Sprite GetSprite(string name)
    {
        name = SPRITE_PATH_NAME + name;
        return GetAsset<GameObject>(name).GetComponent<SpriteRenderer>().sprite;
    }
}
