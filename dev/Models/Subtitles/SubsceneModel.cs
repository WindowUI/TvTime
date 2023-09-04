﻿namespace TvTime.Models;
public class SubsceneModel : ITvTimeModel
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Server { get; set; }
    public string Translator { get; set; }
    public string Language { get; set; }
    public string Desc { get; set; }
    public string FileSize { get; set; }
    public string DateTime { get; set; }
    public string GroupKey { get; set; }
    public bool IsActive { get; set; }
    public ServerType ServerType { get; set; }
}