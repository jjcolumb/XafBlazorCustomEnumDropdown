using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using DevExpress.ExpressApp.Blazor.Components.Models;
using XafBlazorCustomEnumDropdown.Module.BusinessObjects;

namespace XafBlazorCustomEnumDropdown.Blazor.Server.Editors.EnumEditor
{
    public class EnumModel : ComponentModelBase
    {
        public ShifDaysOfTheWeek Value
        {
            get => GetPropertyValue<ShifDaysOfTheWeek>();
            set => SetPropertyValue(value);
        }
        public EventCallback<ShifDaysOfTheWeek> ValueChanged
        {
            get => GetPropertyValue<EventCallback<ShifDaysOfTheWeek>>();
            set => SetPropertyValue(value);
        }
        public Expression<Func<ShifDaysOfTheWeek>> ValueExpression
        {
            get => GetPropertyValue<Expression<Func<ShifDaysOfTheWeek>>>();
            set => SetPropertyValue(value);
        }
        public override Type ComponentType => typeof(EnumComponent);
    }
}
