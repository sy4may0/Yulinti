namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisCustodiaeStatus {
        IConfiguratioCivisCustodiaeStatusCommunis ConfiguratioCustodiaeStatusCommunis { get; }
        IConfiguratioCivisCustodiaeStatusCircumitus ConfiguratioCustodiaeStatusCircumitus { get; }
        IConfiguratioCivisCustodiaeStatusVigilantia ConfiguratioCustodiaeStatusVigilantia { get; }
        IConfiguratioCivisCustodiaeStatusSpectans ConfiguratioCustodiaeStatusSpectans { get; }
        IConfiguratioCivisCustodiaeStatusSequens ConfiguratioCustodiaeStatusSequens { get; }
        IConfiguratioCivisCustodiaeStatusQuaerens ConfiguratioCustodiaeStatusQuaerens { get; }
        IConfiguratioCivisCustodiaeStatusDiscedens ConfiguratioCustodiaeStatusDiscedens { get; }
        IConfiguratioCivisCustodiaeStatusRefrigerationis ConfiguratioCustodiaeStatusRefrigerationis { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusCommunis {
        float TempusSuspectaeStudiumHabereMaxima { get; }
        float TempusSuspectaeStudiumHabereMedia { get; }
        float TempusSuspectaeStudiumHabereMinima { get; }
        float PraeruptioSuspectaeTempusStudiumHabere { get; }
        float TempusSuspectaeStudiumAmittereMaxima { get; }
        float TempusSuspectaeStudiumAmittereMedia { get; }
        float TempusSuspectaeStudiumAmittereMinima { get; }
        float PraeruptioSuspectaeTempusStudiumAmittere { get; }
        float TempusStudiiStudiumHabereMaxima { get; }
        float TempusStudiiStudiumHabereMedia { get; }
        float TempusStudiiStudiumHabereMinima { get; }
        float PraeruptioStudiiTempusStudiumHabere { get; }
        float TempusStudiiStudiumAmittereMaxima { get; }
        float TempusStudiiStudiumAmittereMedia { get; }
        float TempusStudiiStudiumAmittereMinima { get; }
        float PraeruptioStudiiTempusStudiumAmittere { get; }
        float TempusIntentionisStudiumHabereMaxima { get; }
        float TempusIntentionisStudiumHabereMedia { get; }
        float TempusIntentionisStudiumHabereMinima { get; }
        float PraeruptioIntentionisTempusStudiumHabere { get; }
        float TempusIntentionisStudiumAmittereMaxima { get; }
        float TempusIntentionisStudiumAmittereMedia { get; }
        float TempusIntentionisStudiumAmittereMinima { get; }
        float PraeruptioIntentionisTempusStudiumAmittere { get; }
        float TempusSuspectaeConservandi { get; }
        float TempusStudiiConservandi { get; }
        float TempusIntentionisConservandi { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusAttendens {
        float AugmentumSuspectaeVisaeSec { get; }
        float AugmentumSuspectaeAuditaeSec { get; }
        float DeminutioSuspectaeSec { get; }
        float SuspectaMaximaNihilAnomaliae { get; }
        float SuspectaMaximaAuditaeSolus { get; }
        float SuspectaMaximaAnomaliaeDeest { get; }
        float AnomaliaeMinimaAdVigilantiam { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusIntuitus : IConfiguratioCivisCustodiaeStatusAttendens {
        float AugmentumIntentionisSec { get; }
        float DeminutioIntentionisSec { get; }
        float AugmentumStudiumSec { get; }
        float DeminutioStudiumSec { get; }
        float DeminutioStudiumAdRecusationemSec { get; }
        float DeminutioStudiumAdAmittensSec { get; }
        // Suspecta がこの割合(対Maxima)を下回ると Quaerens へ遷移する。
        float RatioSuspectaeMinimaAdQuaerens { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusCircumitus : IConfiguratioCivisCustodiaeStatusAttendens {
    }

    public interface IConfiguratioCivisCustodiaeStatusVigilantia {
        float DeminutioStudiumAdIntuitusSec { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusSpectans : IConfiguratioCivisCustodiaeStatusIntuitus {
        // Intentio がこの割合(対Maxima)以上になると Sequens へ遷移する。
        float RatioIntentionisAdSequens { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusSequens : IConfiguratioCivisCustodiaeStatusIntuitus {
    }

    public interface IConfiguratioCivisCustodiaeStatusQuaerens : IConfiguratioCivisCustodiaeStatusAttendens {
        float DeminutioStudiumAdCassationemSec { get; }
    }

    public interface IConfiguratioCivisCustodiaeStatusDiscedens : IConfiguratioCivisCustodiaeStatusAttendens {
    }

    public interface IConfiguratioCivisCustodiaeStatusRefrigerationis : IConfiguratioCivisCustodiaeStatusAttendens {
        float DistantiaRefrigerationis { get; }
        float DeminutioStudiumAdRefrigerationemSec { get; }
    }
}