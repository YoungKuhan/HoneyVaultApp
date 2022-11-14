using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyVaultApp
{
    class Queen : Bee
    {
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private float eggs;
        private float unassignedWorkers = 3;
        private Bee[] workers = new Bee[0];
        private string StatusReport;
        public override float CostPerShift { get { return 2.15f; } }
        public Queen() : base("Królowa") 
        {
            AssignBee("Opiekunka jaj");
            AssignBee("Zbieraczka nektaru");
            AssignBee("Przetwórczyni miodu");
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach(Bee worker in workers)
            {
                worker.WorkNextShift();
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
        }
        private void AssignBee(string role)
        {
            switch (role)
            {
                case "Opiekunka jaj":
                    AddWorker(new EggCare(this));
                    break;
                case "Zbieraczka nektaru":
                    AddWorker(new NectarCollector());
                    break;
                case "Przetwórczyni miodu":
                    AddWorker(new HoneyManufacturer());
                    break;
            }
            UpdateStatusReport();
        }
        private void AddWorker(Bee worker)
        {
            if(unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }
        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
            {
                if (job == Job) count++;
            }
            return $"{Job}: {count}\n";
        }
        private void UpdateStatusReport()
        {
            StatusReport = HoneyVault.StatusReport + $"Liczba jaj: {eggs}\n" +
                $"Nieprzydzielone robotnice: {unassignedWorkers}\n" +
                WorkerStatus("Opiekunka jaj") + WorkerStatus("Zbieraczka nektaru") + WorkerStatus("Przetwórczyni miodu");


        }
    }
    
}
