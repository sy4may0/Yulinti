using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamiPuellaeCorporis {
        private readonly ThesaurusPuellaeStatuum _thesaurus;
        private readonly TabulaPuellaeThesaurusCorporis _tabulaThesauri;
        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;

        public RamiPuellaeCorporis(
            ThesaurusPuellaeStatuum thesaurus,
            TabulaPuellaeThesaurusCorporis tabulaThesauri,
            IOstiumInputMotusLegibile osInputMotusLeg
        ) {
            _thesaurus = thesaurus;
            _tabulaThesauri = tabulaThesauri;
            _osInputMotusLeg = osInputMotusLeg;
        }

        // Cursusが押されているかどうかを判定する
        public bool EstActivumCursus(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            if (
                _osInputMotusLeg.LegoMotus.LengthSquared() >= _thesaurus.LimenInputQuadratum &&
                _osInputMotusLeg.LegoCursus
            ) {
                return true;
            }
            return false;
        }

        // Cursusが押されていないかどうかを判定する
        public bool EstInactivumCursus(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            if (
                _osInputMotusLeg.LegoMotus.LengthSquared() < _thesaurus.LimenInputQuadratum ||
                !_osInputMotusLeg.LegoCursus
            ) {
                return true;
            }
            return false;
        }

        // Incumboが押されているかどうかを判定する
        public bool EstActivumIncumbo(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            if (
                _osInputMotusLeg.LegoIncumbo
            ) {
                return true;
            }
            return false;
        }

        // Incumboが押されていないかどうかを判定する
        public bool EstInactivumIncumbo(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            if (
                !_osInputMotusLeg.LegoIncumbo
            ) {
                return true;
            }
            return false;
        }

        // Incumboが押されていて、移動しているか判定する。
        public bool EstActivumIncumboMotus(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            return EstActivumIncumbo(resFluidaMotus) && EstActivumMotus(resFluidaMotus);
        }
        
        // Incumboが押されていて、移動していないか判定する。
        public bool EstInactivumIncumboMotus(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            return EstActivumIncumbo(resFluidaMotus) && EstInactivumMotus(resFluidaMotus);
        }

        // 移動入力があるかどうかを判定する
        public bool EstActivumMotus(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            if (_osInputMotusLeg.LegoMotus.LengthSquared() >= _thesaurus.LimenInputQuadratum) {
                return true;
            }
            return false;
        }

        // 移動入力がないかどうかを判定する
        public bool EstInactivumMotus(IResFluidaPuellaeMotusLegibile resFluidaMotus) {
            if (_osInputMotusLeg.LegoMotus.LengthSquared() < _thesaurus.LimenInputQuadratum) {
                return true;
            }
            return false;
        }
    }
}