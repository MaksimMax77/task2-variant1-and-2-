using UnityEngine;
using Zenject;

namespace Sources.Variant3.SceneSibling
{
    public class RootObjectsCreator
    {
        private const string _newGameObjectRootName = "new_game_objects";
        private GameObject _rootObj;

        public GameObject RootObj => _rootObj;
        
        [Inject]
        public void Create()
        {
            _rootObj = CreateObj(_newGameObjectRootName);
        }

        public GameObject AddNewObjectToRoot(string name)
        {
            var obj = CreateObj(name);
            obj.transform.SetParent(_rootObj.transform);
            return obj;
        }
        
        public GameObject CreateGameObjectWithChild(string rootName, params string[] childNames)
        {
            var root = CreateObj(rootName);
            
            foreach (var name in childNames)
            {
                CreateObj(name).transform.SetParent(root.transform);
            }

            return root;
        }
        
        private GameObject CreateObj(string name)
        {
            return new GameObject(name);
        }
    }
}
