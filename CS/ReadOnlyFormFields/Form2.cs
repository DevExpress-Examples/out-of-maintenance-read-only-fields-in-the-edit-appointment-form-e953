using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler;


namespace ReadOnlyFormFields {
    public partial class Form2 : DevExpress.XtraScheduler.UI.AppointmentForm {
        public Form2(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm) {
            this.tbSubject.Enabled = false;
            this.edtEndDate.Enabled = false;
            this.edtEndTime.Enabled = false;
        }
        protected override void chkAllDay_EditValueChanged(object sender, EventArgs e) {
            base.chkAllDay_EditValueChanged(sender, e);
            this.edtEndDate.Enabled = false;
            this.edtEndTime.Enabled = false;
        }
    }
    
}
