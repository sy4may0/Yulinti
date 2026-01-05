using Yulinti.Velum.ContractusVeli;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Velum.Indicium {
    internal sealed class VelumIndicia : IVelumIndicia {
        private readonly IIndicium[] _indicia;

        public VelumIndicia(IReadOnlyList<IIndicium> indicia) {
            _indicia = indicia.ToArray();
        }

        public void AdIndicium() {
            foreach (IIndicium indicum in _indicia) {
                indicum.AdIndicium();
            }
        }
    }
}