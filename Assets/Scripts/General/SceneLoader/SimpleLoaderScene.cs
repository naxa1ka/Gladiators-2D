using UnityEngine.SceneManagement;

public class SimpleLoaderScene : LoaderScene
{
    public void Load(int sceneId)
    {
        TimeState.Resume();
        
        var asyncOperation = SceneManager.LoadSceneAsync(sceneId);

        LoadScene(asyncOperation);
    }

    public void Load(ScenesID sceneId)
    {
        Load((int) sceneId);
    }
}