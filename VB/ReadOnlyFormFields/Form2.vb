Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraScheduler


Namespace ReadOnlyFormFields
	Partial Public Class Form2
		Inherits DevExpress.XtraScheduler.UI.AppointmentForm
		Public Sub New(ByVal control As SchedulerControl, ByVal apt As Appointment, ByVal openRecurrenceForm As Boolean)
			MyBase.New(control, apt, openRecurrenceForm)
			Me.tbSubject.Enabled = False
			Me.edtEndDate.Enabled = False
			Me.edtEndTime.Enabled = False
		End Sub
		Protected Overrides Sub chkAllDay_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.chkAllDay_EditValueChanged(sender, e)
			Me.edtEndDate.Enabled = False
			Me.edtEndTime.Enabled = False
		End Sub
	End Class

End Namespace
