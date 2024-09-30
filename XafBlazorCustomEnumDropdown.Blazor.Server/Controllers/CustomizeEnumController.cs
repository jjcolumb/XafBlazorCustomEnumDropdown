using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.BaseImpl;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using XafBlazorCustomEnumDropdown.Module.BusinessObjects;

namespace XafBlazorCustomEnumDropdown.Blazor.Server.Controllers
{
    public class CustomizeEnumController:ViewController<DetailView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var editors = View.GetItems<PropertyEditor>();
            
        }
        protected override  void  OnActivated()
        {
            base.OnActivated();
            View.CustomizeViewItemControl<EnumPropertyEditor>(this, CustomizeDateTimeEditor);
        }
        
        private void CustomizeDateTimeEditor(EnumPropertyEditor propertyEditor)
        {
            if (propertyEditor!=null)
            {
                //propertyEditor.ComponentModel.CustomData = LoadCustomData;
                propertyEditor.ComponentModel.CustomData = async (options, cancellationToken) =>
                {
                    await System.Threading.Tasks.Task.Delay(1000);
                    var enumValues = Enum.GetValues(typeof(ShifDaysOfTheWeek))
                                    .Cast<Enum>()
                                    .Where(e => e.ToString().StartsWith("S"))
                                    .Select(e => new
                                    {
                                        Text = e.ToString(),
                                        Value = Convert.ToInt32(e)
                                    });

                    return new LoadResult
                    {
                        data = enumValues
                    };
                };
            }
            var enumValues = Enum.GetValues(typeof(ShifDaysOfTheWeek))
                                   .Cast<Enum>()
                                   .Where(e => e.ToString().StartsWith("S"))
                                   .Select(e => new
                                   {
                                       Text = e.ToString(),
                                       Value = Convert.ToInt32(e)
                                   });
            var test = propertyEditor.ComponentModel.CustomData;
        }
        //protected async Task<LoadResult> LoadCustomData(DataSourceLoadOptionsBase options, CancellationToken cancellationToken)
        //{
        //    await System.Threading.Tasks.Task.Delay(1000);
        //    var enumValues = Enum.GetValues(typeof(ShifDaysOfTheWeek))
        //                               .Cast<Enum>()
        //                               .Where(e => e.ToString().StartsWith("S"))
        //                               .Select(e => new
        //                               {
                                           
        //                                   Value = Convert.ToInt32(e)
        //                               });
        //    return DataSourceLoader.Load(enumValues, options);
        //}
    }
    
}
