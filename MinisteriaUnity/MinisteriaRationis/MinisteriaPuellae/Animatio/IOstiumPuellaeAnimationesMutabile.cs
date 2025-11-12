using System;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeAnimationesMutabile {
        void PostulareFundamenti(FukaBaseLayerAnimationID baseLayerAnimationID, Action fInvocanda, bool estObsignatus = false);
        void CogereFundamenti(FukaBaseLayerAnimationID baseLayerAnimationID, Action fInvocanda, bool estObsignatus = false);
        void PostulareCorporisToti(FukaActionLayerAnimationID actionLayerAnimationID, Action fInvocanda, bool estObsignatus = false);
        void CogereCorporisToti(FukaActionLayerAnimationID actionLayerAnimationID, Action fInvocanda, bool estObsignatus = false);
        void CogereDesinentiamFundamenti();
        void CogereDesinentiamCorporisToti();
        void TemporareLuditores();
        void InjicereVelocitatem(float vel);
    }
}