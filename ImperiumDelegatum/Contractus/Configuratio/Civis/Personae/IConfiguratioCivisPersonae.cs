using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisPersonae {
        IDCivisPersonae IDCivisPersonae { get; }
        IDCivisSchemae[] Schemarum { get; }
        int PondusGenerationis { get; }
        Vector2 VitaInitialis { get; }
        Vector2 VisusBasis { get; }
        Vector2 AuditusBasis { get; }
        Vector2 TorelantiaAnomaliaeMaxima { get; }
        Vector2 TorelantiaAnomaliaeMinima { get; }
    }
}