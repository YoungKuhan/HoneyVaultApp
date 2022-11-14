using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyVaultApp
{
    class Bee
    {
        public virtual float CostPerShift { get; }
        public string Job { get; private set; }

        public Bee(string role)
        {
            Job = role;
        }
        public void WorkNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
        }
        protected virtual void DoJob()
        {

        }
    }
}
