using OpenTap;

namespace DMM
{
    [Display("Measurement", Group:"Multimeter")]
    public class Measurement : TestStep
    {
        #region Settings
        // ToDo: Add property here for each parameter the end user should be able to change
        [Display("Instrument", Description:"check the connection of the insturment")]
        public DMM dMM {get; set;}
        [Display("Measurement")]
        public MEAS meas {get; set;}
        #endregion

        public enum MEAS
        {
            Capacitance,
            Continuity,
            Current,
            Diode,
            Frequency,
            Period,
            Resistance,
            Temperature,
            Voltage
        }
        public Measurement()
        {
            // ToDo: Set default values for properties / settings.
            meas = MEAS.Resistance;
        }

        public override void PrePlanRun()
        {
            base.PrePlanRun();
            // ToDo: Optionally add any setup code this step needs to run before the testplan starts
        }

        public override void Run()
        {
            // ToDo: Add test case code here
            double Return = dMM.ScpiQuery<double>($"MEASure:{meas}?");
            Log.Info(Return.ToString());
            RunChildSteps(); //If step has child steps.
            UpgradeVerdict(Verdict.Pass);
        }

        public override void PostPlanRun()
        {
            // ToDo: Optionally add any cleanup code this step needs to run after the entire testplan has finished
            base.PostPlanRun();
        }
    }
}
