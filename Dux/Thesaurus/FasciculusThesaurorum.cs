using Yulinti.MinisteriaUnity.ConfiguratioDucis;

namespace Yulinti.Dux.Thesaurus {
    public sealed class FasciculusThesaurorum {
        public FasciculusThesaurorumPuellae Puellae { get; set; } = new FasciculusThesaurorumPuellae();

        public FasciculusThesaurorum() {
        }

        public FasciculusThesaurorum(FasciculusConfigurationumDucis configuratio) {
            if (configuratio == null) {
                return;
            }

            Puellae = new FasciculusThesaurorumPuellae(configuratio.Puellae);
        }
    }
}
