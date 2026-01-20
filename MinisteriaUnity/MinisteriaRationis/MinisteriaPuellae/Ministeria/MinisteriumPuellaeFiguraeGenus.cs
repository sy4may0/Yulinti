using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFiguraeGenus {
        private readonly SkinnedMeshRenderer _pedisDex;
        private readonly TabulaPuellaeFiguraeGenus _tabulaDex;
        private readonly SkinnedMeshRenderer _pedisSin;
        private readonly TabulaPuellaeFiguraeGenus _tabulaSin;

        public MinisteriumPuellaeFiguraeGenus(
            IConfiguratioPuellaeFiguraeGenusDexter configDex, 
            IConfiguratioPuellaeFiguraeGenusSinister configSin,
            IAnchoraPuellae anchora
        ) {
            _pedisDex = anchora.FiguraPedisDexter;
            _tabulaDex = new TabulaPuellaeFiguraeGenus(configDex, _pedisDex);
            _pedisSin = anchora.FiguraPedisSinister;
            _tabulaSin = new TabulaPuellaeFiguraeGenus(configSin, _pedisSin);
        }

        public float LegoPondusSinister(IDPuellaeFiguraeGenus idFiguraeGenus) {
            int index = _tabulaSin.Lego(idFiguraeGenus);
            return _pedisSin.GetBlendShapeWeight(index);
        }

        public void PonoPondusSinister(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus) {
            int index = _tabulaSin.Lego(idFiguraeGenus);
            _pedisSin.SetBlendShapeWeight(index, pondus);
        }

        public float LegoPondusDexter(IDPuellaeFiguraeGenus idFiguraeGenus) {
            int index = _tabulaDex.Lego(idFiguraeGenus);
            return _pedisDex.GetBlendShapeWeight(index);
        }

        public void PonoPondusDexter(IDPuellaeFiguraeGenus idFiguraeGenus, float pondus) {
            int index = _tabulaDex.Lego(idFiguraeGenus);
            _pedisDex.SetBlendShapeWeight(index, pondus);
        }
    }
}


