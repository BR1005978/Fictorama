using System;
using System.Collections.Generic;
using System.Text;

namespace cinema_app
{
    class Trailer
    {
        public static void Seetrailer(string trailer)
        {

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = trailer;
            System.Diagnostics.Process.Start(psi);
        }
    }
}