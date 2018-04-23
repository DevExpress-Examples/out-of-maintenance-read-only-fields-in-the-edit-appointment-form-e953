using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using System.IO;

namespace ReadOnlyFormFields {
    public partial class Form1 : Form {
        const string aptDataFileName = @"..\..\Data\appointments.xml";
        const string resDataFileName = @"..\..\Data\resources.xml";

        public Form1() {
            InitializeComponent();
            schedulerControl1.Start = new DateTime(2008, 07, 14);
            FillResourceStorage(schedulerStorage1.Resources.Items, resDataFileName);
            FillAppointmentStorage(schedulerStorage1.Appointments.Items, aptDataFileName);
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e) {
            Form2 f = new Form2((SchedulerControl)sender, e.Appointment, false);
            f.ShowDialog();
            e.Handled = true;
        }

        #region FillData

        static Stream GetFileStream(string fileName) {
            return new StreamReader(fileName).BaseStream;
        }

        static void FillResourceStorage(ResourceCollection c, string fileName) {
            using (Stream stream = GetFileStream(fileName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }
        static void FillAppointmentStorage(AppointmentCollection c, string fileName) {
            using (Stream stream = GetFileStream(fileName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }
        #endregion
    }
}