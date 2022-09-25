using UnityEngine;
using UnityEngine.Events;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ItemsSorting
{
    public class First<TypeModel> : ScriptableObject, IStorable  where TypeModel : BaseModel, new()
    {
        [SerializeField] protected TypeModel _model;

        public UnityEvent OnLoad;
        public UnityEvent OnSave;


        public TypeModel Model
        {
            get;
            set;
        }

        public async Task<bool> Load()
        {
            if (File.Exists(GetStoregePath(name)) == false)
            {
                Debug.Log("non load missing file");
                return false;
            }

            TypeModel model = new TypeModel();
            var readedValue = await ReadFile(GetStoregePath(name));

            JsonUtility.FromJsonOverwrite(readedValue, model);

            Model.OnValueChange.RemoveAllListeners();

            Model = model;
            OnLoad.Invoke();
            return true;
        }

        private async Task<string> ReadFile(string path)
        {
            using (var stream = new StreamReader(path))
            {
               return await stream.ReadToEndAsync();
            }
        }

        public async Task<bool> Save()
        {
                string valueForSave = JsonUtility.ToJson(Model);
                return await SaveFile(GetStoregePath(name), valueForSave);
        }

        protected async Task<bool> SaveFile(string path, string content)
        {
            try
            {
                using (var stream = new StreamWriter(path))
                {
                    await stream.WriteLineAsync(content);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                return false;
            }
            OnSave.Invoke();
            return true;
        }

        protected static string GetStoregePath(string name)
        {
            return Application.persistentDataPath + Path.DirectorySeparatorChar + name + ".json";  
        }

    }
}
