using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using Microsoft.AspNetCore.Components;
using XafBlazorCustomEnumDropdown.Module.BusinessObjects;

namespace XafBlazorCustomEnumDropdown.Blazor.Server.Editors.EnumEditor
{    
    [PropertyEditor(typeof(Enum),"CustomEnum", false)]
    public class EnumEditor : BlazorPropertyEditorBase
    {
        public EnumEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        public override EnumModel ComponentModel => (EnumModel)base.ComponentModel;
        protected override IComponentModel CreateComponentModel()
        {
            var model = new EnumModel();
            model.ValueExpression = () => model.Value;
            model.ValueChanged = EventCallback.Factory.Create<ShifDaysOfTheWeek>(this, value => {
                model.Value = value;
                OnControlValueChanged();
                WriteValue();
            });
            return model;
        }
        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            ComponentModel.Value = (ShifDaysOfTheWeek)PropertyValue;
        }
        protected override object GetControlValueCore() => ComponentModel.Value;
        protected override void ApplyReadOnly()
        {
            base.ApplyReadOnly();
            ComponentModel?.SetAttribute("readonly", !AllowEdit);
        }
    }
}
