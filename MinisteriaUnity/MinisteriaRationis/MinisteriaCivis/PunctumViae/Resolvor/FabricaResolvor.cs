using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis
{
    internal static class FabricaResolvor
    {
        public static NihilAut<IResolvorPunctumViae> Creare(IDPunctumViaeTypi typus)
        {
            return typus switch
            {
                IDPunctumViaeTypi.Transitorium => new NihilAut<IResolvorPunctumViae>(new ResolvorTransitorium()),
                IDPunctumViaeTypi.Crematorium => new NihilAut<IResolvorPunctumViae>(new ResolvorCrematorium()),
                IDPunctumViaeTypi.Natorium => new NihilAut<IResolvorPunctumViae>(new ResolvorNatorium()),
                _ => new NihilAut<IResolvorPunctumViae>(null)
            };
        }
    }
}