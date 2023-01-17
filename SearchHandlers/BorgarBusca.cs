using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.SearchHandlers
{
    public class BorgarBusca : SearchHandler
    {
        public IList<BorgarDO> Borgars { get; set; }
        public string NavigationRoute { get; set; }
        public Type NavigationType { get; set; }
        protected override void OnQueryChanged(string valorViejo, string valorNuevo)
        {
            base.OnQueryChanged(valorViejo, valorNuevo);

            if (string.IsNullOrWhiteSpace(valorNuevo))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Borgars.Where(borgarrrr => borgarrrr.BorgarplusDesc.ToLower().Contains(valorNuevo.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            var navParam = new Dictionary<string, object>();
            navParam.Add("BorgarDetail", item);
            if (!string.IsNullOrWhiteSpace(NavigationRoute))
            {
                await Shell.Current.GoToAsync(NavigationRoute, navParam);
            }
        }
    }
}
