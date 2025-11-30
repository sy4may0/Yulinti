using Yulinti.MinisteriaUnity.ConfiguratioDucis;

namespace Yulinti.Dux.Thesaurus {
    public sealed class FasciculusThesaurorumPuellae {
        public ThesaurusPuellaeInTerrae InTerrae { get; set; } = new ThesaurusPuellaeInTerrae();
        public FasciculusThesaurorumPuellaeStatus Status { get; set; } = new FasciculusThesaurorumPuellaeStatus();

        public FasciculusThesaurorumPuellae() {
        }

        public FasciculusThesaurorumPuellae(FasciculusConfigurationumDucisPuellae configuratio) {
            if (configuratio == null) {
                return;
            }

            InTerrae = new ThesaurusPuellaeInTerrae(configuratio.InTerrae);
            Status = new FasciculusThesaurorumPuellaeStatus(configuratio.Status);
        }
    }
}
