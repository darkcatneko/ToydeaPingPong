using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
public class AddressableSearcher : ToSingletonMonoBehavior<AddressableSearcher>
{
    public async Task<T> GetAddressableAsset<T>(string assetAddress)
    {
        var resultTask = Addressables.LoadAssetAsync<T>(assetAddress).Task;
        T result = await resultTask;
        return result;
    }

}
