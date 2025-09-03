using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using Architecture.Domain;

namespace Architecture.App.Models
{
    public partial class MapModel : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public BitmapImage? Picture { get; set; }

        public MapModel()
        {
            Name = "";
            Picture = new BitmapImage();
        }

        public MapModel(GameMap map)
        {
            Id = map.Id;
            Name = map.Name;
            Left = map.Left;
            Top = map.Top;
            Right = map.Right;
            Bottom = map.Bottom;
            Picture = ImageHelper.GetPicture(map.Picture);
        }
    }
}
