using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IContentumOrdinatorPuellaeModi {
        IOstiumTemporisLegibile OsTemporis { get; }
        IOstiumInputMotusLegibile OsInputMotus { get; }
        IOstiumCameraLegibile OsCamera { get; }
        ThesaurusPuellaeStatuum Thesaurus { get; }
        ThesaurusPuellaeStatusCorporis ThesaurusStatus { get; }
    }
}