using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeFigurae {
        private readonly MinisteriumPuellaeFiguraePelvis _pelvis;
        private readonly MinisteriumPuellaeFiguraeGenus _genusDexter;
        private readonly MinisteriumPuellaeFiguraeGenus _genusSinister;

        public MinisteriumPuellaeFigurae(
            IConfiguratioPuellaeFigurae config,
            IAnchoraPuellae anchora
        ) {
            _pelvis = new MinisteriumPuellaeFiguraePelvis(config.Pelvis, anchora.FiguraPelvis);
            _genusDexter = new MinisteriumPuellaeFiguraeGenus(config.GenusDex, anchora.FiguraPedisDexter);
            _genusSinister = new MinisteriumPuellaeFiguraeGenus(config.GenusSin, anchora.FiguraPedisSinister);
        }

        public MinisteriumPuellaeFiguraePelvis Pelvis => _pelvis;
        public MinisteriumPuellaeFiguraeGenus GenusDex => _genusDexter;
        public MinisteriumPuellaeFiguraeGenus GenusSin => _genusSinister;
    }
}


