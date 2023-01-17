using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using SQLiteDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    public partial class BorgarListODModel : ObservableObject
    {
        public static List<BorgarDO> BorgarsForSearchDO { get; private set; } = new List<BorgarDO>();
        public ObservableCollection<BorgarDO> BorgarsDO { get; set; } = new ObservableCollection<BorgarDO>();

        private readonly InterfaceBDD _borgarServiceDO;
        public BorgarListODModel(InterfaceBDD borgarservice)
        {
            _borgarServiceDO = borgarservice;
        }



        [ICommand]
        public async void GetBorgarListDO()
        {
            BorgarsDO.Clear();
            var borgarList = await _borgarServiceDO.GetBorgarListDO();
            if (borgarList?.Count > 0)
            {
                borgarList = borgarList.OrderBy(f => f.NombreOD).ToList();
                foreach (var borgar in borgarList)
                {
                    BorgarsDO.Add(borgar);
                }
                BorgarsForSearchDO.Clear();
                BorgarsForSearchDO.AddRange(borgarList);
            }
        }


        [ICommand]
        public async void AddUpdateBorgar()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateBorgarDetail));
        }


        [ICommand]
        public async void MostrarAccion(BorgarDO borgarmodel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "BorgarDetail", borgarmodel }
                };
                await AppShell.Current.GoToAsync(nameof(AddUpdateBorgarDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _borgarServiceDO.DeleteBorgarDO(borgarmodel);
                if (delResponse > 0)
                {
                    GetBorgarListDO();
                }
            }
        }
    }
}
