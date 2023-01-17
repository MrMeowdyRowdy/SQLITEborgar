﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    [QueryProperty(nameof(BorgarDetail), "BorgarDetail")]
    public partial class AddUpdateBorgarODModel : ObservableObject
    {
        [ObservableProperty]
        private BorgarDO _BorgarDetail = new BorgarDO();

        private readonly InterfaceBDD _studentService;
        public AddUpdateBorgarODModel(InterfaceBDD studentService)
        {
            _studentService = studentService;
        }

        [ICommand]
        public async void AddUpdateBorgar()
        {
            int response = -1;
            if (BorgarDetail.ODBorgarID > 0)
            {
                response = await _studentService.UpdateBorgarDO(BorgarDetail);
            }
            else
            {
                response = await _studentService.AddBorgarDO(new Models.BorgarDO
                {
                    ConQueso = BorgarDetail.ConQueso,
                    NombreOD = BorgarDetail.NombreOD,
                    DescripcionOD = BorgarDetail.DescripcionOD,
                });
            }

        

            if (response > 0)
            {

                await Shell.Current.DisplayAlert("Hamburguesa Guardada", "Registro guardado exitosamente", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("ERROR", "Algo fallo mientras se guardaba el registro", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}
