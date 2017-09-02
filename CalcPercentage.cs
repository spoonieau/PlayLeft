/*
 * PlayLeft Small application to get the battery level of your Xbox Controller as a UWP app.
 * First UWP as such just learing how the platform works.
 * Released under GPL3, Developed by Spoonie_au.
 */

//Class to work out remaing percentage of battery left.
namespace PlayLeft
{
    class CalcPercentage
    {
        private double bF;
        private double bC;

        public double BatteryFull
        {
            get { return bF; }
            set { bF = value; }
        }

        public double BatteryCurrent
        {
            get { return bC; }
            set { bC = value; }
        }

        public string Percentage(double bC, double bF)
        {
            BatteryFull = bF;
            BatteryCurrent = bC;

            //Get current percentage.
            string ammount = ((bC / bF) * 100) + "%".ToString();
            return ammount;

        }

    }
}
