﻿using Microsoft.UI.Xaml.Data;

namespace TvTime.Common;

public class ViewType2BitmapIconConverter : IValueConverter
{
    private readonly (string, string)[] _viewTypes = new[]
    {
        ("Series", "ms-appx:///Assets/Images/series.png"),
        ("Movie", "ms-appx:///Assets/Images/movie.png"),
        ("Anime", "ms-appx:///Assets/Images/anime.png")
    };
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var viewType = value as string;
        if (!string.IsNullOrEmpty(viewType))
        {
            var type = _viewTypes.FirstOrDefault(x => x.Item1.Equals(viewType, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(type.Item2))
            {
                return new BitmapIcon { UriSource = new Uri(type.Item2), ShowAsMonochrome = false };
            }
        }
        return new BitmapIcon { UriSource = new Uri("ms-appx:///Assets/Images/series.png"), ShowAsMonochrome = false };
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
