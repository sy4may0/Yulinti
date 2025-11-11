using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.InstrumentaMinisterii;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaBoneRO : IFukaBoneQuery {
        private readonly FukaBoneService _fukaBoneService;

        public FukaBoneRO(FukaBoneService fukaBoneService) {
            if (fukaBoneService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaBoneService)のFukaBoneServiceがnullです。");
            }
            _fukaBoneService = fukaBoneService;
        }

        public System.Numerics.Vector3 GetBonePosition(BoneID boneID) => InterpressNumericus.ToNumerics(_fukaBoneService.GetBonePosition(boneID));
        public System.Numerics.Quaternion GetBoneRotation(BoneID boneID) => InterpressNumericus.ToNumerics(_fukaBoneService.GetBoneRotation(boneID));
        public System.Numerics.Vector3 GetBoneScale(BoneID boneID) => InterpressNumericus.ToNumerics(_fukaBoneService.GetBoneScale(boneID));
    }
}