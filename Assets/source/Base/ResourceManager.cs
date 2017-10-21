using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : PSingleton<ResourceManager>
{
    public const string PROP_PATH_NAME = "Prefab/";
   
    // cache:
    protected Dictionary<string, GameObject> abObject = new Dictionary<string, GameObject>(); 

    public AsyncOperation LoadSceneAsync(string name, bool isFromAB)
    {
       
        AsyncOperation isDone = Application.LoadLevelAsync(name );
        return isDone;
    }


    public void LoadScene(string name)
    {
        Application.LoadLevel(name);
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

//    public IEnumerator GetPrefabAsyn(string name, Action<GameObject> callback)
//    {
//        name = PROP_PATH_NAME + name;
//       yield return GetAssetAsyn<GameObject>(name, callback);
//    }
//
//
//
//    public AnimationClip GetAnimationClip(string animationName)
//    {
//        
//        animationName = ANIMATION_CLIP_NAME + animationName;
//        var clip = GetAsset<AnimationClip>(animationName);
//        return clip;
//    }
//
//
//    public GameObject GetAnimalModel(string name)
//    {
//        name = "Model/" + name;
//        var model = GetAsset<GameObject>(name);
//        return model;
//    }
//
//    public GameObject GetEffect(string name)
//    {
//        name = "Effect/" + name;
//        var model = GetAsset<GameObject>(name);
//        return model;
//    }
//
//    public AudioClip GetAudio(string name)
//    {
//        name = "Audio/" + name;
//        return GetAsset<AudioClip>(name);
//    }
//
//    public AudioClip GetRiskAudio(int storyId,string name)
//    {
//    	name = "Audio/Risk/" +"Story"+storyId +"/" + name;
//    	return GetAsset<AudioClip>(name);
//    }
//
//    public GameObject GetABObject(string filename)
//    {
//        GameObject obj;
//        if(abObject.TryGetValue(filename, out obj))
//        {
//            return obj;
//        }
//        string assetName;
//        string abName;
//        GetAssetName(filename, out assetName, out abName);
//        AssetBundle bundle = FileUtility.GetAssetBundle(abName);
//        obj = bundle.LoadAsset<GameObject>(assetName);
//        abObject[filename] = obj;
//        bundle.Unload(false);
//       return obj;
//    }
//
//
//    public static bool GetAssetName(string name, out string assetName , out string abName)
//    {
//        int index = name.LastIndexOf('@');
//        assetName = name;
//        bool ret = index != -1 && index != 0 && index != (name.Length-1);
//        if(ret)
//        {
//            //assetName = name.Substring(index);    
//            abName = name.Substring(0, index);
//        }else
//        {
//            abName = name;
//        }
//        Debug.Log(assetName + "--- " + abName);
//        return ret;
//    } 


}
