using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace Utilidades
{
    public class ListaPaises
    {
        private static List<String> Nombres = new List<string>();
        public static void llenarPaises()
        {
            string nom = "";
            foreach (CultureInfo cultura in CultureInfo.GetCultures(CultureTypes.SpecificCultures ))
            {
                    RegionInfo infoRegion = new RegionInfo(cultura.LCID);
                    nom = infoRegion.DisplayName;
                if (!Nombres.Contains (nom)) Nombres.Add(nom); 
            }
            Nombres.Sort();
        }
    }
}
