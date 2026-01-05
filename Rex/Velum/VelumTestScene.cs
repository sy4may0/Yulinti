using UnityEngine;
using VContainer;
using Yulinti.Velum.ContractusVeli;

public sealed class VelumTestScene : MonoBehaviour {
    private IVelumIndicia _velumIndicia;

    [Inject]
    public void Construct(IVelumIndicia velumIndicia) {
        _velumIndicia = velumIndicia;
    }

    private void OnGUI() {
        _velumIndicia?.AdIndicium();
    }
}