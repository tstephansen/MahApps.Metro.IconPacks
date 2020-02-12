﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using AsyncAwaitBestPractices;

namespace MahApps.Metro.IconPacks.Browser.ViewModels
{
    public class IconPackViewModel : ViewModelBase
    {
        private IEnumerable<IIconViewModel> _icons;
        private ICollectionView _iconsCollectionView;
        private string _filterText;
        private IIconViewModel _selectedIcon;

        public IconPackViewModel(MainViewModel mainViewModel, string caption, Type enumType, Type packType)
        {
            this.MainViewModel = mainViewModel;
            this.Caption = caption;

            this.LoadEnumsAsync(enumType, packType).SafeFireAndForget();
        }

        private async Task LoadEnumsAsync(Type enumType, Type packType)
        {
            var collection = await Task.Run(() => GetIcons(enumType, packType).OrderBy(i => i.Name, StringComparer.InvariantCultureIgnoreCase).ToList());

            this.Icons = new ObservableCollection<IIconViewModel>(collection);
            this.PrepareFiltering();
            this.SelectedIcon = this.Icons.First();
        }

        public IconPackViewModel(MainViewModel mainViewModel, string caption, Type[] enumTypes, Type[] packTypes)
        {
            this.MainViewModel = mainViewModel;
            this.Caption = caption;

            this.LoadAllEnumsAsync(enumTypes, packTypes).SafeFireAndForget();
        }

        private async Task LoadAllEnumsAsync(Type[] enumTypes, Type[] packTypes)
        {
            var collection = await Task.Run(() =>
            {
                var allIcons = Enumerable.Empty<IIconViewModel>();
                for (var counter = 0; counter < enumTypes.Length; counter++)
                {
                    allIcons = allIcons.Concat(GetIcons(enumTypes[counter], packTypes[counter]));
                }

                return allIcons.OrderBy(i => i.Name, StringComparer.InvariantCultureIgnoreCase).ToList();
            });

            this.Icons = new ObservableCollection<IIconViewModel>(collection);
            this.PrepareFiltering();
            this.SelectedIcon = this.Icons.First();
        }

        private void PrepareFiltering()
        {
            this._iconsCollectionView = CollectionViewSource.GetDefaultView(this.Icons);
            this._iconsCollectionView.Filter = o => this.FilterIconsPredicate(this.FilterText, (IIconViewModel)o);
        }

        private bool FilterIconsPredicate(string filterText, IIconViewModel iconViewModel)
        {
            return string.IsNullOrWhiteSpace(filterText)
                   || iconViewModel.Name.IndexOf(filterText, StringComparison.CurrentCultureIgnoreCase) >= 0
                   || (!string.IsNullOrWhiteSpace(iconViewModel.Description) && iconViewModel.Description.IndexOf(filterText, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }

        private static string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute != null ? attribute.Description : value.ToString();
        }

        private static IEnumerable<IIconViewModel> GetIcons(Type enumType, Type packType)
        {
            return Enum.GetValues(enumType)
                .OfType<Enum>()
                .Where(k => k.ToString() != "None")
                .Select(k => GetIconViewModel(enumType, packType, k));
        }

        private static IIconViewModel GetIconViewModel(Type enumType, Type packType, Enum k)
        {
            var description = GetDescription(k);
            return new IconViewModel()
            {
                Name = k.ToString(),
                Description = description,
                IconPackType = packType,
                IconType = enumType,
                Value = k
            };
        }

        public MainViewModel MainViewModel { get; }

        public string Caption { get; }

        public IEnumerable<IIconViewModel> Icons
        {
            get { return _icons; }
            set { Set(ref _icons, value); }
        }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (Set(ref _filterText, value))
                {
                    this._iconsCollectionView.Refresh();
                }
            }
        }

        public IIconViewModel SelectedIcon
        {
            get { return _selectedIcon; }
            set { Set(ref _selectedIcon, value); }
        }
    }

    public interface IIconViewModel
    {
        string Name { get; set; }
        string Description { get; set; }
        Type IconPackType { get; set; }
        Type IconType { get; set; }
        object Value { get; set; }
    }

    public class IconViewModel : ViewModelBase, IIconViewModel
    {
        public IconViewModel()
        {
            this.CopyToClipboard =
                new SimpleCommand
                {
                    CanExecuteDelegate = x => (x != null),
                    ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var icon = (IIconViewModel)x;
                        var text = $"<iconPacks:{icon.IconPackType.Name} Kind=\"{icon.Name}\" />";
                        Clipboard.SetDataObject(text);
                    }))
                };

            this.CopyToClipboardAsContent =
                new SimpleCommand
                {
                    CanExecuteDelegate = x => (x != null),
                    ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var icon = (IIconViewModel)x;
                        var text = $"{{iconPacks:{icon.IconPackType.Name.Replace("PackIcon", "")} Kind={icon.Name}}}";
                        Clipboard.SetDataObject(text);
                    }))
                };

            this.CopyToClipboardAsPathIcon =
                new SimpleCommand
                {
                    CanExecuteDelegate = x => (x != null),
                    ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var icon = (IIconViewModel)x;
                        // The UWP type is in WPF app not available
                        var text = $"<iconPacks:{icon.IconPackType.Name.Replace("PackIcon", "PathIcon")} Kind=\"{icon.Name}\" />";
                        Clipboard.SetDataObject(text);
                    }))
                };
            this.CopyToClipboardAsPathData = new SimpleCommand
            {
                CanExecuteDelegate = x => (x != null),
                ExecuteDelegate = x => Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var viewModel = (IIconViewModel)x;
                    var iconType = IconPackType.ToString().Split('.')[3];
                    var data = PathHelper.GetTypeFromString(iconType, viewModel.Name);
                    if (!string.IsNullOrEmpty(data))
                    {
                        var text = $"<Viewbox>\n\t<Path Data=\"{data}\"\n\t\t  Fill=\"#FFFFFFFF\" \n\t\t  SnapsToDevicePixels=\"False\" \n\t\t  UseLayoutRounding=\"False\" \n\t\t  Stretch=\"Uniform\"/>\n</Viewbox>";
                        Clipboard.SetDataObject(text);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Unable to find path data.");
                    }
                }))
            };
        }

        public ICommand CopyToClipboard { get; }

        public ICommand CopyToClipboardAsContent { get; }

        public ICommand CopyToClipboardAsPathIcon { get; }

        public ICommand CopyToClipboardAsPathData { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Type IconPackType { get; set; }

        public Type IconType { get; set; }

        public object Value { get; set; }
    }
}