using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyVaultApp
{
    static class HoneyVault
    {
        public static string StatusReport
        {
            get
            {
                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings += "\nMAŁO MIODU - DODAJ PRODUCENTÓW MIODU!";
                if (nectar < LOW_LEVEL_WARNING) warnings += "\nMALO NEKTARU - DODAJ PRODUCENTÓW NEKTARU!";
                return $"\nILOŚĆ MIODU: {honey} ILOŚĆ NEKTARU: {nectar}\n" + warnings;
            }
        }
        const float NECTAR_CONVERSION_RATIO = 0.19F;
        const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;
        /// <summary>
        /// Zamienia nektar na miód, jesli amount jest wieksze niż ilość nekatru, zamienia cały pozostały nektar
        /// </summary>
        /// <param name="amount">wartość zamiany nektaru w miód</param>
        public static void ConvertNectarToHoney(float amount)
        {

            if (amount > nectar)
            {
                honey += (nectar * NECTAR_CONVERSION_RATIO);
                nectar = 0;
            }
            else
            {
                honey += (amount * NECTAR_CONVERSION_RATIO);
                nectar -= amount;
            }
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
            return false;
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0) nectar += amount;
        }


    }
}
