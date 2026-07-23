namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisStatusCustodiae {
        IConfiguratioCivisStatusCustodiaeCommunis ConfiguratioStatusCustodiaeCommunis { get; }
        IConfiguratioCivisStatusCustodiaeCircumitus ConfiguratioStatusCustodiaeCircumitus { get; }
        IConfiguratioCivisStatusCustodiaeVigilantia ConfiguratioStatusCustodiaeVigilantia { get; }
        IConfiguratioCivisStatusCustodiaeSpectans ConfiguratioStatusCustodiaeSpectans { get; }
        IConfiguratioCivisStatusCustodiaeSequens ConfiguratioStatusCustodiaeSequens { get; }
        IConfiguratioCivisStatusCustodiaeQuaerens ConfiguratioStatusCustodiaeQuaerens { get; }
        IConfiguratioCivisStatusCustodiaeDiscedens ConfiguratioStatusCustodiaeDiscedens { get; }
        IConfiguratioCivisStatusCustodiaeRefrigerationis ConfiguratioStatusCustodiaeRefrigerationis { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeCommunis {
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

    public interface IConfiguratioCivisStatusCustodiaeAttendens {
        float AugmentumSuspectaeVisaeSec { get; }
        float AugmentumSuspectaeAuditaeSec { get; }
        float DeminutioSuspectaeSec { get; }
        float SuspectaMaximaNihilAnomaliae { get; }
        float SuspectaMaximaAuditaeSolus { get; }
        float SuspectaMaximaAnomaliaeDeest { get; }
        float AnomaliaeMinimaAdVigilantiam { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeIntuitus : IConfiguratioCivisStatusCustodiaeAttendens {
        float AugmentumIntentionisSec { get; }
        float DeminutioIntentionisSec { get; }
        float AugmentumStudiumSec { get; }
        float DeminutioStudiumSec { get; }
        float DeminutioStudiumAdRecusationemSec { get; }
        float DeminutioStudiumAdAmittensSec { get; }
        // Suspecta がこの割合(対Maxima)を下回ると Quaerens へ遷移する。
        float RatioSuspectaeMinimaAdQuaerens { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeCircumitus : IConfiguratioCivisStatusCustodiaeAttendens {
    }

    public interface IConfiguratioCivisStatusCustodiaeVigilantia {
        float DeminutioStudiumAdIntuitusSec { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeSpectans : IConfiguratioCivisStatusCustodiaeIntuitus {
        // Intentio がこの割合(対Maxima)以上になると Sequens へ遷移する。
        float RatioIntentionisAdSequens { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeSequens : IConfiguratioCivisStatusCustodiaeIntuitus {
    }

    public interface IConfiguratioCivisStatusCustodiaeQuaerens : IConfiguratioCivisStatusCustodiaeAttendens {
        float DeminutioStudiumAdCassationemSec { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeDiscedens : IConfiguratioCivisStatusCustodiaeAttendens {
    }

    public interface IConfiguratioCivisStatusCustodiaeRefrigerationis : IConfiguratioCivisStatusCustodiaeAttendens {
        float DistantiaRefrigerationis { get; }
        float DeminutioStudiumAdRefrigerationemSec { get; }
    }
}