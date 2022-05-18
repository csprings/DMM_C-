using OpenTap;

namespace DMM
{
    [Display("IDN", Group:"Multimeter")]
    public class IDN : TestStep
    {
        #region Settings
        // ToDo: Add property here for each parameter the end user should be able to change
        [Display("Instrument", Description:"check the connection of the insturment")]
        public DMM dMM {get; set;}
        #endregion
        public IDN()
        {
            // ToDo: Set default values for properties / settings.
        }

        public override void PrePlanRun()
        {
            base.PrePlanRun();
            // ToDo: Optionally add any setup code this step needs to run before the testplan starts
        }

        public override void Run()
        {
            // ToDo: Add test case code here
            string idn = dMM.ScpiQuery("*IDN?");
            Log.Info(idn);
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
