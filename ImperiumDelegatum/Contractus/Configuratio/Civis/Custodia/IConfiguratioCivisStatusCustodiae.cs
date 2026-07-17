namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioCivisStatusCustodiae {
    }

    public interface IConfiguratioCivisStatusCustodiaeAttendens : IConfiguratioCivisStatusCustodiae {
        float AugmentumSuspectaeVisaeSec { get; }
        float AugmentumSuspectaeAuditaeSec { get; }
        float DeminutioSuspectaeSec { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeIntuitus : IConfiguratioCivisStatusCustodiaeAttendens {
        float AugmentumIntentionisSec { get; }
        float DeminutioIntentionisSec { get; }
        float AugmentumStudiumSec { get; }
        float DeminutioStudiumSec { get; }
        float DeminutioStudiumAdRecsationemSec { get; }
        float DeminutioStudiumAdAmittensSec { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeCircumitus : IConfiguratioCivisStatusCustodiaeAttendens {
    }

    public interface IConfiguratioCivisStatusCustodiaeVigilantia : IConfiguratioCivisStatusCustodiae {
        float DeminutioStudiumAdIntuitusSec { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeSpectans : IConfiguratioCivisStatusCustodiaeIntuitus {
    }

    public interface IConfiguratioCivisStatusCustodiaeSequens : IConfiguratioCivisStatusCustodiaeIntuitus {
    }

    public interface IConfiguratioCivisStatusCustodiaeQuaerens : IConfiguratioCivisStatusCustodiaeAttendens {
        float DeminutioStudiumAdCassationemSec { get; }
    }

    public interface IConfiguratioCivisStatusCustodiaeDiscedens : IConfiguratioCivisStatusCustodiae {
    }

}