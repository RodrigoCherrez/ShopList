using SQLite;
using System.ComponentModel;

namespace ShopList.Gui.Models
{
    
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        [DefaultValue(1)]
        public int Cantidad { get; set; }
        public bool Comprado { get; set; }
        public override string ToString()
        {
            return $"{Nombre} ( {Cantidad} )";
        }
    }
}
