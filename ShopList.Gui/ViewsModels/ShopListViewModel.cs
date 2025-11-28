using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopList.Gui.ViewModels
{
    public class ShopListViewModel :INotifyPropertyChanged
        public partial class ShopListViewModel : ObservableObject
    /*:INotifyPropertyChanged*/
    {
        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;
        [ObservableProperty]
        private Item? _origenSeleccionado = null;
        //   public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item> Items { get; }
      //  public string NombreDelArticulo
        //{
          //  get => _nombreDelArticulo;
            //set
           // {
            //    if (value != _nombreDelArticulo)
              //  {
                //    _nombreDelArticulo = value;
                  //  OnPropertyChanged(nameof(NombreDelArticulo));
           //     }
           // }
       // }

     //   public int CantidadAComprar
       // {
         //   get => _cantidadAComprar;
          //  set
           // {
             //   if (value != _cantidadAComprar)
               // {
               //     _cantidadAComprar = value;
                //    OnPropertyChanged(nameof(CantidadAComprar));
               // }
           // }
      //  }

        //public ICommand AgregarShopListItemCommand {  get; private set; }

            public ShopListViewModel()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
            //    AgregarShopListItemCommand = new Command(AgregarShopListItem);
        }
        [RelayCommand]
          if (Items.Count > 0)
            {
                OrigenSeleccionado = Items[0];
            }

            else {
               OrigenSeleccionado = null!;
            
            }

            public void AgregarShopListItem()
   {
            if(string.IsNullOrEmpty(_nombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }

            Random generador = new Random();
            var item = new Item
            {
                Id = generador.Next(),  
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false,
            };
            Items.Add(item);
            NombreDelArticulo = String.Empty;
            CantidadAComprar = 1;
        }

[RelayCommand]
public void EliminarShopListItem()
        {
    if (OrigenSeleccionado == null) { return; }
    Item? nuevoSeleccionado;
    int indice = Items.IndexOf(OrigenSeleccionado);
    if (indice < Items.Count - 1)
    {

        nuevoSeleccionado = Items[indice + 1];
    }
    else
    {
        if (Items.Count > 1)
        {

            nuevoSeleccionado = Items[Items.Count - 2];

        }
        else
        {
            nuevoSeleccionado = null;
        }


    }
    Items.Remove(OrigenSeleccionado);
    OrigenSeleccionado = nuevoSeleccionado;
}
[RelayCommand]
private void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                Comprado = false,
            });

            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Huevos",
                Cantidad = 2,
                Comprado = false,

            });
           
            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Jamon",
                Cantidad = 500,
                Comprado = false,

            });
        }

      //  private void OnPropertyChanged(string propertyName)
        //{
          // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

      //  }


    }
}