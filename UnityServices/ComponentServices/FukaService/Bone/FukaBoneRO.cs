using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.TranslateUtils;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaBoneRO : IFukaBoneQuery {
        private readonly FukaBoneService _fukaBoneService;

        public FukaBoneRO(FukaBoneService fukaBoneService) {
            if (fukaBoneService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaBoneService)のFukaBoneServiceがnullです。");
            }
            _fukaBoneService = fukaBoneService;
        }

        public System.Numerics.Vector3 GetBonePosition(BoneID boneID) => NumericsTranslate.ToNumerics(_fukaBoneService.GetBonePosition(boneID));
        public System.Numerics.Quaternion GetBoneRotation(BoneID boneID) => NumericsTranslate.ToNumerics(_fukaBoneService.GetBoneRotation(boneID));
        public System.Numerics.Vector3 GetBoneScale(BoneID boneID) => NumericsTranslate.ToNumerics(_fukaBoneService.GetBoneScale(boneID));
    }
}