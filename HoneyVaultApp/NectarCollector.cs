using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyVaultApp
{
    class NectarCollector : Bee
    {
        public override float CostPerShift { get {return 1.95f; } }
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        public NectarCollector() : base("Zbieraczka nektaru") { }
        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }

    }
}
