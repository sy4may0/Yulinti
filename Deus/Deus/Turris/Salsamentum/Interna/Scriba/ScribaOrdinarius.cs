using System.IO;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Yulinti.Deus {
    internal sealed class ScribaOrdinarius : IScriba {
        public void Scribere(
            string json, string jsonPath, string tmpPath
        ) {
            string tmpUnique = tmpPath + "_" + Guid.NewGuid();
    
            File.WriteAllText(tmpUnique, json);
    
            if (File.Exists(jsonPath))
                File.Replace(tmpUnique, jsonPath, null);
            else
                File.Move(tmpUnique, jsonPath);
        }
    
        public async Task ScribereAsync(
            string json, string jsonPath, string tmpPath, CancellationToken ct
        ) {
            string tmpUnique = tmpPath + "_" + Guid.NewGuid();
    
            await File.WriteAllTextAsync(tmpUnique, json, ct);
    
            if (File.Exists(jsonPath))
                File.Replace(tmpUnique, jsonPath, null);
            else
                File.Move(tmpUnique, jsonPath);
        }
    
        public string Legere(string jsonPath) {
            return File.ReadAllText(jsonPath);
        }
    
        public void Delere(string jsonPath, string tmpPath) {
            if (File.Exists(jsonPath))
                File.Delete(jsonPath);
    
            string dir = Path.GetDirectoryName(tmpPath);
            string pattern = Path.GetFileName(tmpPath) + "_*";
    
            foreach (var f in Directory.GetFiles(dir, pattern))
                File.Delete(f);
        }

        public void Deplace(string srcPath, string dstPath) {
            if (File.Exists(dstPath))
                File.Delete(dstPath);
            File.Move(srcPath, dstPath);
        }
    }
}