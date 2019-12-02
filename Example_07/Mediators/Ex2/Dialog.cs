using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_07.Mediators
{
    public class Dialog
    {
        public Control[] Controls { get; set; }
    }

    #region Controls

    public class Control {
        public string Name { get; set; }
        public bool IsActive { get; set; }
		public ControlMediator Mediator { get; set; }
    }
    public class TextControl : Control {
        private string _value { get; set; }
        public string Value { get { return _value; } set { _value = value; if (Mediator != null) Mediator.OnChange(); } }
    }
    public class DateControl : Control {
        private DateTime? _value { get; set; }
        public DateTime? Value { get { return _value; } set { _value = value; if (Mediator != null) Mediator.OnChange(); } }
    }
    public class ButtonControl : Control {
        public void Click()
        {
            if (IsActive)
            {
                Console.WriteLine($"{Name} btn was clicked!");
            } else
            {
                Console.WriteLine($"{Name} btn was disabled!");
            }
        }
    }

    #endregion

	public abstract class ControlMediator {
        public abstract void OnChange();
	}

    public class AgeConfirmDialogMediator : ControlMediator {
        private DateControl ageControl;
        private ButtonControl successButtonControl;

        public override void OnChange()
        {
            if (ageControl.Value.HasValue)
            {
                var now = DateTime.Now;
                var age = (now - ageControl.Value.Value).TotalDays / 365;
                successButtonControl.IsActive = age > 18;
            }
        }

        public AgeConfirmDialogMediator(DateControl age, ButtonControl successButton)
        {
            ageControl = age;
            successButtonControl = successButton;
        }
    }
}
