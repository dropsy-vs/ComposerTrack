using AdofaiMapConverter;
using ComposerTrack.Easing;
using ComposerTrack.Models;
using ComposerTrack.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

#nullable disable
namespace ComposerTrack.ViewModels
{
    public class EditorVM : INotifyPropertyChanged, IWindowData<CreateProjectModel>
    {
        private ObservableCollection<KeyFrame> keyFrames;
        private EditorModel editorModel;
        private CustomLevel level;
        private ObservableCollection<TileData> tiles;
        private ObservableCollection<DecoData> decorations;
        private RelayCommand addTileCommand;
        private RelayCommand addDecoCommand;
        private RelayCommand deleteTileCommand;
        private RelayCommand deleteDecoCommand;
        private CreateProjectModel project;

        public RelayCommand AddTileCommand
        {
            get
            {
                return addTileCommand ??= new RelayCommand(obj =>
                    {
                        AddTilesWindow window = new();
                        window.ShowDialog();
                        
                    });
            }
        }

        public RelayCommand AddDecoCommand
        {
            get
            {
                return addDecoCommand ??= new RelayCommand(obj =>
                    {
                    }
                );
            }   
        }
        public RelayCommand DeleteTileCommand
        {
            get
            {
                return deleteTileCommand ??= new RelayCommand(obj =>
                    {
                        TileData tile = obj as TileData;
                        if (tile != null)
                        {
                            Tiles.Remove(tile);
                        }
                    }
                );
            }
        }
        public RelayCommand DeleteDecoCommand
        {
            get
            {
                return deleteDecoCommand ??= new RelayCommand(obj =>
                    {
                        DecoData deco = obj as DecoData;
                        if (deco != null)
                        {
                            Decorations.Remove(deco);
                        }
                    }
                );
            }
        }

        public ObservableCollection<KeyFrame> KeyFrames
        {
            get { return keyFrames; }
            set
            {
                keyFrames = value;
                OnPropertyChanged();
            }
        }
        public EditorModel EditorModel
        {
            get { return editorModel; }
            set
            {
                editorModel = value;
                OnPropertyChanged("EditorModel");
            }
        }
        public ObservableCollection<TileData> Tiles
        {
            get { return tiles; }
            set
            {
                tiles = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DecoData> Decorations
        {
            get { return decorations; }
            set
            {
                decorations = value;
                OnPropertyChanged();
            }
        }
        public CreateProjectModel Project
        {
            get { return project; }
            set
            {
                project = value;
                OnPropertyChanged();
            }
        }
        public CustomLevel Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged();
            }
        }

        public CreateProjectModel Data { get; set; }
        public object Sender { get; set; }

        public EditorVM(IWindowData<CreateProjectModel> data)
        {
            EditorModel = new EditorModel();
            Project = data.Data;
            KeyFrames = new ObservableCollection<KeyFrame>();
        }


#nullable enable
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
