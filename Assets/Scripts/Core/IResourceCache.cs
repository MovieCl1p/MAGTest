using Core.UI;
using Game.Config;
using Game.Service;
using Match3Logic;
using UnityEngine;

namespace Core
{
    public interface IResourceCache : IService
    {
        PrefabReferencesConfig PrefabConfig { get; }
        
        GameConfig GameConfig { get; }

        T GetView<T>() where T : BaseView;
    }
}