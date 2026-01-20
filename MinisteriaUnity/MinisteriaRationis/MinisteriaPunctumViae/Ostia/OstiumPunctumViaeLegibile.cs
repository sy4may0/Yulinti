using System.Numerics;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPunctumViaeLegibile : IOstiumPunctumViaeLegibile {
        private readonly MinisteriumPunctumViae _miPunctumViae;

        public OstiumPunctumViaeLegibile(MinisteriumPunctumViae miPunctumViae) {
            _miPunctumViae = miPunctumViae;
        }

        public ErrorAut<IPunctumViaeLegibile> LegoTemere() {
            PunctumViae punctumViae = _miPunctumViae.LegoTemere();
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_ADITRIUM);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoVicinam(Vector3 positio) {
            PunctumViae punctumViae = _miPunctumViae.LegoVicinam(InterpressNumericus.ToUnity(positio));
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_ADITRIUM);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoCrematoriumTemere() {
            PunctumViae punctumViae = _miPunctumViae.LegoCrematoriumTemere();
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_CREMATORIUM);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoCrematoriumVicinam(Vector3 positio) {
            PunctumViae punctumViae = _miPunctumViae.LegoCrematoriumVicinam(InterpressNumericus.ToUnity(positio));
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_CREMATORIUM);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoNatoriumTemere() {
            PunctumViae punctumViae = _miPunctumViae.LegoNatoriumTemere();
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_NATORIUM);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoNatoriumVicinam(Vector3 positio) {
            PunctumViae punctumViae = _miPunctumViae.LegoNatoriumVicinam(InterpressNumericus.ToUnity(positio));
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_NATORIUM);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoTypumTemere(IDPunctumViaeTypi typus) {
            PunctumViae punctumViae = _miPunctumViae.LegoTypumTemere(typus);
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_POINT);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }

        public ErrorAut<IPunctumViaeLegibile> LegoTypumVicinam(IDPunctumViaeTypi typus, Vector3 positio) {
            PunctumViae punctumViae = _miPunctumViae.LegoTypumVicinam(typus, InterpressNumericus.ToUnity(positio));
            if (punctumViae == null) {
                return ErrorAut<IPunctumViaeLegibile>.Error(IDErrorum.MINISTERIUMPUNCTUMVIAE_NO_ACTIVE_POINT);
            }
            return ErrorAut<IPunctumViaeLegibile>.Successus(_miPunctumViae.LegoOstium(punctumViae.ID));
        }
    }
}