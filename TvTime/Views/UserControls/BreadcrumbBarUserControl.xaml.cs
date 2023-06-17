﻿namespace TvTime.Views;
public sealed partial class BreadcrumbBarUserControl : UserControl
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public List<string> Items
    {
        get { return (List<string>) GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }

    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register("Items", typeof(List<string>), typeof(BreadcrumbBarUserControl), new PropertyMetadata(null));

    public string SingleItem
    {
        get { return (string) GetValue(SingleItemProperty); }
        set { SetValue(SingleItemProperty, value); }
    }

    public static readonly DependencyProperty SingleItemProperty =
        DependencyProperty.Register("SingleItem", typeof(string), typeof(BreadcrumbBarUserControl), new PropertyMetadata(default(string)));

    private ObservableCollection<string> breadcrumbBarCollection;

    public ObservableCollection<string> BreadcrumbBarCollection
    {
        get { return breadcrumbBarCollection; }
        set
        {
            breadcrumbBarCollection = value;
            OnPropertyChanged();
        }
    }

    public BreadcrumbBarUserControl()
    {
        this.InitializeComponent();
        BreadcrumbBarCollection = new();
        Loaded += BreadcrumbBarUserControl_Loaded;
    }

    private void BreadcrumbBarUserControl_Loaded(object sender, RoutedEventArgs e)
    {
        BreadcrumbBarCollection.Add(Application.Current.Resources["BreadCrumbBarRootText"] as string);
        if (Items != null)
        {
            foreach (var item in Items)
            {
                BreadcrumbBarCollection.Add(item);
            }
        }
        else
        {
            BreadcrumbBarCollection.Add(SingleItem);
        }
    }

    private void BreadcrumbBar_ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
    {
        int numItemsToGoBack = BreadcrumbBarCollection.Count - args.Index - 1;
        for (int i = 0; i < numItemsToGoBack; i++)
        {
            App.Current.NavigationManager.GoBack();
        }
    }
}

