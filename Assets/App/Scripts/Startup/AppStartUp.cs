using TinaX;
using TinaX.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Nekonya.CorAdventure
{
    public class AppStartUp : MonoBehaviour
    {
        // Start is called before the first frame update
        private async void Start()
        {
            var core = XCore.New().
            UseVFS().
            UseUIKit().
            UseI18N().
            OnServicesStartException((service, err) =>
            {
                
            });
            await core.RunAsync();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        #if UNITY_EDITOR
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            public static void OnGameStart()
            {
                var cur_scene = SceneManager.GetActiveScene();
                if (!cur_scene.name.Equals("App.Startup") && (cur_scene.name.StartsWith("App.") || cur_scene.name.IsNullOrEmpty()))
                    SceneManager.LoadScene("App.Startup");
            }
        #endif
    }
}
