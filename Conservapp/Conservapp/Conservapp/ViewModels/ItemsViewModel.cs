﻿using System;

namespace Conservapp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public ItemsViewModel()
        {
            try
            {
                Title = "Formulario";
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }
        }

    }
}