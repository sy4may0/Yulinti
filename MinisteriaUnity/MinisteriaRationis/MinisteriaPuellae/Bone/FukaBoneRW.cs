using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.Nucleus.InstrumentaMinisterii;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaBoneRW : IFukaBoneCommand, IFukaBoneQuery {
        private readonly FukaBoneService _fukaBoneService;
        public FukaBoneRW(FukaBoneService fukaBoneService) {
            if (fukaBoneService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaBoneRW)のFukaBoneServiceがnullです。");
            }
            _fukaBoneService = fukaBoneService;
        }

        public System.Numerics.Vector3 GetBonePosition(BoneID boneID) => InterpressNumericus.ToNumerics(_fukaBoneService.GetBonePosition(boneID));
        public System.Numerics.Quaternion GetBoneRotation(BoneID boneID) => InterpressNumericus.ToNumerics(_fukaBoneService.GetBoneRotation(boneID));
        public System.Numerics.Vector3 GetBoneScale(BoneID boneID) => InterpressNumericus.ToNumerics(_fukaBoneService.GetBoneScale(boneID));

        public void SetBonePosition(BoneID boneID, System.Numerics.Vector3 position) {
            _fukaBoneService.SetBonePosition(boneID, InterpressNumericus.ToUnity(position));
        }
        public void SetBoneRotation(BoneID boneID, System.Numerics.Quaternion rotation) {
            _fukaBoneService.SetBoneRotation(boneID, InterpressNumericus.ToUnity(rotation));
        }
        public void SetBoneScale(BoneID boneID, System.Numerics.Vector3 scale) {
            _fukaBoneService.SetBoneScale(boneID, InterpressNumericus.ToUnity(scale));
        }
    }
}