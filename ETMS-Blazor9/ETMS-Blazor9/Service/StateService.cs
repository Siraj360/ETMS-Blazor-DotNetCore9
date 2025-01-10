namespace Stock360_2025.Service;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Microsoft.Extensions.DependencyInjection;
public class StateService 
{

    private readonly BehaviorSubject<string> _title;

    public StateService()
    {
        _title = new BehaviorSubject<string>("Welcome to STOCK 360 Blazor App");
    }

    public IObservable<string> TitleObservable => _title.AsObservable();

    public void UpdateTitle(string newValue)
    {
        _title.OnNext(newValue);
    }

    public string GetTitle()
    {
        return _title.Value;
    }
}

