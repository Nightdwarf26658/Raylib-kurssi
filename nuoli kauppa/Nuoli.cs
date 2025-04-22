using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raylib_test
{
    enum KärkiMateriaali
    {
        Puu,
        Kivi,
        Piikivi,
        Rauta,
        Kulta,
        Timantti,
    }


    enum SulkaMateriaali
    {
        Lehti,
        Kanansulka,
        Kotkansulka,
    }

    internal class Nuoli
    {
        byte pituusCm;
        SulkaMateriaali sulka;
        KärkiMateriaali kärki;
    }
}
